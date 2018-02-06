using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewAop.ParamAttribute
{
    public class AopSwitcherAttribute:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RedisAopSwitcherAttribute : AopSwitcherAttribute
    {
        
        public RedisAopSwitcherAttribute()
        {

        }

        /// <summary>
        /// Redis的键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 是否使用唯一标识
        /// 对于键增加跟多的唯一标识
        /// </summary>
        public bool IsUnique { get; set; }

        public Type ReturnType { get; set; }

        //public ConvertDelegate<T> ConvertFunc<T>{get;set;}

        //public ConvertDelegate ConvertFunc;

        //public ConvertDelegate<T> func<T> { get; set; }

        //ConvertFunc += get<string>("");

        public Func<object,object> Get { get; set; }

        public object Value { get; set; }

    }

    
}
