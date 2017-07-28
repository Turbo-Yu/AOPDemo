using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Activation;
using System.Reflection;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NewAop.Model;
using NewAop.ParamAttribute;

namespace NewAop.AopProxy
{
    /// <summary>
    /// 代理角色
    /// </summary>
    public abstract class AopProxyBase : RealProxy, IAopOperator
    {
        private readonly MarshalByRefObject target;//默认透明代理

        public abstract TEntity PreProcess(IMessage requestMsg, string key, Type returnType);// where T : class;

        public abstract bool PostProcess<T>(IMessage requestMsg, IMessage Respond, string key, T value) where T : class;

        public AopProxyBase(MarshalByRefObject obj, Type type)
            : base(type)
        {
            this.target = obj;
        }

        public override IMessage Invoke(IMessage msg)
        {
            string key = "";
            bool uniq = false;
            Type t = null;
            Func<object,object> func = x => null;
            TEntity data = null;//预执行后要继续执行

            var call = msg as IMethodCallMessage;

            //var ty = call.MethodBase.ReflectedType;

            foreach (Attribute attr in call.MethodBase.GetCustomAttributes(false))
            {
                var methodAopAttr = attr as RedisAopSwitcherAttribute;
                if (methodAopAttr != null)
                {
                    key = methodAopAttr.Key;
                    uniq = methodAopAttr.IsUnique;
                    t = methodAopAttr.ReturnType;
                    func = methodAopAttr.Get;
                    break;
                }
            }


            if (!string.IsNullOrEmpty(key))
            {
                data = this.PreProcess(msg, key, t);//执行方法之前的操作
                var ba = func(data.Data);
               //var b = Convert.ChangeType(JsonConvert.DeserializeObject(data.Data.ToString()), t);
                //t.ReflectedType.Assembly.CreateInstance(t.FullName);
            }

            //如果触发的是构造函数，此时的target还未构建
            var cotor = call as IConstructionCallMessage;
            if (cotor != null)
            {
                //获取最底层的默认真实代理
                RealProxy default_proxy = RemotingServices.GetRealProxy(this.target);

                default_proxy.InitializeServerObject(cotor);
                MarshalByRefObject tp = (MarshalByRefObject)this.GetTransparentProxy();

                return EnterpriseServicesHelper.CreateConstructionReturnMessage(cotor, tp);
            }

            if (data != null)
            {
                //如果不想运行目标方法可执行该代码，如果直接返回return null会导致异常
                IMethodCallMessage callMsg = msg as IMethodCallMessage;
                var d = JsonConvert.DeserializeObject(data.Data.ToString());
                return new ReturnMessage(d, callMsg.Args, callMsg.ArgCount, null, callMsg);
            }
            else
            {
                //执行目标代码
                IMethodMessage result_msg;
                result_msg = RemotingServices.ExecuteMessage(this.target, call);

                var value = (result_msg as ReturnMessage).ReturnValue;
                //执行结束代码
                if (!string.IsNullOrEmpty(key))
                    this.PostProcess(msg, result_msg, key, value);
                return result_msg;
            }

        }
    }
}
