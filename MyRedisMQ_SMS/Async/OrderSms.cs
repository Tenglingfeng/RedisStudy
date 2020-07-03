using System;
using System.Threading;

namespace MyRedisMQ_SMS.Async
{
    public class OrderSms
    {
        public  void SendSms(string orderSn)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"发送短信:{orderSn},成功");
        }
    }
}