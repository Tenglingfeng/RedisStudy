using System;
using System.Collections.Generic;

namespace RedisPubSubTeam.Team
{
    /// <summary>
    /// 团购微服务
    /// </summary>
    public class Team
    {
        public readonly Dictionary<string, string> DataBaseDic = new Dictionary<string, string>();

        public Team()
        {
            DataBaseDic.Add("dev", "Data Source=.;initial Catalog=Team_Dev;User Id=sa;Pwd=123;");
            DataBaseDic.Add("test", "Data Source=.;initial Catalog=Team_Test;User Id=sa;Pwd=123;");
            DataBaseDic.Add("pro", "Data Source=.;initial Catalog=Team_Pro;User Id=sa;Pwd=123;");
        }


        public void UpdateDatabase(string databaseEnvironment)
        {
            Console.WriteLine($"获取数据库环境:{databaseEnvironment}");

            string databaseUrl = DataBaseDic[databaseEnvironment];
            Console.WriteLine($"更新数据库Url:{databaseUrl}");
        }

    }
}