using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPubSubTeam
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("团购微服务开始订阅数据库消息");

            PubSub.RedisPubSub redisPubSub = new PubSub.RedisPubSub();
            redisPubSub.Sub("database", message =>
            {
                //获取订阅的主题消息
                string databaseEnv = message.Message;

                //处理逻辑 数据库更换

                Team.Team team = new Team.Team();
                team.UpdateDatabase(databaseEnv);

            });
            Console.ReadKey();
        }
    }
}
