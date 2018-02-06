using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP_PostSharpDemo
{
    public class MyClass
    {
        [MyAspect]
        public void MyMehtod()
        {
            Console.WriteLine("Hello,AOP!");
        }
    }
}
