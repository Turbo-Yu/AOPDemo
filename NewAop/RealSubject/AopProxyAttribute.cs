using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using NewAop.AopProxy;

namespace NewAop.RealSubject
{
    /// <summary>
    /// AOP代理特性，如果一个类想实现具体的AOP，只要实现AopProxyBase和IAopProxyFactory,然后加上该特性即可
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AopProxyAttribute:ProxyAttribute
    {
        private IAopProxyFactory proxyFactory = null;

        public AopProxyAttribute(Type factoryType)
        {
            this.proxyFactory = (IAopProxyFactory)Activator.CreateInstance(factoryType);
        }

        //创建实例

        /// <summary>
        /// 获得目标对象的自定义透明代理
        /// </summary>
        /// <param name="serverType"></param>
        /// <returns></returns>
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            //未初始化的实例的默认透明代理
            MarshalByRefObject target = base.CreateInstance(serverType);//得到未初始化的实例(cotor未执行)

            object[] args = { target, serverType };

            //得到自定义的真实代理
            AopProxyBase rp = this.proxyFactory.CreateAopProxyInstance(target, serverType);

            return (MarshalByRefObject)rp.GetTransparentProxy();
        }
    }
}
