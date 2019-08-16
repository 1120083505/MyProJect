using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Sys_AdminModel
    {
        #region 对象
        #region
        private string _Id;
        [DisplayName("")]
        public string Id
        {
            get { return this._Id; }
            set
            {
                this._Id = value;
            }
        }
        #endregion

        #region 登录名称
        private string _LoginName;
        [DisplayName("登录名称")]
        
        public string LoginName
        {
            get { return this._LoginName; }
            set
            {
                this._LoginName = value;
            }
        }
        #endregion

        #region 密码
        private string _LoginPwd;
        [DisplayName("密码")]
        public string LoginPwd
        {
            get { return this._LoginPwd; }
            set
            {
                this._LoginPwd = value;
            }
        }
        #endregion

        #region 真实姓名
        private string _RealName;
        [DisplayName("真实姓名")]
        public string RealName
        {
            get { return this._RealName; }
            set
            {
                this._RealName = value;
            }
        }
        #endregion

        #region 登陆状态
        private int _IsLogin;
        [DisplayName("登陆状态")]
        public int IsLogin
        {
            get { return this._IsLogin; }
            set
            {
                this._IsLogin = value;
            }
        }
        #endregion

        #region 角色名称
        private string _RoleId;
        [DisplayName("角色名称")]
        public string RoleId
        {
            get { return this._RoleId; }
            set
            {
                this._RoleId = value;
            }
        }
        #endregion

        #region Email
        private string _Email;
        [DisplayName("Email")]
        public string Email
        {
            get { return this._Email; }
            set
            {
                this._Email = value;
            }
        }
        #endregion

        #region 
        private DateTime _PubDate;
        [DisplayName("")]
        public DateTime PubDate
        {
            get { return this._PubDate; }
            set
            {
                this._PubDate = value;
            }
        }
        #endregion
        #endregion

        #region Col
        #endregion
    }
}
