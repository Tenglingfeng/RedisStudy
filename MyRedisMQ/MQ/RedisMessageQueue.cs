using ServiceStack.Redis;
using System;
using System.Linq;
using System.Text;

namespace MyRedisMQ.MQ
{
    public class RedisMessageQueue :IDisposable
    {

        public RedisClient RedisClient { get; set; }

        public RedisMessageQueue(string redisHost)
        {
            RedisClient =  new RedisClient(redisHost) ;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="qKey">入队Key</param>
        /// <param name="qMessage">入队消息</param>
        /// <returns></returns>
        public long EnQueue(string qKey, string qMessage)
        {
            //编码字符串
            var b = Encoding.UTF8.GetBytes(qMessage);

            //入队
            return RedisClient.LPush(qKey, b);
        }

        /// <summary>
        /// 出队 (非阻塞) (拉模型)
        /// </summary>
        /// <param name="qKey">出队key</param>
        /// <returns></returns>
        public string DeQueue(string qKey)
        {
            //出队
            byte[] b=  RedisClient.RPop(qKey);
            string msg = null;
            if (!b.Any())
            {
                Console.WriteLine("队列中消息为空");
            }
            else
            {
                msg = Encoding.UTF8.GetString(b);
            }

            return msg;

        }

        /// <summary>
        /// 出队(阻塞) (推模型)
        /// </summary>
        /// <returns></returns>
        public string BdQueue(string qKey,TimeSpan? timeSpan)
        {
            return RedisClient.BlockingPopItemFromList(qKey, timeSpan);
        }

        /// <summary>
        /// 获取队列中的消息数量
        /// </summary>
        /// <returns></returns>
        public long GetQueueCount(string qKey)
        {
            return RedisClient.GetListCount(qKey);
        }

        /// <summary>
        /// 关闭Redis
        /// </summary>

        public void Dispose()
        {
            
            RedisClient.Dispose();
        }
    }
}