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
    public class Sys_RoleModel
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

        #region 角色名称
        private string _Name;
        [DisplayName("角色名称")]
        public string Name
        {
            get { return this._Name; }
            set
            {
                this._Name = value;
            }
        }
        #endregion

        #region 备注
        private string _Memo;
        [DisplayName("备注")]
        public string Memo
        {
            get { return this._Memo; }
            set
            {
                this._Memo = value;
            }
        }
        #endregion

        #region 操作日期
        private DateTime _PubDate;
        [DisplayName("操作日期")]
        public DateTime PubDate
        {
            get { return this._PubDate; }
            set
            {
                this._PubDate = value;
            }
        }
        #endregion
    }
}
