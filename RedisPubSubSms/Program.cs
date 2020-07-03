using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPubSubSms
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("短信微服务开始订阅数据库消息");

            PubSub.RedisPubSub redisPubSub = new PubSub.RedisPubSub();
            redisPubSub.Sub("database", message =>
            {
                //获取订阅的主题消息
                string databaseEnv = message.Message;

                //处理逻辑 数据库更换

                Sms.Sms sms= new Sms.Sms();
                sms.UpdateDatabase(databaseEnv);

            });
            Console.ReadKey();
        }
    }
}
