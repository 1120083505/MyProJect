using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Core
{
    /// <summary>
    /// 获取登录用户的相关信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public static string proName = "_ZrSoft";
        /// <summary>
        /// Cookie过期天数 默认为退出浏览器清除cookie
        /// </summary>
        public static int outDays = 0;
        #region 样式
        /// <summary>
        /// 样式
        /// </summary>
        public static string Theme
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("Theme" + proName);
            }
            set
            {

                CookieUtil.SetEncryptedCookie("Theme" + proName, value, 30);
            }
        }
        #endregion
        #region 管理员部分

        /// <summary>
        /// 管理员登录ID
        /// </summary>
        public static string AdminID
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("adminid" + proName);
            }
            set
            {

                CookieUtil.SetEncryptedCookie("adminid" + proName, value, outDays);
            }
        }

        /// <summary>
        /// 管理员登录名
        /// </summary>
        public static string AdminName
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("adminname" + proName);
            }
            set
            {
                CookieUtil.SetEncryptedCookie("adminname" + proName, value, outDays);
            }
        }
        /// <summary>
        /// 管理员真实姓名
        /// </summary>
        public static string RealName
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("RealName" + proName);
            }
            set
            {
                CookieUtil.SetEncryptedCookie("RealName" + proName, value, outDays);
            }
        }
        /// <summary>
        /// 管理员类型
        /// </summary>
        public static string AdminType
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("AdminType" + proName);
            }
            set
            {
                CookieUtil.SetEncryptedCookie("AdminType" + proName, value, outDays);
            }
        }
        /// <summary>
        /// 是否允许查看所有
        /// </summary>
        public static string IsAllowAll
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("IsAllowAll" + proName);
            }
            set
            {
                CookieUtil.SetEncryptedCookie("IsAllowAll" + proName, value, outDays);
            }
        }
        /// <summary>
        /// 管理员登录验证码
        /// </summary>
        public static string Admin_CheckCode
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("Admin_CheckCode");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("Admin_CheckCode", value);
            }
        }


        /// <summary>
        /// 管理员具有的角色ID
        /// </summary>
        public static string RoleID
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("RoleID_ZR");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("RoleID_ZR", value, outDays);
            }
        }

        #endregion

        #region 前台用户部分
        /// <summary>
        /// 用户ID
        /// </summary>
        public static string CusID
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("CusID");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("CusID", value);
            }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public static string discount
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("Discount");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("Discount", value);
            }
        }
        /// <summary>
        /// 用户Username
        /// </summary>
        public static string CusLoginName
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("CusLoginName");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("CusLoginName", value);
            }
        }
        #endregion

        /// <summary>
        /// 查询连接
        /// </summary>
        public static string ConStr
        {
            get
            {
                return CookieUtil.GetEncryptedCookieValue("sqllinkautocode");
            }
            set
            {
                CookieUtil.SetEncryptedCookie("sqllinkautocode", value, 10);
            }
        }
    }

}
