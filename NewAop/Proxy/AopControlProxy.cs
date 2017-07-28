using NewAop.AopProxy;
using NewAop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewAop.Proxy
{
    /// <summary>
    /// 真实主题角色
    /// 这里继承AopProxyBase是为了
    /// 1、使用RealProxy；
    /// 2、真实主题应该依赖代理角色，不应该是代理角色依赖真实主题
    /// </summary>
    public class AopControlProxy: AopProxyBase
    {
        public AopControlProxy(MarshalByRefObject obj,Type type):base(obj,type)
        {

        }

        public override TEntity PreProcess(System.Runtime.Remoting.Messaging.IMessage requestMsg, string key, Type returnType)
        {
            Console.WriteLine("目标方法运行开始前");
            return null;
        }

        public override bool PostProcess<T>(System.Runtime.Remoting.Messaging.IMessage requestMsg, System.Runtime.Remoting.Messaging.IMessage Respond, string key, T value)
        {
            Console.WriteLine("目标方法运行结束后");
            return true;
        }
    }
}
