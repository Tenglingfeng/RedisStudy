using StackExchange.Redis;
using System;
using System.Threading;

namespace RedisLock.Locks
{
    /// <summary>
    /// redis分布式锁
    /// 1:锁名
    /// 2:加锁操作
    /// 3:解锁操作
    /// 4:锁超时时间
    /// </summary>
    public class RedisLock
    {
        private ConnectionMultiplexer ConnectionMultiplexer = null;

        private IDatabase Database = null;

        public RedisLock()
        {
            ConnectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
            Database = ConnectionMultiplexer.GetDatabase(0);
        }

        /// <summary>
        /// 加锁
        /// </summary>
        public void Lock()
        {
            while (true)
            {
                bool flag = Database.LockTake("redisLock", Thread.CurrentThread.ManagedThreadId, TimeSpan.FromSeconds(10));
                if (flag)
                {
                    break;
                }
                // 线程休眠 
                Thread.Sleep(200);
            }

        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock()
        {
            while (true)
            {
               bool flag = Database.LockRelease("redisLock", Thread.CurrentThread.ManagedThreadId);
               if (flag)
               {
                   break;

               }
            }

            ConnectionMultiplexer.Dispose();
        }
    }
}