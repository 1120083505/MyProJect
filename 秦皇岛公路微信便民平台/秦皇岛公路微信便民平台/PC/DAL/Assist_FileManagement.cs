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
    public partial class Assist_FileManagementCollection : ActiveList<Assist_FileManagement, Assist_FileManagementCollection>
    {
        public Assist_FileManagementCollection() { }
        public Assist_FileManagementCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Assist_FileManagement o = this[i];
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
    public partial class Assist_FileManagement : ActiveRecord<Assist_FileManagement>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Assist_FileManagement()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Assist_FileManagement(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Assist_FileManagement(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Assist_FileManagement(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Assist_FileManagement", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCustodyId = new TableSchema.TableColumn(schema);
                colvarCustodyId.ColumnName = "CustodyId";
                colvarCustodyId.DataType = DbType.String;
                colvarCustodyId.MaxLength = 50;
                colvarCustodyId.AutoIncrement = false;
                colvarCustodyId.IsNullable = false;
                colvarCustodyId.IsPrimaryKey = false;
                colvarCustodyId.IsForeignKey = false;
                colvarCustodyId.IsReadOnly = false;
                colvarCustodyId.DefaultSetting = @"";
                colvarCustodyId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCustodyId);


                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 500;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = false;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                colvarTitle.DefaultSetting = @"";
                colvarTitle.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTitle);


                TableSchema.TableColumn colvarIsHighlight = new TableSchema.TableColumn(schema);
                colvarIsHighlight.ColumnName = "IsHighlight";
                colvarIsHighlight.DataType = DbType.Int32;
                colvarIsHighlight.MaxLength = 0;
                colvarIsHighlight.AutoIncrement = false;
                colvarIsHighlight.IsNullable = false;
                colvarIsHighlight.IsPrimaryKey = false;
                colvarIsHighlight.IsForeignKey = false;
                colvarIsHighlight.IsReadOnly = false;
                colvarIsHighlight.DefaultSetting = @"((1))";
                colvarIsHighlight.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsHighlight);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Assist_FileManagement", schema);
            }
        }
        #endregion
        #region Props
        [DisplayName("主键")]
        [XmlAttribute("Id")]
        [Bindable(true)]
        public string Id
        {
            get { return GetColumnValue<string>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }
        [DisplayName("所属单位")]
        [XmlAttribute("CustodyId")]
        [Bindable(true)]
        public string CustodyId
        {
            get { return GetColumnValue<string>(Columns.CustodyId); }
            set { SetColumnValue(Columns.CustodyId, value); }
        }
        [DisplayName("标题")]
        [XmlAttribute("Title")]
        [Bindable(true)]
        public string Title
        {
            get { return GetColumnValue<string>(Columns.Title); }
            set { SetColumnValue(Columns.Title, value); }
        }
        [DisplayName("是否高亮显示")]
        [XmlAttribute("IsHighlight")]
        [Bindable(true)]
        public int IsHighlight
        {
            get { return GetColumnValue<int>(Columns.IsHighlight); }
            set { SetColumnValue(Columns.IsHighlight, value); }
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
        [DisplayName("最后修改时间")]
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        [DisplayName("最后修改人")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varCustodyId, string varTitle, int varIsHighlight, string varMemo, string varAdminId, DateTime varPubDate, DateTime? varEditPubDate, string varEditAdminId)
        {
            Assist_FileManagement item = new Assist_FileManagement();
            item.Id = varId;
            item.CustodyId = varCustodyId;
            item.Title = varTitle;
            item.IsHighlight = varIsHighlight;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditPubDate = varEditPubDate;
            item.EditAdminId = varEditAdminId;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varCustodyId, string varTitle, int varIsHighlight, string varMemo, string varAdminId, DateTime varPubDate, DateTime? varEditPubDate, string varEditAdminId)
        {
            Assist_FileManagement item = new Assist_FileManagement();
            item.Id = varId;
            item.CustodyId = varCustodyId;
            item.Title = varTitle;
            item.IsHighlight = varIsHighlight;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditPubDate = varEditPubDate;
            item.EditAdminId = varEditAdminId;

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
        public static TableSchema.TableColumn CustodyIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn IsHighlightColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string CustodyId = @"CustodyId";
            public static string Title = @"Title";
            public static string IsHighlight = @"IsHighlight";
            public static string Memo = @"Memo";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string EditPubDate = @"EditPubDate";
            public static string EditAdminId = @"EditAdminId";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
