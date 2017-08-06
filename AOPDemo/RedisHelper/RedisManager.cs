using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.RedisHelper
{
    public class RedisManager
    {
        private static RedisConfigInfo redisConfigInfo = RedisConfigInfo.GetConfig();

        private static PooledRedisClientManager prcm;

        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            string[] writeServerList = SplitString(redisConfigInfo.WriterServerList, ",");
            string[] readServerList = SplitString(redisConfigInfo.ReadServerList, ",");
            prcm = new PooledRedisClientManager(readServerList, writeServerList, new RedisClientManagerConfig
            {
                MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                AutoStart = redisConfigInfo.AutoStart
            });
        }

        private static string[] SplitString(string str, string split)
        {
            return str.Split(split.ToArray());
        }

        public static IRedisClient GetClient()
        {
            if (prcm == null)
                CreateManager();
            return prcm.GetClient();
        }
    }
}
