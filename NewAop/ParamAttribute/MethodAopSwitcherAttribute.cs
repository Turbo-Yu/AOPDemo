using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAop.ParamAttribute
{
    /// <summary>
    /// 处理特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class MethodAopSwitcherAttribute : Attribute
    {
        private int useAspect = 0;
        private string userlog = "";

        public MethodAopSwitcherAttribute(int useAop, string log)
        {
            this.useAspect = useAop;
            this.userlog = log;
        }

        public int UseAspect
        {
            get
            {
                return this.useAspect;
            }
        }

        public string UserLog
        {
            get
            {
                return this.userlog;
            }
        }
    }
}
