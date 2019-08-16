using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Web;

namespace Core
{
    public class lang
    {

        /// <summary>
        /// 当前语言版本
        /// </summary>
        public static string CurrentLang;
        public static CultureInfo cultureInfo;

    }
    public class langHelper
    {
        ResourceManager rs;
        public langHelper()
        {
            var path = HttpContext.Current.Server.MapPath("~/bin/Resource.dll");
            Assembly assembly = Assembly.LoadFile(path);
            rs = new ResourceManager("Resource.lang", assembly);
        }
        public string GetLangString(string Name)
        {
            try
            {
                return rs.GetString(Name, Core.lang.cultureInfo);
            }
            catch
            {
                return "unfind";
            }
        }
    }
}
