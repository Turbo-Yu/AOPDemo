using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace AOPDemo.RedisHelper
{
    public class RedisConfigInfo : IConfigurationSectionHandler
    {
        internal static RedisConfigInfo GetConfig()
        {
            RedisConfigInfo section = (RedisConfigInfo)ConfigurationManager.GetSection("RedisConfig");
            return section;
        }

        public string WriterServerList { get; set; }

        public string ReadServerList { get; set; }

        public int MaxWritePoolSize { get; set; }

        public int MaxReadPoolSize { get; set; }

        public bool AutoStart { get; set; }

        public int LocalCacheTime { get; set; }

        public bool RecordeLog { get; set; }

        public object Create(object parent, object configContext, XmlNode section)
        {
            RedisConfigInfo para = new RedisConfigInfo();

            foreach (XmlNode xn in section.ChildNodes)
            {
                switch (xn.Name)
                {
                    case "WriterServerList":
                        para.WriterServerList = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "ReadServerList":
                        para.ReadServerList = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "MaxWritePoolSize":
                        para.MaxWritePoolSize = int.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                    case "MaxReadPoolSize":
                        para.MaxReadPoolSize = int.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                    case "AutoStart":
                        para.AutoStart = bool.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                    case "LocalCacheTime":
                        para.LocalCacheTime = int.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                    case "RecordeLog":
                        para.RecordeLog = bool.Parse(xn.SelectSingleNode("@attribute").InnerText);
                        break;
                }
            }

            return para;
        }
    }
}
