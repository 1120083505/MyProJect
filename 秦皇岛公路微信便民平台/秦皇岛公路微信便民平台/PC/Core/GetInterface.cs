using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
   public class GetInterface
    {
        public static string jieko(string ActionName, string Parameter)
        {

            return Core.Utils.HttpPost("http://139.196.112.1:10020/appport/" + ActionName, Parameter);

        }
    }
}
