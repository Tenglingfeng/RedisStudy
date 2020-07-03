using System.Threading;

namespace RedisLock2.Skills
{
    /// <summary>
    /// 客户端对象
    /// </summary>
    public class Client
    {

        /// <summary>
        ///秒杀方法
        /// </summary>
        /// <param name="threadCount"></param>
        public static void Skills(int threadCount)
        {
            //1:商品秒杀服务
            ProductionSkill production = new ProductionSkill();
            

            //2:创建20个请求来秒杀
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() => { production.SkillProduct(); });
                thread.Start();
            }
            
        }
    }
}