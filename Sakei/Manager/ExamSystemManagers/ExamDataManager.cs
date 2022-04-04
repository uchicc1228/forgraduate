using Sakei.Models.ExamSystemModels;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager.ExamSystemManagers
{
    public class ExamDataManager
    {

        ///<summary>抓取歷史回顧用題目資料(將資料從DB取出)</summary>
        ///<param name="testLevel">測驗等級</param>
        ///<param name="pageSize">每頁最大筆數</param>
        ///<param name="pageIndex">目前頁數</param>
        ///<param name="totalRows">每頁實際筆數</param>
        public List<TestDataModel> GetTestDataList(Guid userID, int testLevel, int pageSize, int pageIndex, out int totalRows)
        {
            string levelWhereText = "";
            string andLevelText = "";
            //計算跳頁數
            int skip = pageSize * (pageIndex - 1);
            if (skip < 0)
                skip = 0;

            //如果testLevel，則尋找全等級
            if (testLevel != 0)
            {
                levelWhereText = $"WHERE TestLevel = {testLevel}";
                andLevelText = $"AND TestLevel = {testLevel}";
            }

            string commandExamText = $@"
                                        SELECT 
                                        TestID,TestLevel,TestTypes.TestTypeID,TypeContext,TestContent,
	                                    OptionsA,OptionsB,OptionsC,OptionsD,TestAnswer
									FROM TestDatabases
									INNER JOIN TestTypes
									ON TestDatabases.TestTypeID = TestTypes.TestTypeID
									WHERE IsEnable='TRUE'
                                        ";

            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                 SELECT TOP ({pageSize})
                                    UserAnswers.TestID,TestLevel,TestTypeID,TypeContext,TestContent,
	                                OptionsA,OptionsB,OptionsC,OptionsD,TestAnswer,UserAnswer
                                 FROM UserAnswers
                                 INNER JOIN 
                                 	({commandExamText})  AS Exam
                                ON UserAnswers.TestID = Exam.TestID
                                WHERE 
                                      UserID = @UserID {andLevelText} AND
                                      UserAnswers.TestID NOT IN(
                                            SELECT TOP {skip} TestID
                                            FROM UserAnswers 
                                            {levelWhereText}
                                            ORDER BY CreateDate
                                      )
                                ORDER BY CreateDate
                                ";
            string commandCountText =
                $@" SELECT COUNT(UserAnswers.TestID)
                    FROM UserAnswers
                    INNER JOIN TestDatabases
                    ON UserAnswers.TestID = TestDatabases.TestID
                    WHERE 
                        UserID = @UserID {andLevelText}
                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<TestDataModel> examDataList = new List<TestDataModel>();
                        //將資料取出放到List中
                        while (reader.Read())
                        {
                            TestDataModel info = BuildExamData(reader);
                            examDataList.Add(info);
                        }
                        reader.Close();
                        //取得總筆數
                        command.CommandText = commandCountText;

                        totalRows = (int)command.ExecuteScalar();
                        return examDataList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.TestDataManager.GetTestDataList", ex);
                throw;
            }
        }
        /// <summary> 抓取考試用資料 </summary>
        public List<TestDataModel> GetTestDataForTest(int testLevel, int testCount, Guid userID, bool isChalleng)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT TOP(@TestCount) 
                                	TestDatabases.TestID,TestLevel,TestTypes.TestTypeID,TypeContext,TestContent,
                                	OptionsA,OptionsB,OptionsC,OptionsD,TestAnswer,UserAnswer
                                FROM(TestDatabases
                                INNER JOIN TestTypes
                                ON TestDatabases.TestTypeID=TestTypes.TestTypeID)
                                LEFT JOIN UserAnswers
                                ON TestDatabases.TestID=UserAnswers.TestID
                                WHERE
	                                TestDatabases.TestLevel = @TestLevel AND
	                                IsEnable='true' AND
	                                ( UserID = @UserID OR UserID IS NULL )
                                ORDER BY NEWID()
                                ";
            string commandTextInsert = $@" 
                                        UPDATE UserAccounts
                                        SET UserPoints -= 10
                                        WHERE UserID = @UserID ";
            if (isChalleng)
            {
                commandText += commandTextInsert;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@TestLevel", testLevel);
                        command.Parameters.AddWithValue("@TestCount", testCount);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<TestDataModel> examDataList = new List<TestDataModel>();

                        //將資料取出放到List中
                        while (reader.Read())
                        {
                            TestDataModel info = BuildExamData(reader);
                            examDataList.Add(info);
                        }

                        return examDataList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.TestDataManager.GetTestDataForTest", ex);
                throw;
            }
        }

        private static TestDataModel BuildExamData(SqlDataReader reader)
        {
            return new TestDataModel
            {
                TestID = (Guid)reader["TestID"],
                TestLevel = (int)reader["TestLevel"],
                TestTypeID = (int)reader["TestTypeID"],
                TypeContext = reader["TypeContext"] as string,
                TestContent = reader["TestContent"] as string,
                OptionsA = reader["OptionsA"] as string,
                OptionsB = reader["OptionsB"] as string,
                OptionsC = reader["OptionsC"] as string,
                OptionsD = reader["OptionsD"] as string,
                TestAnswer = reader["TestAnswer"] as string,
                UserAnswer = reader["UserAnswer"] as string

            };
        }
    }
}