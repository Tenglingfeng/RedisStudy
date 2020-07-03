using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRedisMQ_SMS.Async;
using MyRedisMQ_SMS.MQ;

namespace MyRedisMQ_SMS
{
    class Program
    {
        static void Main(string[] args)
        {

            using (RedisMessageQueue redis = new RedisMessageQueue("localhost:6379"))
            {
                //拉 时效性不高
                //redis.DeQueue("points");

                Console.WriteLine("发送短信开始消费*********** \r\n");
                while (true)
                {
                    //获取发送短信 推
                    string message = redis.BdQueue("sms", TimeSpan.FromSeconds(60));

                  
                    if (!string.IsNullOrEmpty(message))
                    {
                        //消费短信
                        OrderSms orderSms = new OrderSms();
                        orderSms.SendSms(message);
                    }
                }

            }
        }
    }
}
