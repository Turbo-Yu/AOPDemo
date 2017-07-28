using NewAop;
using NewAop.AopProxy;
using NewAop.ParamAttribute;
using NewAop.RealSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPDemo
{
    [AopProxy(typeof(AopControlProxyFactory))]
    public class Exameplec: ContextBoundObject
    {
        private string name;
        public Exameplec(string a)
        {
            this.name = a;
        }

        [MethodAopSwitcher(1, "参数")]
        public void SayHello()
        {
            Console.WriteLine("目标方法已附加");
        }

        public void SayByeBye()
        {
            Console.WriteLine("目标方法未附加");
        }
    }
}
