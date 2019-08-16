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
    public partial class Sys_LogCollection : ActiveList<Sys_Log, Sys_LogCollection>
    {
        public Sys_LogCollection() { }
        public Sys_LogCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Log o = this[i];
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
    public partial class Sys_Log : ActiveRecord<Sys_Log>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Sys_Log()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Log(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Log(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Log(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Log", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarModuleName = new TableSchema.TableColumn(schema);
                colvarModuleName.ColumnName = "ModuleName";
                colvarModuleName.DataType = DbType.String;
                colvarModuleName.MaxLength = 200;
                colvarModuleName.AutoIncrement = false;
                colvarModuleName.IsNullable = false;
                colvarModuleName.IsPrimaryKey = false;
                colvarModuleName.IsForeignKey = false;
                colvarModuleName.IsReadOnly = false;
                colvarModuleName.DefaultSetting = @"";
                colvarModuleName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarModuleName);


                TableSchema.TableColumn colvarOperateName = new TableSchema.TableColumn(schema);
                colvarOperateName.ColumnName = "OperateName";
                colvarOperateName.DataType = DbType.String;
                colvarOperateName.MaxLength = 500;
                colvarOperateName.AutoIncrement = false;
                colvarOperateName.IsNullable = true;
                colvarOperateName.IsPrimaryKey = false;
                colvarOperateName.IsForeignKey = false;
                colvarOperateName.IsReadOnly = false;
                colvarOperateName.DefaultSetting = @"";
                colvarOperateName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOperateName);


                TableSchema.TableColumn colvarOperateMemo = new TableSchema.TableColumn(schema);
                colvarOperateMemo.ColumnName = "OperateMemo";
                colvarOperateMemo.DataType = DbType.String;
                colvarOperateMemo.MaxLength = 0;
                colvarOperateMemo.AutoIncrement = false;
                colvarOperateMemo.IsNullable = false;
                colvarOperateMemo.IsPrimaryKey = false;
                colvarOperateMemo.IsForeignKey = false;
                colvarOperateMemo.IsReadOnly = false;
                colvarOperateMemo.DefaultSetting = @"";
                colvarOperateMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOperateMemo);


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


                TableSchema.TableColumn colvarIP = new TableSchema.TableColumn(schema);
                colvarIP.ColumnName = "IP";
                colvarIP.DataType = DbType.String;
                colvarIP.MaxLength = 50;
                colvarIP.AutoIncrement = false;
                colvarIP.IsNullable = false;
                colvarIP.IsPrimaryKey = false;
                colvarIP.IsForeignKey = false;
                colvarIP.IsReadOnly = false;
                colvarIP.DefaultSetting = @"";
                colvarIP.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIP);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Log", schema);
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
        [DisplayName("模块名称")]
        [XmlAttribute("ModuleName")]
        [Bindable(true)]
        public string ModuleName
        {
            get { return GetColumnValue<string>(Columns.ModuleName); }
            set { SetColumnValue(Columns.ModuleName, value); }
        }
        [DisplayName("操作名称")]
        [XmlAttribute("OperateName")]
        [Bindable(true)]
        public string OperateName
        {
            get { return GetColumnValue<string>(Columns.OperateName); }
            set { SetColumnValue(Columns.OperateName, value); }
        }
        [DisplayName("操作说明")]
        [XmlAttribute("OperateMemo")]
        [Bindable(true)]
        public string OperateMemo
        {
            get { return GetColumnValue<string>(Columns.OperateMemo); }
            set { SetColumnValue(Columns.OperateMemo, value); }
        }
        [DisplayName("操作时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("操作人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("IP")]
        [XmlAttribute("IP")]
        [Bindable(true)]
        public string IP
        {
            get { return GetColumnValue<string>(Columns.IP); }
            set { SetColumnValue(Columns.IP, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varModuleName, string varOperateName, string varOperateMemo, DateTime varPubDate, string varAdminId, string varIP)
        {
            Sys_Log item = new Sys_Log();
            item.Id = varId;
            item.ModuleName = varModuleName;
            item.OperateName = varOperateName;
            item.OperateMemo = varOperateMemo;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;
            item.IP = varIP;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varModuleName, string varOperateName, string varOperateMemo, DateTime varPubDate, string varAdminId, string varIP)
        {
            Sys_Log item = new Sys_Log();
            item.Id = varId;
            item.ModuleName = varModuleName;
            item.OperateName = varOperateName;
            item.OperateMemo = varOperateMemo;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;
            item.IP = varIP;

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
        public static TableSchema.TableColumn ModuleNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn OperateNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn OperateMemoColumn
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
        public static TableSchema.TableColumn IPColumn
        {
            get { return Schema.Columns[6]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string ModuleName = @"ModuleName";
            public static string OperateName = @"OperateName";
            public static string OperateMemo = @"OperateMemo";
            public static string PubDate = @"PubDate";
            public static string AdminId = @"AdminId";
            public static string IP = @"IP";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
