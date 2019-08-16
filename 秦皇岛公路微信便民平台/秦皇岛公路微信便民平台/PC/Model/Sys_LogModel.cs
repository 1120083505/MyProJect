using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class Sys_LogModel
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
        private string _ModuleName;
        [DisplayName("模块名称")]
        public string ModuleName
        {
            get { return this._ModuleName; }
            set
            {
                this._ModuleName = value;
            }
        }
        #endregion

        #region 操作名称
        private string _OperateName;
        [DisplayName("操作名称")]
        public string OperateName
        {
            get { return this._OperateName; }
            set
            {
                this._OperateName = value;
            }
        }
        #endregion

        #region 操作说明
        private string _OperateMemo;
        [DisplayName("操作说明")]
        public string OperateMemo
        {
            get { return this._OperateMemo; }
            set
            {
                this._OperateMemo = value;
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

        #region 操作人
        private string _AdminId;
        [DisplayName("操作人")]
        public string AdminId
        {
            get { return this._AdminId; }
            set
            {
                this._AdminId = value;
            }
        }
        #endregion

        #region IP
        private string _IP;
        [DisplayName("IP")]
        public string IP
        {
            get { return this._IP; }
            set
            {
                this._IP = value;
            }
        }
        #endregion
    }
}
