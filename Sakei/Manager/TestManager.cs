using Sakei.Models;
using Sakei.Models.ExamSystemModels;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager
{
    public class TestManager
    {
        TestModel model = new TestModel();
        //確認是否有重複之題目
        public TestModel GetTest(string Content)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM TestDatabases
                    WHERE TestContent = @Content";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@Content", Content);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            TestModel model = new TestModel()
                            {
                                Type = (int)reader["TestTypeID"] ,
                                Content = reader["TestContent"] as string,
                                OptionsA = reader["OptionsA"] as string,
                                OptionsB = reader["OptionsB"] as string,
                                OptionsC = reader["OptionsC"] as string,
                                OptionsD = reader["OptionsD"] as string,
                                TestAnswer = reader["TestAnswer"] as string,
                                ID = (Guid)reader["TestID"],
                                Level = (int)reader["TestLevel"],
                                IsEnable = (int)reader["IsEnable"]
     
    };
                            return model;

                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("TestModel.GetAccount", ex);
                throw;
            }
        }

        ///<summary>抓取歷史回顧用題目資料(將資料從DB取出)</summary>
        ///<param name="testLevel">測驗等級</param>
        ///<param name="pageSize">每頁最大筆數</param>
        ///<param name="pageIndex">目前頁數</param>
        ///<param name="totalRows">每頁實際筆數</param>

        public bool CreateTest(TestModel model)
        {
          

            // 1. 判斷資料庫是否有相同的 Account
        //    if (this.GetTest(model.Content) != null)

          //      throw new Exception("已存在相同的題目");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @" INSERT INTO TestDatabases
                        (TestID,TestLevel, TestTypeID, TestContent, OptionsA, OptionsB, OptionsC,OptionsD,TestAnswer,IsEnable)
                    VALUES
                        (@id,  @level, @typeID, @content , @optionsA, @optionsB,  @optionsC, @optionsD,@answer,@isEnable );";



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@level", model.Level);
                        command.Parameters.AddWithValue("@typeID", model.Type);
                        command.Parameters.AddWithValue("@content", model.Content);
                        command.Parameters.AddWithValue("@optionsA", model.OptionsA);
                        command.Parameters.AddWithValue("@optionsB", model.OptionsB);
                        command.Parameters.AddWithValue("@optionsC", model.OptionsC);
                        command.Parameters.AddWithValue("@optionsD", model.OptionsD);
                        command.Parameters.AddWithValue("@answer", model.TestAnswer);
                        command.Parameters.AddWithValue("@isEnable ", model.IsEnable);




                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                Logger.WriteLog("CreateAccount", ex);
                return false;
            }
        }

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
                            info.UserAnswer = reader["UserAnswer"] as string;
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
                Logger.WriteLog("Sakei.Manager.TestManager.GetTestDataList", ex);
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
                TestAnswer = reader["TestAnswer"] as string
            };
        }
    }
}