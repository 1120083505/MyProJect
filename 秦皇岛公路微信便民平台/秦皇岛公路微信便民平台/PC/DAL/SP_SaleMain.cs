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
    public partial class SP_SaleMainCollection : ActiveList<SP_SaleMain, SP_SaleMainCollection>
    {
        public SP_SaleMainCollection() { }
        public SP_SaleMainCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SP_SaleMain o = this[i];
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
    public partial class SP_SaleMain : ActiveRecord<SP_SaleMain>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public SP_SaleMain()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public SP_SaleMain(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public SP_SaleMain(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public SP_SaleMain(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("SP_SaleMain", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCustomer = new TableSchema.TableColumn(schema);
                colvarCustomer.ColumnName = "Customer";
                colvarCustomer.DataType = DbType.String;
                colvarCustomer.MaxLength = 50;
                colvarCustomer.AutoIncrement = false;
                colvarCustomer.IsNullable = false;
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


                TableSchema.TableColumn colvarTotalPrice = new TableSchema.TableColumn(schema);
                colvarTotalPrice.ColumnName = "TotalPrice";
                colvarTotalPrice.DataType = DbType.Decimal;
                colvarTotalPrice.MaxLength = 0;
                colvarTotalPrice.AutoIncrement = false;
                colvarTotalPrice.IsNullable = false;
                colvarTotalPrice.IsPrimaryKey = false;
                colvarTotalPrice.IsForeignKey = false;
                colvarTotalPrice.IsReadOnly = false;
                colvarTotalPrice.DefaultSetting = @"";
                colvarTotalPrice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTotalPrice);


                TableSchema.TableColumn colvarOpeningTime = new TableSchema.TableColumn(schema);
                colvarOpeningTime.ColumnName = "OpeningTime";
                colvarOpeningTime.DataType = DbType.DateTime;
                colvarOpeningTime.MaxLength = 0;
                colvarOpeningTime.AutoIncrement = false;
                colvarOpeningTime.IsNullable = false;
                colvarOpeningTime.IsPrimaryKey = false;
                colvarOpeningTime.IsForeignKey = false;
                colvarOpeningTime.IsReadOnly = false;
                colvarOpeningTime.DefaultSetting = @"";
                colvarOpeningTime.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOpeningTime);


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
                DataService.Providers["ZrCon"].AddSchema("SP_SaleMain", schema);
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
        [DisplayName("总价合计")]
        [XmlAttribute("TotalPrice")]
        [Bindable(true)]
        public decimal TotalPrice
        {
            get { return GetColumnValue<decimal>(Columns.TotalPrice); }
            set { SetColumnValue(Columns.TotalPrice, value); }
        }
        [DisplayName("开单时间")]
        [XmlAttribute("OpeningTime")]
        [Bindable(true)]
        public DateTime OpeningTime
        {
            get { return GetColumnValue<DateTime>(Columns.OpeningTime); }
            set { SetColumnValue(Columns.OpeningTime, value); }
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
        [DisplayName("Month")]
        [XmlAttribute("Month")]
        [Bindable(true)]
        public string Month
        {
            get { return GetColumnValue<string>(Columns.Month); }
            set { SetColumnValue(Columns.Month, value); }
        }
        [DisplayName("Year")]
        [XmlAttribute("Year")]
        [Bindable(true)]
        public string Year
        {
            get { return GetColumnValue<string>(Columns.Year); }
            set { SetColumnValue(Columns.Year, value); }
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
        public static void Insert(string varId, string varCustomer, string varCustomerId, decimal varTotalPrice, DateTime varOpeningTime, string varAdminId, DateTime? varPubDate, string varMonth, string varYear, string varDay, string varExt1, string varExt2, string varExt3)
        {
            SP_SaleMain item = new SP_SaleMain();
            item.Id = varId;
            item.Customer = varCustomer;
            item.CustomerId = varCustomerId;
            item.TotalPrice = varTotalPrice;
            item.OpeningTime = varOpeningTime;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Month = varMonth;
            item.Year = varYear;
            item.Day = varDay;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varCustomer, string varCustomerId, decimal varTotalPrice, DateTime varOpeningTime, string varAdminId, DateTime? varPubDate, string varMonth, string varYear, string varDay, string varExt1, string varExt2, string varExt3)
        {
            SP_SaleMain item = new SP_SaleMain();
            item.Id = varId;
            item.Customer = varCustomer;
            item.CustomerId = varCustomerId;
            item.TotalPrice = varTotalPrice;
            item.OpeningTime = varOpeningTime;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Month = varMonth;
            item.Year = varYear;
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
        public static TableSchema.TableColumn CustomerColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn CustomerIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn TotalPriceColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn OpeningTimeColumn
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
        public static TableSchema.TableColumn MonthColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn YearColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn DayColumn
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
            public static string Customer = @"Customer";
            public static string CustomerId = @"CustomerId";
            public static string TotalPrice = @"TotalPrice";
            public static string OpeningTime = @"OpeningTime";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string Month = @"Month";
            public static string Year = @"Year";
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
