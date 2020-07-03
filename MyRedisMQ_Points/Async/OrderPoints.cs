using System;
using System.Threading;

namespace MyRedisMQ_Points.Async
{
    public class OrderPoints
    {
        public void AddPoints(string orderSn)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"增加积分:{orderSn},成功");
        }
    }
}