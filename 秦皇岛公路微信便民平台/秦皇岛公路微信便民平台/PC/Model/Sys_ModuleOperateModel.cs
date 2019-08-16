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
    public class Sys_ModuleOperateModel
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

        #region 
        private string _Name;
        [DisplayName("")]
        public string Name
        {
            get { return this._Name; }
            set
            {
                this._Name = value;
            }
        }
        #endregion

        #region 
        private string _KeyCode;
        [DisplayName("")]
        public string KeyCode
        {
            get { return this._KeyCode; }
            set
            {
                this._KeyCode = value;
            }
        }
        #endregion

        #region 
        private string _ModuleId;
        [DisplayName("")]
        public string ModuleId
        {
            get { return this._ModuleId; }
            set
            {
                this._ModuleId = value;
            }
        }
        #endregion

        #region 排序
        private int _Sort;
        [DisplayName("排序")]
        public int Sort
        {
            get { return this._Sort; }
            set
            {
                this._Sort = value;
            }
        }
        #endregion

        #region 
        private string _Icon;
        [DisplayName("")]
        public string Icon
        {
            get { return this._Icon; }
            set
            {
                this._Icon = value;
            }
        }
        #endregion

        #region 是否生成按钮
        private int _IsBtn;
        [DisplayName("是否生成按钮")]
        public int IsBtn
        {
            get { return this._IsBtn; }
            set
            {
                this._IsBtn = value;
            }
        }
        #endregion
    }
}
