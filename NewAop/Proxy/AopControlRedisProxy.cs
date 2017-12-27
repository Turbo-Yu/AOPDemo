
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using NewAop.AopProxy;
using NewAop.Model;
using ServiceStack.Redis;

namespace NewAop.Proxy
{
    public class AopControlRedisProxy : AopProxyBase
    {
        public AopControlRedisProxy(MarshalByRefObject obj, Type type)
            : base(obj, type)
        {

        }

        public override TEntity PreProcess(IMessage requestMsg, string key, Type returnType)
        {
            using (var client = new RedisClient("127.0.0.1", 6379))
            {
                var data = client.Get<TEntity>(key);
                if (data == null)
                    return null;
                else
                {
                    return data;
                }
            }
        }

        public override bool PostProcess<T>(IMessage requestMsg, IMessage Respond, string key, T value)
        {
            try
            {
                using (var client = new RedisClient("127.0.0.1", 6379))
                {
                    var t = new TEntity() { Data = value };
                    client.Add<TEntity>(key, t);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
