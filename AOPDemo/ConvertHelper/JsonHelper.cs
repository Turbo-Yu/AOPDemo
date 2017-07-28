using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.ConvertHelper
{
    public class JsonHelper
    {
        public static T DeserializeObject<T>(string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj.ToString());
        }

        /// <summary>
        /// 从某一JSON文件反序列化到某一类型
        /// </summary>
        /// <param name="filePath">待反序列化的XML文件名称</param>
        /// <param name="type">反序列化出的</param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (StreamReader reader = new StreamReader(fs, Encoding.GetEncoding("utf-8")))
                    {
                        var data = reader.ReadToEnd();
                        var xs = DeserializeObject<T>(data);
                        return xs;
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
