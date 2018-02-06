using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp
{
    [Serializable]
    public class MyAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("方法执行前");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("方法执行后");
        }
    }
}
