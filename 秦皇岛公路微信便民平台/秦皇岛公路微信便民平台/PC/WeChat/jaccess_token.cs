using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChat_
{
    public class jaccess_token
    {
       /// <summary>
        /// access_token
       /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// expires_in
        /// </summary>
        public string expires_in { get; set; }

        /// <summary>
        ///errcode 
        /// </summary>
        public string errcode { get; set; }

        /// <summary>
        ///errmsg 
        /// </summary>
        public string errmsg { get; set; }
        
    }
}
