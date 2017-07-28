using NewAop.AopProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace NewAop.RealSubject
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AopProxyRedisAttribute : ProxyAttribute
    {
        private IAopProxyFactory proxyFactory = null;

        public AopProxyRedisAttribute(Type factoryType)
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
            var target = base.CreateInstance(serverType);//得到未初始化的实例(cotor未执行)

            object[] args = { target, serverType };

            //得到自定义的真实代理
            var rp = this.proxyFactory.CreateAopProxyInstance(target, serverType);

            return (MarshalByRefObject)rp.GetTransparentProxy();
        }
    }
}
