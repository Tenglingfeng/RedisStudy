using System;
using System.Linq;
using System.Threading;
using RedisLock2.DbContext;
using RedisLock2.Model;

namespace RedisLock2.Skills
{
    public class ProductionSkill
    {
        public void SkillProduct()
        {
            Locks.RedisLock redis = new Locks.RedisLock();
            redis.Lock();
            var stocks = GetProductionStocks();
                if (stocks.Count.Value == 0)
                {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:不好意思 商品已被抢光,商品编号:{stocks.Count}");
                redis.UnLock();
                return;
                }
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:恭喜你 抢到了,商品编号:{stocks.Count}");
            subtracProduction(stocks);
            redis.UnLock();
        }

        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <returns></returns>
        private Stocks GetProductionStocks()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                Stocks stocks = dbContext.Stocks.FirstOrDefault(x => x.Id == 1);
                return stocks;
            }            
        }

        private void subtracProduction(Stocks stocks)
        {

            using (MyDbContext dbContext = new MyDbContext())
            {
                Stocks updateStocks = dbContext.Stocks.FirstOrDefault(x => x.Id == stocks.Id);
                if (updateStocks != null) updateStocks.Count = stocks.Count - 1;
                dbContext.SaveChanges();
            }
        }
    }
}