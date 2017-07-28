using NewAop.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAop.AopProxy
{
    public class AopControlProxyFactory : IAopProxyFactory
    {

        public AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type)
        {
            //return new AopControlProxy(obj, type);
            return new AopControlRedisProxy(obj, type);
        }
    }
}
