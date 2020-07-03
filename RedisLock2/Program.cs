using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisLock2.Skills;

namespace RedisLock2
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
