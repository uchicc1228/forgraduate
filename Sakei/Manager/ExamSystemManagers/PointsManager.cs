using Sakei.Models.ExamSystemModels;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager.ExamSystemManagers
{
    public class PointsManager
    {
       
        ///<summary>增加使用者積分紀錄</summary> 
        public void CreatePoints(Guid userID,int corrent,int userLevel,int userPoints,int money)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                INSERT INTO PointsLists
                                ( UserID, Correct)
                                VALUES
                                ( @UserID, @Correct)
                                UPDATE UserAccounts
                                SET UserLevel = @UserLevel, UserPoints = @UserPoints, UserMoney += @Money
                                WHERE UserID= @UserID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@Correct", corrent);
                        command.Parameters.AddWithValue("@UserLevel", userLevel);
                        command.Parameters.AddWithValue("@UserPoints", userPoints);
                        command.Parameters.AddWithValue("@Money", money);
                        conn.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.PointsManager.CreatePoints", ex);
                throw;
            }
        }
        
       
    }
}