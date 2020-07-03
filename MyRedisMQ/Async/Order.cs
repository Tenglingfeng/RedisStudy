using MyRedisMQ.MQ;
using System;
using System.Diagnostics;
using System.Threading;

namespace MyRedisMQ.Async
{
    public class Order
    {
        public string CreateOrder()
        {
            //统计时间
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //1:订单生成
            string orderSn = this.OrderGenrator();

            //1.1 存储到数据库
            Thread.Sleep(1000);
            Console.WriteLine($"订单{orderSn}保存成功! \r\n");

            //2:添加积分
            //Console.WriteLine("=========================================开始调用积分服务=========================================");
            //OrderPoints orderPoints = new OrderPoints();
            //orderPoints.AddPoints(orderSn);
            //Console.WriteLine("=========================================积分服务调用完成=========================================\r\n");

            ////3:发送短信
            //Console.WriteLine("=========================================开始调用发送短信========================================= ");
            //OrderSms orderSms = new OrderSms();
            //OrderSms.SendSms(orderSn);
            //Console.WriteLine("=========================================发送短信调用完成=========================================");

            //Redis优化:
            using (RedisMessageQueue redis = new RedisMessageQueue("localhost:6379"))
            {
                //1:添加积分
                redis.EnQueue("points", orderSn);
                //2:发送短信
                redis.EnQueue("sms", orderSn);
            }



            stopwatch.Stop();
            Console.WriteLine($" \r\n 订单耗时:{stopwatch.ElapsedMilliseconds}ms");
            return orderSn;
        }

        /// <summary>
        /// 订单生成器
        /// </summary>
        /// <returns></returns>
        private string OrderGenrator()
        {

            Random r = new Random();

            return DateTime.Now.ToString("yyyyMMdd HH:mm:ss fff") + r.Next(1000, 9999).ToString();
        }
    }
}