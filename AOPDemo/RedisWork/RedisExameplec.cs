using NewAop.AopProxy;
using NewAop.ParamAttribute;
using NewAop.RealSubject;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPDemo.RedisWork
{
    [AopProxyRedis(typeof(AopControlProxyFactory))]
    public class RedisExameplec : ContextBoundObject
    {
        private RedisClient client;
        public object Get()
        {
            client = new RedisClient("127.0.0.1", 6379);
            var Get_studs = client.Get("StringListEntity");
            var a = BitConverter.ToString(Get_studs);

            client.Dispose();
            return Get_studs;
        }

        //public T A<T>(string json){return JsonConvert.DeserializeObject<T>(json);}

        [RedisAopSwitcher(Key = "StringListEntity", IsUnique = false, ReturnType = typeof(List<Student>))]
        public List<Student> Push(string uid)
        {
            List<Student> studs = new List<Student>();
            studs.Add(new Student { id = "1001", name = "李四", age = 17 });
            studs.Add(new Student { id = "1002", name = "張三", age = 17 });
            studs.Add(new Student { id = "1003", name = "王二", age = 17 });
            studs.Add(new Student { id = "1004", name = "宋柳", age = 17 });
            //client.Add<List<Student>>("StringListEntity", studs);
            //List<Student> Get_studs = client.Get<List<Student>>("StringListEntity");
            //foreach (var item in Get_studs)
            //{
            //    Console.WriteLine("数据类型为：List<Entity>.键:StringListEntity,值:id={0} name={1} age={2}", item.id, item.name, item.age);
            //}
            return studs;
        }


    }
}
