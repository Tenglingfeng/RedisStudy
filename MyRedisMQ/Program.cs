using MyRedisMQ.Async;
using MyRedisMQ.FlowLimit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedisMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********RedisMQ*******  \r\n  ");

            ////异步处理
            //Order order = new Order();
            //order.CreateOrder();

            //流量削峰
            SkillsUpStream skillsDownStream = new SkillsUpStream();
            skillsDownStream.CreateSkillOrder(2000);

            Console.ReadKey();
        }
    }
}
