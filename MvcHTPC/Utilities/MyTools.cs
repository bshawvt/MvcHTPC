using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Utilities
{
    public class MyTools
    {
        public static void Utilities2()
        {

        }
        public static string Encode64String(string str)
        {
            var b = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(b);
        }
    }
}