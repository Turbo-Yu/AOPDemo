using AOPDemo.Business;
using AOPDemo.ConvertHelper;
using AOPDemo.RedisHelper;
using NewAop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var epc = new RedisExameplec();
            //var data = epc.Push("001");
            //var data = epc.Get();

            //var str = CatchTest.TryCatchTest();
            //Console.WriteLine(str);
            //XMLHelper.ConvertXmlSiteMap();
            //SiteMapRead.GetContent();
            RedisConfigInfo.GetConfig();
            Console.Read();
        }

        
    }
}
