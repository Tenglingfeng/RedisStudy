using RedisLock.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisLock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"开始秒杀");
            Client.Skills(20);
            Console.ReadKey();
        }
    }
}
