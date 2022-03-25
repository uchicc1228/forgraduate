using Sakei.Manager.ExamSystemManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sakei.Helper.ExamSystemHelpers
{
    public class ChoseExamLevelHelper
    {
        /// <summary>
        /// 判斷使用者等級是否足夠
        /// </summary>
        /// <param name="userLevel">使用者等級</param>
        /// <param name="targetLevel">測試、物品等級</param>
        /// <returns></returns>
        public static bool IsLevelEnough(int userLevel, int targetLevel)
        {
            if (userLevel > targetLevel)
                return true;
            else
                return false;
        }

    }
}