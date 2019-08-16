using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    /// <summary>
    ///  
    /// </summary>
    public class Sys_PowerModel
    {
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

        #region 角色
        private string _RoleId;
        [DisplayName("角色")]
        public string RoleId
        {
            get { return this._RoleId; }
            set
            {
                this._RoleId = value;
            }
        }
        #endregion

        #region 操作权限
        private string _ModuleOperateId;
        [DisplayName("操作权限")]
        public string ModuleOperateId
        {
            get { return this._ModuleOperateId; }
            set
            {
                this._ModuleOperateId = value;
            }
        }
        #endregion
    }
}
