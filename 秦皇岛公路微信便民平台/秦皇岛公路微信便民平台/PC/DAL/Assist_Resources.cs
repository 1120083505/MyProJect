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
    public partial class Assist_ResourcesCollection : ActiveList<Assist_Resources, Assist_ResourcesCollection>
    {
        public Assist_ResourcesCollection() { }
        public Assist_ResourcesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Assist_Resources o = this[i];
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
    public partial class Assist_Resources : ActiveRecord<Assist_Resources>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Assist_Resources()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Assist_Resources(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Assist_Resources(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Assist_Resources(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Assist_Resources", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarFromId = new TableSchema.TableColumn(schema);
                colvarFromId.ColumnName = "FromId";
                colvarFromId.DataType = DbType.String;
                colvarFromId.MaxLength = 50;
                colvarFromId.AutoIncrement = false;
                colvarFromId.IsNullable = false;
                colvarFromId.IsPrimaryKey = false;
                colvarFromId.IsForeignKey = false;
                colvarFromId.IsReadOnly = false;
                colvarFromId.DefaultSetting = @"";
                colvarFromId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFromId);


                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.String;
                colvarUrl.MaxLength = 0;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = false;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                colvarUrl.DefaultSetting = @"";
                colvarUrl.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUrl);


                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.String;
                colvarName.MaxLength = 500;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                colvarName.DefaultSetting = @"";
                colvarName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarName);


                TableSchema.TableColumn colvarSuddix = new TableSchema.TableColumn(schema);
                colvarSuddix.ColumnName = "Suddix";
                colvarSuddix.DataType = DbType.String;
                colvarSuddix.MaxLength = 50;
                colvarSuddix.AutoIncrement = false;
                colvarSuddix.IsNullable = false;
                colvarSuddix.IsPrimaryKey = false;
                colvarSuddix.IsForeignKey = false;
                colvarSuddix.IsReadOnly = false;
                colvarSuddix.DefaultSetting = @"";
                colvarSuddix.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSuddix);


                TableSchema.TableColumn colvarFileType = new TableSchema.TableColumn(schema);
                colvarFileType.ColumnName = "FileType";
                colvarFileType.DataType = DbType.String;
                colvarFileType.MaxLength = 50;
                colvarFileType.AutoIncrement = false;
                colvarFileType.IsNullable = true;
                colvarFileType.IsPrimaryKey = false;
                colvarFileType.IsForeignKey = false;
                colvarFileType.IsReadOnly = false;
                colvarFileType.DefaultSetting = @"";
                colvarFileType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFileType);


                TableSchema.TableColumn colvarFromType = new TableSchema.TableColumn(schema);
                colvarFromType.ColumnName = "FromType";
                colvarFromType.DataType = DbType.Int32;
                colvarFromType.MaxLength = 0;
                colvarFromType.AutoIncrement = false;
                colvarFromType.IsNullable = true;
                colvarFromType.IsPrimaryKey = false;
                colvarFromType.IsForeignKey = false;
                colvarFromType.IsReadOnly = false;
                colvarFromType.DefaultSetting = @"";
                colvarFromType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFromType);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Assist_Resources", schema);
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
        [DisplayName("所属类型表")]
        [XmlAttribute("FromId")]
        [Bindable(true)]
        public string FromId
        {
            get { return GetColumnValue<string>(Columns.FromId); }
            set { SetColumnValue(Columns.FromId, value); }
        }
        [DisplayName("路径")]
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url
        {
            get { return GetColumnValue<string>(Columns.Url); }
            set { SetColumnValue(Columns.Url, value); }
        }
        [DisplayName("文件名")]
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [DisplayName("后缀")]
        [XmlAttribute("Suddix")]
        [Bindable(true)]
        public string Suddix
        {
            get { return GetColumnValue<string>(Columns.Suddix); }
            set { SetColumnValue(Columns.Suddix, value); }
        }
        [DisplayName("文件类型")]
        [XmlAttribute("FileType")]
        [Bindable(true)]
        public string FileType
        {
            get { return GetColumnValue<string>(Columns.FileType); }
            set { SetColumnValue(Columns.FileType, value); }
        }
        [DisplayName("所属类型")]
        [XmlAttribute("FromType")]
        [Bindable(true)]
        public int? FromType
        {
            get { return GetColumnValue<int?>(Columns.FromType); }
            set { SetColumnValue(Columns.FromType, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("操作人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("操作时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("最后修改人")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [DisplayName("最后修改时间")]
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varFromId, string varUrl, string varName, string varSuddix, string varFileType, int? varFromType, string varMemo, string varAdminId, DateTime varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Assist_Resources item = new Assist_Resources();
            item.Id = varId;
            item.FromId = varFromId;
            item.Url = varUrl;
            item.Name = varName;
            item.Suddix = varSuddix;
            item.FileType = varFileType;
            item.FromType = varFromType;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varFromId, string varUrl, string varName, string varSuddix, string varFileType, int? varFromType, string varMemo, string varAdminId, DateTime varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Assist_Resources item = new Assist_Resources();
            item.Id = varId;
            item.FromId = varFromId;
            item.Url = varUrl;
            item.Name = varName;
            item.Suddix = varSuddix;
            item.FileType = varFileType;
            item.FromType = varFromType;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;

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
        public static TableSchema.TableColumn FromIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn SuddixColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn FileTypeColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn FromTypeColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[10]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[11]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string FromId = @"FromId";
            public static string Url = @"Url";
            public static string Name = @"Name";
            public static string Suddix = @"Suddix";
            public static string FileType = @"FileType";
            public static string FromType = @"FromType";
            public static string Memo = @"Memo";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
