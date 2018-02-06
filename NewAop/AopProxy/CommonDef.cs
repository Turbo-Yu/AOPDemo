using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using NewAop.Model;
using NewAop.ParamAttribute;

namespace NewAop.AopProxy
{
    /// <summary>
    /// AOP操作符接口，提供前后处理函数
    /// 抽象主题角色(接口)
    /// </summary>
    public interface IAopOperator
    {
        /// <summary>
        /// 目标函数执行前的触发函数
        /// 如果返回值为False不再继续往下执行,直接返回
        /// </summary>
        /// <param name="requestMsg"></param>
        /// <returns></returns>
        TEntity PreProcess(IMessage requestMsg, RedisAopSwitcherAttribute attr) ;//where T : class;

        /// <summary>
        /// 目标函数执行后的触发函数
        /// </summary>
        /// <param name="requestMsg"></param>
        /// <param name="Respond"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        bool PostProcess(IMessage requestMsg, IMessage Respond, RedisAopSwitcherAttribute attr);
    }

    /// <summary>
    /// 用户创建特定的AOP代理的实例，Factory使Attribute独立于Aop代理类
    /// 
    /// </summary>
    public interface IAopProxyFactory
    {
        AopProxyBase CreateAopProxyInstance(MarshalByRefObject obj, Type type);
    }
}
