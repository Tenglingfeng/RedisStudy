using MyRedisMQ_Points.Async;
using MyRedisMQ_Points.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisMQ_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RedisMessageQueue redis = new RedisMessageQueue("localhost:6379"))
            {
                //拉 时效性不高
                //redis.DeQueue("points");

                Console.WriteLine("积分开始消费*********** \r\n");
                while (true)
                {
                    //获取积分 推
                    string message = redis.BdQueue("points", TimeSpan.FromSeconds(60));

                    
                    if (!string.IsNullOrEmpty(message))
                    {
                        //消费积分
                        OrderPoints orderPoints = new OrderPoints();
                        orderPoints.AddPoints(message);

                    }
                }
          
            }
        }
    }
}
