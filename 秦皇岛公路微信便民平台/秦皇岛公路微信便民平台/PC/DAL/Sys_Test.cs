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
    public partial class Sys_TestCollection : ActiveList<Sys_Test, Sys_TestCollection>
    {
        public Sys_TestCollection() { }
        public Sys_TestCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Test o = this[i];
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
    public partial class Sys_Test : ActiveRecord<Sys_Test>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Sys_Test()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Test(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Test(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Test(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Test", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 50;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = false;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                colvarTitle.DefaultSetting = @"";
                colvarTitle.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTitle);


                TableSchema.TableColumn colvarprice = new TableSchema.TableColumn(schema);
                colvarprice.ColumnName = "price";
                colvarprice.DataType = DbType.Decimal;
                colvarprice.MaxLength = 0;
                colvarprice.AutoIncrement = false;
                colvarprice.IsNullable = false;
                colvarprice.IsPrimaryKey = false;
                colvarprice.IsForeignKey = false;
                colvarprice.IsReadOnly = false;
                colvarprice.DefaultSetting = @"";
                colvarprice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarprice);


                TableSchema.TableColumn colvarcount = new TableSchema.TableColumn(schema);
                colvarcount.ColumnName = "count";
                colvarcount.DataType = DbType.Int32;
                colvarcount.MaxLength = 0;
                colvarcount.AutoIncrement = false;
                colvarcount.IsNullable = false;
                colvarcount.IsPrimaryKey = false;
                colvarcount.IsForeignKey = false;
                colvarcount.IsReadOnly = false;
                colvarcount.DefaultSetting = @"";
                colvarcount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarcount);


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


                TableSchema.TableColumn colvarOtherMemo = new TableSchema.TableColumn(schema);
                colvarOtherMemo.ColumnName = "OtherMemo";
                colvarOtherMemo.DataType = DbType.String;
                colvarOtherMemo.MaxLength = 500;
                colvarOtherMemo.AutoIncrement = false;
                colvarOtherMemo.IsNullable = true;
                colvarOtherMemo.IsPrimaryKey = false;
                colvarOtherMemo.IsForeignKey = false;
                colvarOtherMemo.IsReadOnly = false;
                colvarOtherMemo.DefaultSetting = @"";
                colvarOtherMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOtherMemo);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Test", schema);
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
        [DisplayName("测试名称")]
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [DisplayName("标题")]
        [XmlAttribute("Title")]
        [Bindable(true)]
        public string Title
        {
            get { return GetColumnValue<string>(Columns.Title); }
            set { SetColumnValue(Columns.Title, value); }
        }
        [DisplayName("价格")]
        [XmlAttribute("price")]
        [Bindable(true)]
        public decimal price
        {
            get { return GetColumnValue<decimal>(Columns.price); }
            set { SetColumnValue(Columns.price, value); }
        }
        [DisplayName("计数")]
        [XmlAttribute("count")]
        [Bindable(true)]
        public int count
        {
            get { return GetColumnValue<int>(Columns.count); }
            set { SetColumnValue(Columns.count, value); }
        }
        [DisplayName("操作时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("操作员")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("OtherMemo")]
        [Bindable(true)]
        public string OtherMemo
        {
            get { return GetColumnValue<string>(Columns.OtherMemo); }
            set { SetColumnValue(Columns.OtherMemo, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varName, string varTitle, decimal varprice, int varcount, DateTime varPubDate, string varAdminId, string varOtherMemo)
        {
            Sys_Test item = new Sys_Test();
            item.Id = varId;
            item.Name = varName;
            item.Title = varTitle;
            item.price = varprice;
            item.count = varcount;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;
            item.OtherMemo = varOtherMemo;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varName, string varTitle, decimal varprice, int varcount, DateTime varPubDate, string varAdminId, string varOtherMemo)
        {
            Sys_Test item = new Sys_Test();
            item.Id = varId;
            item.Name = varName;
            item.Title = varTitle;
            item.price = varprice;
            item.count = varcount;
            item.PubDate = varPubDate;
            item.AdminId = varAdminId;
            item.OtherMemo = varOtherMemo;

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
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn priceColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn countColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn OtherMemoColumn
        {
            get { return Schema.Columns[7]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Name = @"Name";
            public static string Title = @"Title";
            public static string price = @"price";
            public static string count = @"count";
            public static string PubDate = @"PubDate";
            public static string AdminId = @"AdminId";
            public static string OtherMemo = @"OtherMemo";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
