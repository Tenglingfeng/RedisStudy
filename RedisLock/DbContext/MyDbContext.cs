using RedisLock.Model;
using System.Data.Entity;

namespace RedisLock.DbContext
{
    public class MyDbContext :System.Data.Entity.DbContext
    {
        public MyDbContext() : base("data source=.;initial catalog=RedisTest;Integrated Security=True;")
        {
        }

        public DbSet<Stocks>  Stocks{ get; set; }
    }
}