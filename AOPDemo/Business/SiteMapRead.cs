using AOPDemo.ConvertHelper;
using AOPDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.Business
{
    public class SiteMapRead
    {
        public static void GetContent()
        {
            var data = JsonHelper.DeserializeFromXml<SiteMapModel_Json>(@"D:\Projects\Redis\Demos\AOPDemo\AOPDemo\Resource\SiteMap.json");


        }
    }
}
