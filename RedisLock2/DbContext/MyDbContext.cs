using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using RedisLock2.Model;

namespace RedisLock2.DbContext
{
    public class MyDbContext :System.Data.Entity.DbContext
    {
        public MyDbContext() : base("data source=.;initial catalog=RedisTest;Integrated Security=True;")
        {
        }

        public DbSet<Stocks>  Stocks{ get; set; }
    }
}