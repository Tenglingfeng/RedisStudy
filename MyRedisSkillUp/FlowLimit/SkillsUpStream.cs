using System;
using MyRedisSkillUp.MQ;

namespace MyRedisSkillUp.FlowLimit
{
    public class SkillsUpStream
    {
        public void CreateSkillOrder(int requestCount)
        {
            // 1 :创建秒杀订单
            Console.WriteLine($"秒杀的数量是:{requestCount}");

            ////1.1: 系统宕机
            //if (HandlerRequestCount<requestCount)
            //{
            //    throw new Exception($"目前的请求数:{requestCount},最大能够请求数:{HandlerRequestCount}");
            //}


            //如何使用Redis优化:? 
            using (RedisMessageQueue redis = new RedisMessageQueue("localhost:6379"))
            {
                //1.1:循环写入队列
                for (int i = 0; i < requestCount; i++)
                {
                    long cont = redis.GetQueueCount("skills");
                    if (cont>HandlerRequestCount)
                    {
                        Console.WriteLine("系统繁忙,请稍候再试");
                    }
                    else
                    {
                        redis.EnQueue("skills", i.ToString());

                    }

                }
                
            }



        }

        public int HandlerRequestCount { get; set; } = 1000;
    }
}
