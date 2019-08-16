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
    public partial class Sys_ModuleCollection : ActiveList<Sys_Module, Sys_ModuleCollection>
    {
        public Sys_ModuleCollection() { }
        public Sys_ModuleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Module o = this[i];
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
    public partial class Sys_Module : ActiveRecord<Sys_Module>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Sys_Module()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Module(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Module(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Module(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Module", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.String;
                colvarName.MaxLength = 50;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                colvarName.DefaultSetting = @"";
                colvarName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarName);


                TableSchema.TableColumn colvarEnName = new TableSchema.TableColumn(schema);
                colvarEnName.ColumnName = "EnName";
                colvarEnName.DataType = DbType.String;
                colvarEnName.MaxLength = 50;
                colvarEnName.AutoIncrement = false;
                colvarEnName.IsNullable = false;
                colvarEnName.IsPrimaryKey = false;
                colvarEnName.IsForeignKey = false;
                colvarEnName.IsReadOnly = false;
                colvarEnName.DefaultSetting = @"";
                colvarEnName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEnName);


                TableSchema.TableColumn colvarParentId = new TableSchema.TableColumn(schema);
                colvarParentId.ColumnName = "ParentId";
                colvarParentId.DataType = DbType.String;
                colvarParentId.MaxLength = 50;
                colvarParentId.AutoIncrement = false;
                colvarParentId.IsNullable = false;
                colvarParentId.IsPrimaryKey = false;
                colvarParentId.IsForeignKey = false;
                colvarParentId.IsReadOnly = false;
                colvarParentId.DefaultSetting = @"";
                colvarParentId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarParentId);


                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.String;
                colvarUrl.MaxLength = 0;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = true;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                colvarUrl.DefaultSetting = @"";
                colvarUrl.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUrl);


                TableSchema.TableColumn colvarIcon = new TableSchema.TableColumn(schema);
                colvarIcon.ColumnName = "Icon";
                colvarIcon.DataType = DbType.String;
                colvarIcon.MaxLength = 250;
                colvarIcon.AutoIncrement = false;
                colvarIcon.IsNullable = true;
                colvarIcon.IsPrimaryKey = false;
                colvarIcon.IsForeignKey = false;
                colvarIcon.IsReadOnly = false;
                colvarIcon.DefaultSetting = @"";
                colvarIcon.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIcon);


                TableSchema.TableColumn colvarIsLast = new TableSchema.TableColumn(schema);
                colvarIsLast.ColumnName = "IsLast";
                colvarIsLast.DataType = DbType.Int32;
                colvarIsLast.MaxLength = 0;
                colvarIsLast.AutoIncrement = false;
                colvarIsLast.IsNullable = false;
                colvarIsLast.IsPrimaryKey = false;
                colvarIsLast.IsForeignKey = false;
                colvarIsLast.IsReadOnly = false;
                colvarIsLast.DefaultSetting = @"((0))";
                colvarIsLast.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsLast);


                TableSchema.TableColumn colvarEnable = new TableSchema.TableColumn(schema);
                colvarEnable.ColumnName = "Enable";
                colvarEnable.DataType = DbType.Int32;
                colvarEnable.MaxLength = 0;
                colvarEnable.AutoIncrement = false;
                colvarEnable.IsNullable = false;
                colvarEnable.IsPrimaryKey = false;
                colvarEnable.IsForeignKey = false;
                colvarEnable.IsReadOnly = false;
                colvarEnable.DefaultSetting = @"((1))";
                colvarEnable.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEnable);


                TableSchema.TableColumn colvarSort = new TableSchema.TableColumn(schema);
                colvarSort.ColumnName = "Sort";
                colvarSort.DataType = DbType.Int32;
                colvarSort.MaxLength = 0;
                colvarSort.AutoIncrement = false;
                colvarSort.IsNullable = false;
                colvarSort.IsPrimaryKey = false;
                colvarSort.IsForeignKey = false;
                colvarSort.IsReadOnly = false;
                colvarSort.DefaultSetting = @"((0))";
                colvarSort.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSort);


                TableSchema.TableColumn colvarIsShow = new TableSchema.TableColumn(schema);
                colvarIsShow.ColumnName = "IsShow";
                colvarIsShow.DataType = DbType.Int32;
                colvarIsShow.MaxLength = 0;
                colvarIsShow.AutoIncrement = false;
                colvarIsShow.IsNullable = false;
                colvarIsShow.IsPrimaryKey = false;
                colvarIsShow.IsForeignKey = false;
                colvarIsShow.IsReadOnly = false;
                colvarIsShow.DefaultSetting = @"((0))";
                colvarIsShow.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsShow);


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


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 150;
                colvarMemo.AutoIncrement = false;
                colvarMemo.IsNullable = true;
                colvarMemo.IsPrimaryKey = false;
                colvarMemo.IsForeignKey = false;
                colvarMemo.IsReadOnly = false;
                colvarMemo.DefaultSetting = @"";
                colvarMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMemo);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Module", schema);
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
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [DisplayName("英文名称")]
        [XmlAttribute("EnName")]
        [Bindable(true)]
        public string EnName
        {
            get { return GetColumnValue<string>(Columns.EnName); }
            set { SetColumnValue(Columns.EnName, value); }
        }
        [DisplayName("父级菜单ID")]
        [XmlAttribute("ParentId")]
        [Bindable(true)]
        public string ParentId
        {
            get { return GetColumnValue<string>(Columns.ParentId); }
            set { SetColumnValue(Columns.ParentId, value); }
        }
        [DisplayName("链接")]
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url
        {
            get { return GetColumnValue<string>(Columns.Url); }
            set { SetColumnValue(Columns.Url, value); }
        }
        [DisplayName("图标样式")]
        [XmlAttribute("Icon")]
        [Bindable(true)]
        public string Icon
        {
            get { return GetColumnValue<string>(Columns.Icon); }
            set { SetColumnValue(Columns.Icon, value); }
        }
        [DisplayName("是否为最后")]
        [XmlAttribute("IsLast")]
        [Bindable(true)]
        public int IsLast
        {
            get { return GetColumnValue<int>(Columns.IsLast); }
            set { SetColumnValue(Columns.IsLast, value); }
        }
        [DisplayName("是否启用")]
        [XmlAttribute("Enable")]
        [Bindable(true)]
        public int Enable
        {
            get { return GetColumnValue<int>(Columns.Enable); }
            set { SetColumnValue(Columns.Enable, value); }
        }
        [DisplayName("排序")]
        [XmlAttribute("Sort")]
        [Bindable(true)]
        public int Sort
        {
            get { return GetColumnValue<int>(Columns.Sort); }
            set { SetColumnValue(Columns.Sort, value); }
        }
        [DisplayName("显示")]
        [XmlAttribute("IsShow")]
        [Bindable(true)]
        public int IsShow
        {
            get { return GetColumnValue<int>(Columns.IsShow); }
            set { SetColumnValue(Columns.IsShow, value); }
        }
        [DisplayName("管理员ID")]
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
        [DisplayName("说明")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varName, string varEnName, string varParentId, string varUrl, string varIcon, int varIsLast, int varEnable, int varSort, int varIsShow, string varAdminId, DateTime varPubDate, string varMemo)
        {
            Sys_Module item = new Sys_Module();
            item.Id = varId;
            item.Name = varName;
            item.EnName = varEnName;
            item.ParentId = varParentId;
            item.Url = varUrl;
            item.Icon = varIcon;
            item.IsLast = varIsLast;
            item.Enable = varEnable;
            item.Sort = varSort;
            item.IsShow = varIsShow;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Memo = varMemo;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varName, string varEnName, string varParentId, string varUrl, string varIcon, int varIsLast, int varEnable, int varSort, int varIsShow, string varAdminId, DateTime varPubDate, string varMemo)
        {
            Sys_Module item = new Sys_Module();
            item.Id = varId;
            item.Name = varName;
            item.EnName = varEnName;
            item.ParentId = varParentId;
            item.Url = varUrl;
            item.Icon = varIcon;
            item.IsLast = varIsLast;
            item.Enable = varEnable;
            item.Sort = varSort;
            item.IsShow = varIsShow;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Memo = varMemo;

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
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn EnNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn ParentIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn IconColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn IsLastColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn EnableColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn SortColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn IsShowColumn
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[10]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[11]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[12]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Name = @"Name";
            public static string EnName = @"EnName";
            public static string ParentId = @"ParentId";
            public static string Url = @"Url";
            public static string Icon = @"Icon";
            public static string IsLast = @"IsLast";
            public static string Enable = @"Enable";
            public static string Sort = @"Sort";
            public static string IsShow = @"IsShow";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string Memo = @"Memo";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
