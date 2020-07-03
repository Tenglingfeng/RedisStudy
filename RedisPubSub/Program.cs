using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPubSub
{
    /// <summary>
    /// 订阅与发布后台
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1:开发环境
            string dev = "dev";

            //2:测试环境
            string test = "test";

            //3:生产环境
            string pro = "pro";


            //后台发布更新环境命令
            Config.Config config = new Config.Config();
            config.UpdateDatabase(test);
            Console.ReadKey();
        }
    }
}
