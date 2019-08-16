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
    public partial class App_VersionCollection : ActiveList<App_Version, App_VersionCollection>
    {
        public App_VersionCollection() { }
        public App_VersionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                App_Version o = this[i];
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
    public partial class App_Version : ActiveRecord<App_Version>, IActiveRecord
    {
        #region .ctors and Default Settings
        public App_Version()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public App_Version(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public App_Version(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public App_Version(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("App_Version", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
                colvarCode.ColumnName = "Code";
                colvarCode.DataType = DbType.String;
                colvarCode.MaxLength = 50;
                colvarCode.AutoIncrement = false;
                colvarCode.IsNullable = false;
                colvarCode.IsPrimaryKey = false;
                colvarCode.IsForeignKey = false;
                colvarCode.IsReadOnly = false;
                colvarCode.DefaultSetting = @"";
                colvarCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCode);


                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.String;
                colvarUrl.MaxLength = 500;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = false;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                colvarUrl.DefaultSetting = @"";
                colvarUrl.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUrl);


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 0;
                colvarMemo.AutoIncrement = false;
                colvarMemo.IsNullable = false;
                colvarMemo.IsPrimaryKey = false;
                colvarMemo.IsForeignKey = false;
                colvarMemo.IsReadOnly = false;
                colvarMemo.DefaultSetting = @"";
                colvarMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMemo);


                TableSchema.TableColumn colvarPubDate = new TableSchema.TableColumn(schema);
                colvarPubDate.ColumnName = "PubDate";
                colvarPubDate.DataType = DbType.DateTime;
                colvarPubDate.MaxLength = 0;
                colvarPubDate.AutoIncrement = false;
                colvarPubDate.IsNullable = false;
                colvarPubDate.IsPrimaryKey = false;
                colvarPubDate.IsForeignKey = false;
                colvarPubDate.IsReadOnly = false;
                colvarPubDate.DefaultSetting = @"";
                colvarPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubDate);


                TableSchema.TableColumn colvarAdminId = new TableSchema.TableColumn(schema);
                colvarAdminId.ColumnName = "AdminId";
                colvarAdminId.DataType = DbType.String;
                colvarAdminId.MaxLength = 50;
                colvarAdminId.AutoIncrement = false;
                colvarAdminId.IsNullable = false;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                colvarAdminId.DefaultSetting = @"";
                colvarAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAdminId);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("App_Version", schema);
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
        [DisplayName("版本号")]
        [XmlAttribute("Code")]
        [Bindable(true)]
        public string Code
        {
            get { return GetColumnValue<string>(Columns.Code); }
            set { SetColumnValue(Columns.Code, value); }
        }
        [DisplayName("Url")]
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url
        {
            get { return GetColumnValue<string>(Columns.Url); }
            set { SetColumnValue(Columns.Url, value); }
        }
        [DisplayName("介绍")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("发布时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("发布人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varCode, string varUrl, string varMemo, DateTime varPubDate, string varAdminId)
        {
            App_Version item = new App_Version();
            item.Id = varId;
            item.Code = varCode;
            item.Url = varUrl;
            item.Memo = varMemo;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varCode, string varUrl, string varMemo, DateTime varPubDate, string varAdminId)
        {
            App_Version item = new App_Version();
            item.Id = varId;
            item.Code = varCode;
            item.Url = varUrl;
            item.Memo = varMemo;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;

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
        public static TableSchema.TableColumn CodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Code = @"Code";
            public static string Url = @"Url";
            public static string Memo = @"Memo";
            public static string PubDate = @"PubDate";
            public static string AdminId = @"AdminId";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
