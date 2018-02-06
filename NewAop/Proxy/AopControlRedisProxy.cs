
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using NewAop.AopProxy;
using NewAop.Model;
using ServiceStack.Redis;
using NewAop.ParamAttribute;
using Newtonsoft.Json;

namespace NewAop.Proxy
{
    public class AopControlRedisProxy : AopProxyBase
    {
        public AopControlRedisProxy(MarshalByRefObject obj, Type type)
            : base(obj, type)
        {

        }

        public override TEntity PreProcess(IMessage requestMsg, RedisAopSwitcherAttribute attr)
        {
            using (var client = new RedisClient("127.0.0.1", 6379))
            {
                var data = client.Get<string>(attr.Key);
                if (data == null)
                    return null;
                else
                {
                    return new TEntity { Data = data };
                }
            }
        }

        public override bool PostProcess(IMessage requestMsg, IMessage respond, RedisAopSwitcherAttribute attr)
        {
            try
            {
                using (var client = new RedisClient("127.0.0.1", 6379))
                {
                    //var t = new TEntity() { Data = value };
                    client.Add(attr.Key, JsonConvert.SerializeObject(attr.Value));
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
