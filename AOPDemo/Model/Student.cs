using NewAop.AopProxy;
using NewAop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPDemo
{
    public class Student:TEntity
    {
        public string id { get; set; }

        public string name { get; set; }

        public int age { get; set; }
    }


}
