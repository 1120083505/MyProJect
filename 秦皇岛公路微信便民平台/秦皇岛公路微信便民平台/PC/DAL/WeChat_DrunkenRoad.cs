﻿using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;
namespace ZrSoft
{
    [Serializable]
    public partial class WeChat_DrunkenRoadCollection : ActiveList<WeChat_DrunkenRoad, WeChat_DrunkenRoadCollection>
    {
        public WeChat_DrunkenRoadCollection() { }
        public WeChat_DrunkenRoadCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WeChat_DrunkenRoad o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
    }
    [Serializable]
    public partial class WeChat_DrunkenRoad : ActiveRecord<WeChat_DrunkenRoad>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public WeChat_DrunkenRoad()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public WeChat_DrunkenRoad(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public WeChat_DrunkenRoad(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public WeChat_DrunkenRoad(string columnName, object columnValue)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByParam(columnName, columnValue);
        }
        protected static void SetSQLProps() { GetTableSchema(); }
        #endregion
        #region Schema and Query Accessor	 
        public static Query CreateQuery() { return new Query(Schema); }
        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                    SetSQLProps();
                return BaseSchema;
            }
        }
        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration 
                TableSchema.Table schema = new TableSchema.Table("WeChat_DrunkenRoad", TableType.Table, DataService.GetInstance("ZrCon"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns 

                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "Id";
                colvarId.DataType = DbType.String;
                colvarId.MaxLength = 50;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = true;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                colvarId.DefaultSetting = @"";
                colvarId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarId);


                TableSchema.TableColumn colvarRoadName = new TableSchema.TableColumn(schema);
                colvarRoadName.ColumnName = "RoadName";
                colvarRoadName.DataType = DbType.String;
                colvarRoadName.MaxLength = 200;
                colvarRoadName.AutoIncrement = false;
                colvarRoadName.IsNullable = true;
                colvarRoadName.IsPrimaryKey = false;
                colvarRoadName.IsForeignKey = false;
                colvarRoadName.IsReadOnly = false;
                colvarRoadName.DefaultSetting = @"";
                colvarRoadName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoadName);


                TableSchema.TableColumn colvarRoadNum = new TableSchema.TableColumn(schema);
                colvarRoadNum.ColumnName = "RoadNum";
                colvarRoadNum.DataType = DbType.Int32;
                colvarRoadNum.MaxLength = 0;
                colvarRoadNum.AutoIncrement = false;
                colvarRoadNum.IsNullable = true;
                colvarRoadNum.IsPrimaryKey = false;
                colvarRoadNum.IsForeignKey = false;
                colvarRoadNum.IsReadOnly = false;
                colvarRoadNum.DefaultSetting = @"";
                colvarRoadNum.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoadNum);


                TableSchema.TableColumn colvarRoadVotes = new TableSchema.TableColumn(schema);
                colvarRoadVotes.ColumnName = "RoadVotes";
                colvarRoadVotes.DataType = DbType.Int32;
                colvarRoadVotes.MaxLength = 0;
                colvarRoadVotes.AutoIncrement = false;
                colvarRoadVotes.IsNullable = true;
                colvarRoadVotes.IsPrimaryKey = false;
                colvarRoadVotes.IsForeignKey = false;
                colvarRoadVotes.IsReadOnly = false;
                colvarRoadVotes.DefaultSetting = @"";
                colvarRoadVotes.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoadVotes);


                TableSchema.TableColumn colvarRoadMemo = new TableSchema.TableColumn(schema);
                colvarRoadMemo.ColumnName = "RoadMemo";
                colvarRoadMemo.DataType = DbType.String;
                colvarRoadMemo.MaxLength = 500;
                colvarRoadMemo.AutoIncrement = false;
                colvarRoadMemo.IsNullable = true;
                colvarRoadMemo.IsPrimaryKey = false;
                colvarRoadMemo.IsForeignKey = false;
                colvarRoadMemo.IsReadOnly = false;
                colvarRoadMemo.DefaultSetting = @"";
                colvarRoadMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoadMemo);


                TableSchema.TableColumn colvarRoadState = new TableSchema.TableColumn(schema);
                colvarRoadState.ColumnName = "RoadState";
                colvarRoadState.DataType = DbType.Int32;
                colvarRoadState.MaxLength = 0;
                colvarRoadState.AutoIncrement = false;
                colvarRoadState.IsNullable = true;
                colvarRoadState.IsPrimaryKey = false;
                colvarRoadState.IsForeignKey = false;
                colvarRoadState.IsReadOnly = false;
                colvarRoadState.DefaultSetting = @"";
                colvarRoadState.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoadState);


                TableSchema.TableColumn colvarAdminId = new TableSchema.TableColumn(schema);
                colvarAdminId.ColumnName = "AdminId";
                colvarAdminId.DataType = DbType.String;
                colvarAdminId.MaxLength = 50;
                colvarAdminId.AutoIncrement = false;
                colvarAdminId.IsNullable = true;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                colvarAdminId.DefaultSetting = @"";
                colvarAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAdminId);


                TableSchema.TableColumn colvarPubdate = new TableSchema.TableColumn(schema);
                colvarPubdate.ColumnName = "Pubdate";
                colvarPubdate.DataType = DbType.DateTime;
                colvarPubdate.MaxLength = 0;
                colvarPubdate.AutoIncrement = false;
                colvarPubdate.IsNullable = true;
                colvarPubdate.IsPrimaryKey = false;
                colvarPubdate.IsForeignKey = false;
                colvarPubdate.IsReadOnly = false;
                colvarPubdate.DefaultSetting = @"";
                colvarPubdate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubdate);


                TableSchema.TableColumn colvarEditAdminId = new TableSchema.TableColumn(schema);
                colvarEditAdminId.ColumnName = "EditAdminId";
                colvarEditAdminId.DataType = DbType.String;
                colvarEditAdminId.MaxLength = 50;
                colvarEditAdminId.AutoIncrement = false;
                colvarEditAdminId.IsNullable = true;
                colvarEditAdminId.IsPrimaryKey = false;
                colvarEditAdminId.IsForeignKey = false;
                colvarEditAdminId.IsReadOnly = false;
                colvarEditAdminId.DefaultSetting = @"";
                colvarEditAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEditAdminId);


                TableSchema.TableColumn colvarEditPubDate = new TableSchema.TableColumn(schema);
                colvarEditPubDate.ColumnName = "EditPubDate";
                colvarEditPubDate.DataType = DbType.DateTime;
                colvarEditPubDate.MaxLength = 0;
                colvarEditPubDate.AutoIncrement = false;
                colvarEditPubDate.IsNullable = true;
                colvarEditPubDate.IsPrimaryKey = false;
                colvarEditPubDate.IsForeignKey = false;
                colvarEditPubDate.IsReadOnly = false;
                colvarEditPubDate.DefaultSetting = @"";
                colvarEditPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEditPubDate);


                TableSchema.TableColumn colvarExt1 = new TableSchema.TableColumn(schema);
                colvarExt1.ColumnName = "Ext1";
                colvarExt1.DataType = DbType.String;
                colvarExt1.MaxLength = 50;
                colvarExt1.AutoIncrement = false;
                colvarExt1.IsNullable = true;
                colvarExt1.IsPrimaryKey = false;
                colvarExt1.IsForeignKey = false;
                colvarExt1.IsReadOnly = false;
                colvarExt1.DefaultSetting = @"";
                colvarExt1.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt1);


                TableSchema.TableColumn colvarExt2 = new TableSchema.TableColumn(schema);
                colvarExt2.ColumnName = "Ext2";
                colvarExt2.DataType = DbType.String;
                colvarExt2.MaxLength = 500;
                colvarExt2.AutoIncrement = false;
                colvarExt2.IsNullable = true;
                colvarExt2.IsPrimaryKey = false;
                colvarExt2.IsForeignKey = false;
                colvarExt2.IsReadOnly = false;
                colvarExt2.DefaultSetting = @"";
                colvarExt2.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt2);


                TableSchema.TableColumn colvarExt3 = new TableSchema.TableColumn(schema);
                colvarExt3.ColumnName = "Ext3";
                colvarExt3.DataType = DbType.String;
                colvarExt3.MaxLength = 2000;
                colvarExt3.AutoIncrement = false;
                colvarExt3.IsNullable = true;
                colvarExt3.IsPrimaryKey = false;
                colvarExt3.IsForeignKey = false;
                colvarExt3.IsReadOnly = false;
                colvarExt3.DefaultSetting = @"";
                colvarExt3.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt3);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("WeChat_DrunkenRoad", schema);
            }
        }
        #endregion
        #region Props 
        [DisplayName("Id")]
        [XmlAttribute("Id")]
        [Bindable(true)]
        public string Id
        {
            get { return GetColumnValue<string>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }
        [DisplayName("公路名称")]
        [XmlAttribute("RoadName")]
        [Bindable(true)]
        public string RoadName
        {
            get { return GetColumnValue<string>(Columns.RoadName); }
            set { SetColumnValue(Columns.RoadName, value); }
        }
        [DisplayName("公路编号")]
        [XmlAttribute("RoadNum")]
        [Bindable(true)]
        public int? RoadNum
        {
            get { return GetColumnValue<int?>(Columns.RoadNum); }
            set { SetColumnValue(Columns.RoadNum, value); }
        }
        [DisplayName("公路得票数")]
        [XmlAttribute("RoadVotes")]
        [Bindable(true)]
        public int? RoadVotes
        {
            get { return GetColumnValue<int?>(Columns.RoadVotes); }
            set { SetColumnValue(Columns.RoadVotes, value); }
        }
        [DisplayName("公路简介")]
        [XmlAttribute("RoadMemo")]
        [Bindable(true)]
        public string RoadMemo
        {
            get { return GetColumnValue<string>(Columns.RoadMemo); }
            set { SetColumnValue(Columns.RoadMemo, value); }
        }
        [DisplayName("状态")]
        [XmlAttribute("RoadState")]
        [Bindable(true)]
        public int? RoadState
        {
            get { return GetColumnValue<int?>(Columns.RoadState); }
            set { SetColumnValue(Columns.RoadState, value); }
        }
        [DisplayName("录入人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("创建时间")]
        [XmlAttribute("Pubdate")]
        [Bindable(true)]
        public DateTime? Pubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.Pubdate); }
            set { SetColumnValue(Columns.Pubdate, value); }
        }
        [DisplayName("修改人")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [DisplayName("修改时间")]
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        [DisplayName("Ext1")]
        [XmlAttribute("Ext1")]
        [Bindable(true)]
        public string Ext1
        {
            get { return GetColumnValue<string>(Columns.Ext1); }
            set { SetColumnValue(Columns.Ext1, value); }
        }
        [DisplayName("Ext2")]
        [XmlAttribute("Ext2")]
        [Bindable(true)]
        public string Ext2
        {
            get { return GetColumnValue<string>(Columns.Ext2); }
            set { SetColumnValue(Columns.Ext2, value); }
        }
        [DisplayName("Ext3")]
        [XmlAttribute("Ext3")]
        [Bindable(true)]
        public string Ext3
        {
            get { return GetColumnValue<string>(Columns.Ext3); }
            set { SetColumnValue(Columns.Ext3, value); }
        }
        #endregion
        #region ObjectDataSource support 
        public static void Insert(string varId, string varRoadName, int? varRoadNum, int? varRoadVotes, string varRoadMemo, int? varRoadState, string varAdminId, DateTime? varPubdate, string varEditAdminId, DateTime? varEditPubDate, string varExt1, string varExt2, string varExt3)
        {
            WeChat_DrunkenRoad item = new WeChat_DrunkenRoad();
            item.Id = varId;
            item.RoadName = varRoadName;
            item.RoadNum = varRoadNum;
            item.RoadVotes = varRoadVotes;
            item.RoadMemo = varRoadMemo;
            item.RoadState = varRoadState;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varRoadName, int? varRoadNum, int? varRoadVotes, string varRoadMemo, int? varRoadState, string varAdminId, DateTime? varPubdate, string varEditAdminId, DateTime? varEditPubDate, string varExt1, string varExt2, string varExt3)
        {
            WeChat_DrunkenRoad item = new WeChat_DrunkenRoad();
            item.Id = varId;
            item.RoadName = varRoadName;
            item.RoadNum = varRoadNum;
            item.RoadVotes = varRoadVotes;
            item.RoadMemo = varRoadMemo;
            item.RoadState = varRoadState;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;

            item.IsNew = false;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        #endregion
        #region Typed Columns 
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        public static TableSchema.TableColumn RoadNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn RoadNumColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn RoadVotesColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn RoadMemoColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn RoadStateColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn PubdateColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[10]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[11]; }
        }
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[12]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string RoadName = @"RoadName";
            public static string RoadNum = @"RoadNum";
            public static string RoadVotes = @"RoadVotes";
            public static string RoadMemo = @"RoadMemo";
            public static string RoadState = @"RoadState";
            public static string AdminId = @"AdminId";
            public static string Pubdate = @"Pubdate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
            public static string Ext1 = @"Ext1";
            public static string Ext2 = @"Ext2";
            public static string Ext3 = @"Ext3";
        }
        #endregion
        #region Update PK Collections 
        #endregion
        #region Deep Save 
        #endregion
    }
}
