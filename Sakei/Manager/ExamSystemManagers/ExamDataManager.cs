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
        public List<TestDataModel> GetTestDataList(int testLevel, int pageSize, int pageIndex, out int totalRows)
        {
            //計算跳頁數
            int skip = pageSize * (pageIndex - 1);
            if (skip < 0)
                skip = 0;

            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT TOP ({pageSize})
                                    TestID,TestLevel,TestTypes.TestTypeID,TypeContext,TestContent,
	                                OptionsA,OptionsB,OptionsC,OptionsD,TestAnswer
                                FROM TestDatabases
                                INNER JOIN TestTypes 
                                ON TestDatabases.TestTypeID = TestTypes.TestTypeID
                                WHERE IsEnable = 'true' AND
                                      TestLevel = {testLevel} AND
                                      TestID NOT IN(
                                            SELECT TOP {skip} TestID
                                            FROM TestDatabases 
                                            WHERE 
                                                IsEnable = 'true' AND
                                                TestLevel = {testLevel}
                                            ORDER BY CreatTime
                                      )
                                ORDER BY CreatTime
                                ";
            string commandCountText =
                $@" SELECT COUNT(TestID)
                    FROM TestDatabases
                    WHERE 
                        IsEnable = 'true' AND
                        TestLevel = {testLevel}
                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
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
        public List<TestDataModel> GetTestDataForTest(int testLevel)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT TestID,TestLevel,TestTypes.TestTypeID,TypeContext,TestContent,
	                                   OptionsA,OptionsB,OptionsC,OptionsD,TestAnswer
                                FROM(
                                SELECT TOP (10) *
                                FROM TestDatabases
                                WHERE IsEnable = 'true' AND
                                      TestLevel = @TestLevel
                                ORDER BY NEWID()
                                )AS OutputData
                                INNER JOIN TestTypes 
                                ON OutputData.TestTypeID=TestTypes.TestTypeID
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@TestLevel", testLevel);

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
                TestAnswer = reader["TestAnswer"] as string
            };
        }
    }
}