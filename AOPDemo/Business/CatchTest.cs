using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo
{
    public class CatchTest
    {
        public static string TryCatchTest()
        {
            string str = "1\r\n";
            try
            {
                str += "2\r\n";
                throw new NotImplementedException();
            }
            catch
            {
                str += "3\r\n";
                try
                {
                    str += "4\r\n";
                    throw new NotImplementedException();
                }
                catch
                {
                    str += "5\r\n";
                }
                str += "6\r\n";
            }
            str += "7\r\n";
            return str += "8\r\n";
        }
    }
}
