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
    public class Sys_ModuleModel
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

        #region 模块名称
        private string _Name;
        [DisplayName("模块名称")]
        public string Name
        {
            get { return this._Name; }
            set
            {
                this._Name = value;
            }
        }
        #endregion

        #region 英文名称
        private string _EnName;
        [DisplayName("英文名称")]
        public string EnName
        {
            get { return this._EnName; }
            set
            {
                this._EnName = value;
            }
        }
        #endregion

        #region 父级菜单ID
        private string _ParentId;
        [DisplayName("父级菜单ID")]
        public string ParentId
        {
            get { return this._ParentId; }
            set
            {
                this._ParentId = value;
            }
        }
        #endregion

        #region 链接
        private string _Url;
        [DisplayName("链接")]
        public string Url
        {
            get { return this._Url; }
            set
            {
                this._Url = value;
            }
        }
        #endregion

        #region 图标样式
        private string _Icon;
        [DisplayName("图标样式")]
        public string Icon
        {
            get { return this._Icon; }
            set
            {
                this._Icon = value;
            }
        }
        #endregion

        #region 是否为最后
        private int _IsLast;
        [DisplayName("是否为最后")]
        public int IsLast
        {
            get { return this._IsLast; }
            set
            {
                this._IsLast = value;
            }
        }
        #endregion

        #region 是否启用
        private int _Enable;
        [DisplayName("是否启用")]
        public int Enable
        {
            get { return this._Enable; }
            set
            {
                this._Enable = value;
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

        #region 显示
        private int _IsShow;
        [DisplayName("显示")]
        public int IsShow
        {
            get { return this._IsShow; }
            set
            {
                this._IsShow = value;
            }
        }
        #endregion

        #region 管理员ID
        private string _AdminId;
        [DisplayName("管理员ID")]
        public string AdminId
        {
            get { return this._AdminId; }
            set
            {
                this._AdminId = value;
            }
        }
        #endregion

        #region 操作时间
        private DateTime _PubDate;
        [DisplayName("操作时间")]
        public DateTime PubDate
        {
            get { return this._PubDate; }
            set
            {
                this._PubDate = value;
            }
        }
        #endregion

        #region 说明
        private string _Memo;
        [DisplayName("说明")]
        public string Memo
        {
            get { return this._Memo; }
            set
            {
                this._Memo = value;
            }
        }
        #endregion
    }
}
