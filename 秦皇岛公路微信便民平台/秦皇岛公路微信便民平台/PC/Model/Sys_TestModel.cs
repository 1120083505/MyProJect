using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Model
{
    /// <summary>
    /// 测试
    /// </summary>
    public class Sys_TestModel
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

        #region 测试名称
        private string _Name;
        [DisplayName("测试名称")]
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
        private string _Title;
        [DisplayName("")]
        public string Title
        {
            get { return this._Title; }
            set
            {
                this._Title = value;
            }
        }
        #endregion

        #region cehsi test显示
        private string _test;
        [DisplayName("cehsi test显示")]
        public string test
        {
            get { return this._test; }
            set
            {
                this._test = value;
            }
        }
        #endregion

        #region 价格
        private decimal _price;
        [DisplayName("价格")]
        public decimal price
        {
            get { return this._price; }
            set
            {
                this._price = value;
            }
        }
        #endregion

        #region 数量
        private int _count;
        [DisplayName("数量")]
        public int count
        {
            get { return this._count; }
            set
            {
                this._count = value;
            }
        }
        #endregion

        #region 发布时间
        private DateTime _PubDate;
        [DisplayName("发布时间")]
        public DateTime PubDate
        {
            get { return this._PubDate; }
            set
            {
                this._PubDate = value;
            }
        }
        #endregion

        #region 发布者
        private string _AdminId;
        [DisplayName("发布者")]
        public string AdminId
        {
            get { return this._AdminId; }
            set
            {
                this._AdminId = value;
            }
        }
        #endregion

        #region 其他内容
        private string _OtherMemo;
        [DisplayName("其他内容")]
        public string OtherMemo
        {
            get { return this._OtherMemo; }
            set
            {
                this._OtherMemo = value;
            }
        }
        #endregion
    }
}
