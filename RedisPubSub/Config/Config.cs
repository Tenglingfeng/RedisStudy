using System;

namespace RedisPubSub.Config
{
    /// <summary>
    /// 配置中心微服务
    /// </summary>
    public class Config
    {
        public void UpdateDatabase(string databaseEnvironment)
        {
            Console.WriteLine($"配置中心开始更新数据库环境:{databaseEnvironment}");

            //1.1开始发布
            PubSub.RedisPubSub redisPubSub = new PubSub.RedisPubSub();
            redisPubSub.Pub("database", databaseEnvironment);

            Console.WriteLine($"更新成功:{databaseEnvironment}");
        }
    }
}