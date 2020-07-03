using System;
using System.Threading;

namespace MyRedisSkillDown.FlowLimit
{
    public class SkillsDownStream
    {


        public void HandlerRequest(int requestCount)
        {
            Thread.Sleep(10);

            Console.WriteLine($"秒杀订单创建成功\r\n");

            Console.WriteLine($"秒杀订单库存扣减成功\r\n");

            Console.WriteLine($"用户余额扣减成功\r\n");

            Console.WriteLine($"处理的请求数量:{requestCount}");
        }
    }
}