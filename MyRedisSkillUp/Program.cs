using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRedisSkillDown.FlowLimit;
using MyRedisSkillUp.MQ;

namespace MyRedisSkillUp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RedisMessageQueue redis = new RedisMessageQueue("localhost:6379"))
            {
                Console.WriteLine("秒杀上游消息");
                while (true)
                {
                    string message = redis.BdQueue("skills", TimeSpan.FromSeconds(60));


                    Console.WriteLine("********************************下游开始秒杀业务调用************************************\r\n");

                    SkillsDownStream skillsUpStream = new SkillsDownStream();
                    skillsUpStream.HandlerRequest(Convert.ToInt32(message));
                    Console.WriteLine("********************************下游秒杀业务调用完成************************************\r\n"); 
                }
            }
        }
    }
}
