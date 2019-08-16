using System;
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
    public partial class WeChat_HighwayDynamicCollection : ActiveList<WeChat_HighwayDynamic, WeChat_HighwayDynamicCollection>
    {
        public WeChat_HighwayDynamicCollection() { }
        public WeChat_HighwayDynamicCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WeChat_HighwayDynamic o = this[i];
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
    public partial class WeChat_HighwayDynamic : ActiveRecord<WeChat_HighwayDynamic>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public WeChat_HighwayDynamic()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public WeChat_HighwayDynamic(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public WeChat_HighwayDynamic(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public WeChat_HighwayDynamic(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("WeChat_HighwayDynamic", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 200;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = true;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                colvarTitle.DefaultSetting = @"";
                colvarTitle.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTitle);


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


                TableSchema.TableColumn colvarConetent = new TableSchema.TableColumn(schema);
                colvarConetent.ColumnName = "Conetent";
                colvarConetent.DataType = DbType.String;
                colvarConetent.MaxLength = 0;
                colvarConetent.AutoIncrement = false;
                colvarConetent.IsNullable = true;
                colvarConetent.IsPrimaryKey = false;
                colvarConetent.IsForeignKey = false;
                colvarConetent.IsReadOnly = false;
                colvarConetent.DefaultSetting = @"";
                colvarConetent.ForeignKeyTableName = "";
                schema.Columns.Add(colvarConetent);


                TableSchema.TableColumn colvarPubDate = new TableSchema.TableColumn(schema);
                colvarPubDate.ColumnName = "PubDate";
                colvarPubDate.DataType = DbType.DateTime;
                colvarPubDate.MaxLength = 0;
                colvarPubDate.AutoIncrement = false;
                colvarPubDate.IsNullable = true;
                colvarPubDate.IsPrimaryKey = false;
                colvarPubDate.IsForeignKey = false;
                colvarPubDate.IsReadOnly = false;
                colvarPubDate.DefaultSetting = @"";
                colvarPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubDate);


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


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 0;
                colvarMemo.AutoIncrement = false;
                colvarMemo.IsNullable = true;
                colvarMemo.IsPrimaryKey = false;
                colvarMemo.IsForeignKey = false;
                colvarMemo.IsReadOnly = false;
                colvarMemo.DefaultSetting = @"";
                colvarMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMemo);


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
                DataService.Providers["ZrCon"].AddSchema("WeChat_HighwayDynamic", schema);
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
        [DisplayName("标题")]
        [XmlAttribute("Title")]
        [Bindable(true)]
        public string Title
        {
            get { return GetColumnValue<string>(Columns.Title); }
            set { SetColumnValue(Columns.Title, value); }
        }
        [DisplayName("录入人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("内容")]
        [XmlAttribute("Conetent")]
        [Bindable(true)]
        public string Conetent
        {
            get { return GetColumnValue<string>(Columns.Conetent); }
            set { SetColumnValue(Columns.Conetent, value); }
        }
        [DisplayName("录入时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime? PubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
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
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
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
        public static void Insert(string varId, string varTitle, string varAdminId, string varConetent, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate, string varMemo, string varExt1, string varExt2, string varExt3)
        {
            WeChat_HighwayDynamic item = new WeChat_HighwayDynamic();
            item.Id = varId;
            item.Title = varTitle;
            item.AdminId = varAdminId;
            item.Conetent = varConetent;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            item.Memo = varMemo;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varTitle, string varAdminId, string varConetent, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate, string varMemo, string varExt1, string varExt2, string varExt3)
        {
            WeChat_HighwayDynamic item = new WeChat_HighwayDynamic();
            item.Id = varId;
            item.Title = varTitle;
            item.AdminId = varAdminId;
            item.Conetent = varConetent;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            item.Memo = varMemo;
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
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn ConetentColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[10]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Title = @"Title";
            public static string AdminId = @"AdminId";
            public static string Conetent = @"Conetent";
            public static string PubDate = @"PubDate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
            public static string Memo = @"Memo";
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
