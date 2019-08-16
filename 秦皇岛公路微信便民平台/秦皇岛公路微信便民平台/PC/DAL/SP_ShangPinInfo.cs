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
    public partial class SP_ShangPinInfoCollection : ActiveList<SP_ShangPinInfo, SP_ShangPinInfoCollection>
    {
        public SP_ShangPinInfoCollection() { }
        public SP_ShangPinInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SP_ShangPinInfo o = this[i];
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
    public partial class SP_ShangPinInfo : ActiveRecord<SP_ShangPinInfo>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public SP_ShangPinInfo()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public SP_ShangPinInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public SP_ShangPinInfo(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public SP_ShangPinInfo(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("SP_ShangPinInfo", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarMainId = new TableSchema.TableColumn(schema);
                colvarMainId.ColumnName = "MainId";
                colvarMainId.DataType = DbType.String;
                colvarMainId.MaxLength = 50;
                colvarMainId.AutoIncrement = false;
                colvarMainId.IsNullable = true;
                colvarMainId.IsPrimaryKey = false;
                colvarMainId.IsForeignKey = false;
                colvarMainId.IsReadOnly = false;
                colvarMainId.DefaultSetting = @"";
                colvarMainId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMainId);


                TableSchema.TableColumn colvarFormId = new TableSchema.TableColumn(schema);
                colvarFormId.ColumnName = "FormId";
                colvarFormId.DataType = DbType.String;
                colvarFormId.MaxLength = 50;
                colvarFormId.AutoIncrement = false;
                colvarFormId.IsNullable = true;
                colvarFormId.IsPrimaryKey = false;
                colvarFormId.IsForeignKey = false;
                colvarFormId.IsReadOnly = false;
                colvarFormId.DefaultSetting = @"";
                colvarFormId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFormId);


                TableSchema.TableColumn colvarIswarehouse = new TableSchema.TableColumn(schema);
                colvarIswarehouse.ColumnName = "Iswarehouse";
                colvarIswarehouse.DataType = DbType.Int32;
                colvarIswarehouse.MaxLength = 0;
                colvarIswarehouse.AutoIncrement = false;
                colvarIswarehouse.IsNullable = true;
                colvarIswarehouse.IsPrimaryKey = false;
                colvarIswarehouse.IsForeignKey = false;
                colvarIswarehouse.IsReadOnly = false;
                colvarIswarehouse.DefaultSetting = @"";
                colvarIswarehouse.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIswarehouse);


                TableSchema.TableColumn colvarNum = new TableSchema.TableColumn(schema);
                colvarNum.ColumnName = "Num";
                colvarNum.DataType = DbType.Decimal;
                colvarNum.MaxLength = 0;
                colvarNum.AutoIncrement = false;
                colvarNum.IsNullable = true;
                colvarNum.IsPrimaryKey = false;
                colvarNum.IsForeignKey = false;
                colvarNum.IsReadOnly = false;
                colvarNum.DefaultSetting = @"";
                colvarNum.ForeignKeyTableName = "";
                schema.Columns.Add(colvarNum);


                TableSchema.TableColumn colvarPrice = new TableSchema.TableColumn(schema);
                colvarPrice.ColumnName = "Price";
                colvarPrice.DataType = DbType.Decimal;
                colvarPrice.MaxLength = 0;
                colvarPrice.AutoIncrement = false;
                colvarPrice.IsNullable = true;
                colvarPrice.IsPrimaryKey = false;
                colvarPrice.IsForeignKey = false;
                colvarPrice.IsReadOnly = false;
                colvarPrice.DefaultSetting = @"";
                colvarPrice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPrice);


                TableSchema.TableColumn colvarSumPrice = new TableSchema.TableColumn(schema);
                colvarSumPrice.ColumnName = "SumPrice";
                colvarSumPrice.DataType = DbType.Decimal;
                colvarSumPrice.MaxLength = 0;
                colvarSumPrice.AutoIncrement = false;
                colvarSumPrice.IsNullable = true;
                colvarSumPrice.IsPrimaryKey = false;
                colvarSumPrice.IsForeignKey = false;
                colvarSumPrice.IsReadOnly = false;
                colvarSumPrice.DefaultSetting = @"";
                colvarSumPrice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSumPrice);


                TableSchema.TableColumn colvarWarehouse = new TableSchema.TableColumn(schema);
                colvarWarehouse.ColumnName = "Warehouse";
                colvarWarehouse.DataType = DbType.String;
                colvarWarehouse.MaxLength = 50;
                colvarWarehouse.AutoIncrement = false;
                colvarWarehouse.IsNullable = true;
                colvarWarehouse.IsPrimaryKey = false;
                colvarWarehouse.IsForeignKey = false;
                colvarWarehouse.IsReadOnly = false;
                colvarWarehouse.DefaultSetting = @"";
                colvarWarehouse.ForeignKeyTableName = "";
                schema.Columns.Add(colvarWarehouse);


                TableSchema.TableColumn colvarCustomer = new TableSchema.TableColumn(schema);
                colvarCustomer.ColumnName = "Customer";
                colvarCustomer.DataType = DbType.String;
                colvarCustomer.MaxLength = 50;
                colvarCustomer.AutoIncrement = false;
                colvarCustomer.IsNullable = true;
                colvarCustomer.IsPrimaryKey = false;
                colvarCustomer.IsForeignKey = false;
                colvarCustomer.IsReadOnly = false;
                colvarCustomer.DefaultSetting = @"";
                colvarCustomer.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCustomer);


                TableSchema.TableColumn colvarCustomerId = new TableSchema.TableColumn(schema);
                colvarCustomerId.ColumnName = "CustomerId";
                colvarCustomerId.DataType = DbType.String;
                colvarCustomerId.MaxLength = 50;
                colvarCustomerId.AutoIncrement = false;
                colvarCustomerId.IsNullable = true;
                colvarCustomerId.IsPrimaryKey = false;
                colvarCustomerId.IsForeignKey = false;
                colvarCustomerId.IsReadOnly = false;
                colvarCustomerId.DefaultSetting = @"";
                colvarCustomerId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCustomerId);


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
                colvarPubDate.IsNullable = true;
                colvarPubDate.IsPrimaryKey = false;
                colvarPubDate.IsForeignKey = false;
                colvarPubDate.IsReadOnly = false;
                colvarPubDate.DefaultSetting = @"";
                colvarPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubDate);


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 500;
                colvarMemo.AutoIncrement = false;
                colvarMemo.IsNullable = true;
                colvarMemo.IsPrimaryKey = false;
                colvarMemo.IsForeignKey = false;
                colvarMemo.IsReadOnly = false;
                colvarMemo.DefaultSetting = @"";
                colvarMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMemo);


                TableSchema.TableColumn colvarYear = new TableSchema.TableColumn(schema);
                colvarYear.ColumnName = "Year";
                colvarYear.DataType = DbType.String;
                colvarYear.MaxLength = 20;
                colvarYear.AutoIncrement = false;
                colvarYear.IsNullable = true;
                colvarYear.IsPrimaryKey = false;
                colvarYear.IsForeignKey = false;
                colvarYear.IsReadOnly = false;
                colvarYear.DefaultSetting = @"";
                colvarYear.ForeignKeyTableName = "";
                schema.Columns.Add(colvarYear);


                TableSchema.TableColumn colvarMonth = new TableSchema.TableColumn(schema);
                colvarMonth.ColumnName = "Month";
                colvarMonth.DataType = DbType.String;
                colvarMonth.MaxLength = 20;
                colvarMonth.AutoIncrement = false;
                colvarMonth.IsNullable = true;
                colvarMonth.IsPrimaryKey = false;
                colvarMonth.IsForeignKey = false;
                colvarMonth.IsReadOnly = false;
                colvarMonth.DefaultSetting = @"";
                colvarMonth.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMonth);


                TableSchema.TableColumn colvarDay = new TableSchema.TableColumn(schema);
                colvarDay.ColumnName = "Day";
                colvarDay.DataType = DbType.String;
                colvarDay.MaxLength = 20;
                colvarDay.AutoIncrement = false;
                colvarDay.IsNullable = true;
                colvarDay.IsPrimaryKey = false;
                colvarDay.IsForeignKey = false;
                colvarDay.IsReadOnly = false;
                colvarDay.DefaultSetting = @"";
                colvarDay.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDay);


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
                colvarExt2.MaxLength = 50;
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
                colvarExt3.MaxLength = 50;
                colvarExt3.AutoIncrement = false;
                colvarExt3.IsNullable = true;
                colvarExt3.IsPrimaryKey = false;
                colvarExt3.IsForeignKey = false;
                colvarExt3.IsReadOnly = false;
                colvarExt3.DefaultSetting = @"";
                colvarExt3.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt3);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("SP_ShangPinInfo", schema);
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
        [DisplayName("关联ID")]
        [XmlAttribute("MainId")]
        [Bindable(true)]
        public string MainId
        {
            get { return GetColumnValue<string>(Columns.MainId); }
            set { SetColumnValue(Columns.MainId, value); }
        }
        [DisplayName("商品名称")]
        [XmlAttribute("FormId")]
        [Bindable(true)]
        public string FormId
        {
            get { return GetColumnValue<string>(Columns.FormId); }
            set { SetColumnValue(Columns.FormId, value); }
        }
        [DisplayName("是否进出库")]
        [XmlAttribute("Iswarehouse")]
        [Bindable(true)]
        public int? Iswarehouse
        {
            get { return GetColumnValue<int?>(Columns.Iswarehouse); }
            set { SetColumnValue(Columns.Iswarehouse, value); }
        }
        [DisplayName("数量")]
        [XmlAttribute("Num")]
        [Bindable(true)]
        public decimal? Num
        {
            get { return GetColumnValue<decimal?>(Columns.Num); }
            set { SetColumnValue(Columns.Num, value); }
        }
        [DisplayName("价格")]
        [XmlAttribute("Price")]
        [Bindable(true)]
        public decimal? Price
        {
            get { return GetColumnValue<decimal?>(Columns.Price); }
            set { SetColumnValue(Columns.Price, value); }
        }
        [DisplayName("总价")]
        [XmlAttribute("SumPrice")]
        [Bindable(true)]
        public decimal? SumPrice
        {
            get { return GetColumnValue<decimal?>(Columns.SumPrice); }
            set { SetColumnValue(Columns.SumPrice, value); }
        }
        [DisplayName("所属仓库")]
        [XmlAttribute("Warehouse")]
        [Bindable(true)]
        public string Warehouse
        {
            get { return GetColumnValue<string>(Columns.Warehouse); }
            set { SetColumnValue(Columns.Warehouse, value); }
        }
        [DisplayName("客户")]
        [XmlAttribute("Customer")]
        [Bindable(true)]
        public string Customer
        {
            get { return GetColumnValue<string>(Columns.Customer); }
            set { SetColumnValue(Columns.Customer, value); }
        }
        [DisplayName("客户ID")]
        [XmlAttribute("CustomerId")]
        [Bindable(true)]
        public string CustomerId
        {
            get { return GetColumnValue<string>(Columns.CustomerId); }
            set { SetColumnValue(Columns.CustomerId, value); }
        }
        [DisplayName("录入人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("录入时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime? PubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("Year")]
        [XmlAttribute("Year")]
        [Bindable(true)]
        public string Year
        {
            get { return GetColumnValue<string>(Columns.Year); }
            set { SetColumnValue(Columns.Year, value); }
        }
        [DisplayName("Month")]
        [XmlAttribute("Month")]
        [Bindable(true)]
        public string Month
        {
            get { return GetColumnValue<string>(Columns.Month); }
            set { SetColumnValue(Columns.Month, value); }
        }
        [DisplayName("Day")]
        [XmlAttribute("Day")]
        [Bindable(true)]
        public string Day
        {
            get { return GetColumnValue<string>(Columns.Day); }
            set { SetColumnValue(Columns.Day, value); }
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
        public static void Insert(string varId, string varMainId, string varFormId, int? varIswarehouse, decimal? varNum, decimal? varPrice, decimal? varSumPrice, string varWarehouse, string varCustomer, string varCustomerId, string varAdminId, DateTime? varPubDate, string varMemo, string varYear, string varMonth, string varDay, string varExt1, string varExt2, string varExt3)
        {
            SP_ShangPinInfo item = new SP_ShangPinInfo();
            item.Id = varId;
            item.MainId = varMainId;
            item.FormId = varFormId;
            item.Iswarehouse = varIswarehouse;
            item.Num = varNum;
            item.Price = varPrice;
            item.SumPrice = varSumPrice;
            item.Warehouse = varWarehouse;
            item.Customer = varCustomer;
            item.CustomerId = varCustomerId;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Memo = varMemo;
            item.Year = varYear;
            item.Month = varMonth;
            item.Day = varDay;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varMainId, string varFormId, int? varIswarehouse, decimal? varNum, decimal? varPrice, decimal? varSumPrice, string varWarehouse, string varCustomer, string varCustomerId, string varAdminId, DateTime? varPubDate, string varMemo, string varYear, string varMonth, string varDay, string varExt1, string varExt2, string varExt3)
        {
            SP_ShangPinInfo item = new SP_ShangPinInfo();
            item.Id = varId;
            item.MainId = varMainId;
            item.FormId = varFormId;
            item.Iswarehouse = varIswarehouse;
            item.Num = varNum;
            item.Price = varPrice;
            item.SumPrice = varSumPrice;
            item.Warehouse = varWarehouse;
            item.Customer = varCustomer;
            item.CustomerId = varCustomerId;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Memo = varMemo;
            item.Year = varYear;
            item.Month = varMonth;
            item.Day = varDay;
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
        public static TableSchema.TableColumn MainIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn FormIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn IswarehouseColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn NumColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn PriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn SumPriceColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn WarehouseColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn CustomerColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn CustomerIdColumn
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
        public static TableSchema.TableColumn YearColumn
        {
            get { return Schema.Columns[13]; }
        }
        public static TableSchema.TableColumn MonthColumn
        {
            get { return Schema.Columns[14]; }
        }
        public static TableSchema.TableColumn DayColumn
        {
            get { return Schema.Columns[15]; }
        }
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[16]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[17]; }
        }
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[18]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string MainId = @"MainId";
            public static string FormId = @"FormId";
            public static string Iswarehouse = @"Iswarehouse";
            public static string Num = @"Num";
            public static string Price = @"Price";
            public static string SumPrice = @"SumPrice";
            public static string Warehouse = @"Warehouse";
            public static string Customer = @"Customer";
            public static string CustomerId = @"CustomerId";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string Memo = @"Memo";
            public static string Year = @"Year";
            public static string Month = @"Month";
            public static string Day = @"Day";
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
