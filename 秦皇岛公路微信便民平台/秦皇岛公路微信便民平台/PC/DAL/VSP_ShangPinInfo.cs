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
    public partial class VSP_ShangPinInfoCollection : ReadOnlyList<VSP_ShangPinInfo, VSP_ShangPinInfoCollection>
    {
        public VSP_ShangPinInfoCollection() { }
    }
    [Serializable]
    public partial class VSP_ShangPinInfo : ReadOnlyRecord<VSP_ShangPinInfo>, IReadOnlyRecord
    {

        #region Default Settings 
        protected static void SetSQLProps()
        {
            GetTableSchema();
        }
        #endregion
        #region Schema Accessor 
        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("VSP_ShangPinInfo", TableType.View, DataService.GetInstance("ZrCon"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns


                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "Id";
                colvarId.DataType = DbType.String;
                colvarId.MaxLength = 50;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
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
                schema.Columns.Add(colvarExt3);


                TableSchema.TableColumn colvarTotalPrice = new TableSchema.TableColumn(schema);
                colvarTotalPrice.ColumnName = "TotalPrice";
                colvarTotalPrice.DataType = DbType.Decimal;
                colvarTotalPrice.MaxLength = 0;
                colvarTotalPrice.AutoIncrement = false;
                colvarTotalPrice.IsNullable = true;
                colvarTotalPrice.IsPrimaryKey = false;
                colvarTotalPrice.IsForeignKey = false;
                colvarTotalPrice.IsReadOnly = false;
                schema.Columns.Add(colvarTotalPrice);


                TableSchema.TableColumn colvarOpeningTime = new TableSchema.TableColumn(schema);
                colvarOpeningTime.ColumnName = "OpeningTime";
                colvarOpeningTime.DataType = DbType.DateTime;
                colvarOpeningTime.MaxLength = 0;
                colvarOpeningTime.AutoIncrement = false;
                colvarOpeningTime.IsNullable = true;
                colvarOpeningTime.IsPrimaryKey = false;
                colvarOpeningTime.IsForeignKey = false;
                colvarOpeningTime.IsReadOnly = false;
                schema.Columns.Add(colvarOpeningTime);


                TableSchema.TableColumn colvarWareName = new TableSchema.TableColumn(schema);
                colvarWareName.ColumnName = "WareName";
                colvarWareName.DataType = DbType.String;
                colvarWareName.MaxLength = 50;
                colvarWareName.AutoIncrement = false;
                colvarWareName.IsNullable = true;
                colvarWareName.IsPrimaryKey = false;
                colvarWareName.IsForeignKey = false;
                colvarWareName.IsReadOnly = false;
                schema.Columns.Add(colvarWareName);


                TableSchema.TableColumn colvarCustomerName = new TableSchema.TableColumn(schema);
                colvarCustomerName.ColumnName = "CustomerName";
                colvarCustomerName.DataType = DbType.String;
                colvarCustomerName.MaxLength = 50;
                colvarCustomerName.AutoIncrement = false;
                colvarCustomerName.IsNullable = true;
                colvarCustomerName.IsPrimaryKey = false;
                colvarCustomerName.IsForeignKey = false;
                colvarCustomerName.IsReadOnly = false;
                schema.Columns.Add(colvarCustomerName);


                TableSchema.TableColumn colvarRealName = new TableSchema.TableColumn(schema);
                colvarRealName.ColumnName = "RealName";
                colvarRealName.DataType = DbType.String;
                colvarRealName.MaxLength = 50;
                colvarRealName.AutoIncrement = false;
                colvarRealName.IsNullable = true;
                colvarRealName.IsPrimaryKey = false;
                colvarRealName.IsForeignKey = false;
                colvarRealName.IsReadOnly = false;
                schema.Columns.Add(colvarRealName);


                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.String;
                colvarName.MaxLength = 50;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = true;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                schema.Columns.Add(colvarName);


                TableSchema.TableColumn colvarYear = new TableSchema.TableColumn(schema);
                colvarYear.ColumnName = "Year";
                colvarYear.DataType = DbType.String;
                colvarYear.MaxLength = 20;
                colvarYear.AutoIncrement = false;
                colvarYear.IsNullable = true;
                colvarYear.IsPrimaryKey = false;
                colvarYear.IsForeignKey = false;
                colvarYear.IsReadOnly = false;
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
                schema.Columns.Add(colvarDay);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VSP_ShangPinInfo", schema);
            }
        }
        #endregion
        #region Query Accessor 
        public static Query CreateQuery()
        {
            return new Query(Schema);
        }
        #endregion
        #region .ctors 
        public VSP_ShangPinInfo()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSP_ShangPinInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VSP_ShangPinInfo(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VSP_ShangPinInfo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName, columnValue);
        }

        #endregion
        #region Props 
        [XmlAttribute("Id")]
        [Bindable(true)]
        public string Id
        {
            get { return GetColumnValue<string>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }
        [XmlAttribute("MainId")]
        [Bindable(true)]
        public string MainId
        {
            get { return GetColumnValue<string>(Columns.MainId); }
            set { SetColumnValue(Columns.MainId, value); }
        }
        [XmlAttribute("FormId")]
        [Bindable(true)]
        public string FormId
        {
            get { return GetColumnValue<string>(Columns.FormId); }
            set { SetColumnValue(Columns.FormId, value); }
        }
        [XmlAttribute("Iswarehouse")]
        [Bindable(true)]
        public int? Iswarehouse
        {
            get { return GetColumnValue<int?>(Columns.Iswarehouse); }
            set { SetColumnValue(Columns.Iswarehouse, value); }
        }
        [XmlAttribute("Num")]
        [Bindable(true)]
        public decimal? Num
        {
            get { return GetColumnValue<decimal?>(Columns.Num); }
            set { SetColumnValue(Columns.Num, value); }
        }
        [XmlAttribute("Price")]
        [Bindable(true)]
        public decimal? Price
        {
            get { return GetColumnValue<decimal?>(Columns.Price); }
            set { SetColumnValue(Columns.Price, value); }
        }
        [XmlAttribute("SumPrice")]
        [Bindable(true)]
        public decimal? SumPrice
        {
            get { return GetColumnValue<decimal?>(Columns.SumPrice); }
            set { SetColumnValue(Columns.SumPrice, value); }
        }
        [XmlAttribute("Warehouse")]
        [Bindable(true)]
        public string Warehouse
        {
            get { return GetColumnValue<string>(Columns.Warehouse); }
            set { SetColumnValue(Columns.Warehouse, value); }
        }
        [XmlAttribute("Customer")]
        [Bindable(true)]
        public string Customer
        {
            get { return GetColumnValue<string>(Columns.Customer); }
            set { SetColumnValue(Columns.Customer, value); }
        }
        [XmlAttribute("CustomerId")]
        [Bindable(true)]
        public string CustomerId
        {
            get { return GetColumnValue<string>(Columns.CustomerId); }
            set { SetColumnValue(Columns.CustomerId, value); }
        }
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime? PubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [XmlAttribute("Ext1")]
        [Bindable(true)]
        public string Ext1
        {
            get { return GetColumnValue<string>(Columns.Ext1); }
            set { SetColumnValue(Columns.Ext1, value); }
        }
        [XmlAttribute("Ext2")]
        [Bindable(true)]
        public string Ext2
        {
            get { return GetColumnValue<string>(Columns.Ext2); }
            set { SetColumnValue(Columns.Ext2, value); }
        }
        [XmlAttribute("Ext3")]
        [Bindable(true)]
        public string Ext3
        {
            get { return GetColumnValue<string>(Columns.Ext3); }
            set { SetColumnValue(Columns.Ext3, value); }
        }
        [XmlAttribute("TotalPrice")]
        [Bindable(true)]
        public decimal? TotalPrice
        {
            get { return GetColumnValue<decimal?>(Columns.TotalPrice); }
            set { SetColumnValue(Columns.TotalPrice, value); }
        }
        [XmlAttribute("OpeningTime")]
        [Bindable(true)]
        public DateTime? OpeningTime
        {
            get { return GetColumnValue<DateTime?>(Columns.OpeningTime); }
            set { SetColumnValue(Columns.OpeningTime, value); }
        }
        [XmlAttribute("WareName")]
        [Bindable(true)]
        public string WareName
        {
            get { return GetColumnValue<string>(Columns.WareName); }
            set { SetColumnValue(Columns.WareName, value); }
        }
        [XmlAttribute("CustomerName")]
        [Bindable(true)]
        public string CustomerName
        {
            get { return GetColumnValue<string>(Columns.CustomerName); }
            set { SetColumnValue(Columns.CustomerName, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [XmlAttribute("Year")]
        [Bindable(true)]
        public string Year
        {
            get { return GetColumnValue<string>(Columns.Year); }
            set { SetColumnValue(Columns.Year, value); }
        }
        [XmlAttribute("Month")]
        [Bindable(true)]
        public string Month
        {
            get { return GetColumnValue<string>(Columns.Month); }
            set { SetColumnValue(Columns.Month, value); }
        }
        [XmlAttribute("Day")]
        [Bindable(true)]
        public string Day
        {
            get { return GetColumnValue<string>(Columns.Day); }
            set { SetColumnValue(Columns.Day, value); }
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
            public static string Ext1 = @"Ext1";
            public static string Ext2 = @"Ext2";
            public static string Ext3 = @"Ext3";
            public static string TotalPrice = @"TotalPrice";
            public static string OpeningTime = @"OpeningTime";
            public static string WareName = @"WareName";
            public static string CustomerName = @"CustomerName";
            public static string RealName = @"RealName";
            public static string Name = @"Name";
            public static string Year = @"Year";
            public static string Month = @"Month";
            public static string Day = @"Day";
        }
        #endregion
        #region IAbstractRecord Members 
        public new CT GetColumnValue<CT>(string columnName)
        {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName)
        {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion

    }
}
