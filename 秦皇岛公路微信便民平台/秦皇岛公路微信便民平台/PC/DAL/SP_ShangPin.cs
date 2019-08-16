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
    public partial class SP_ShangPinCollection : ActiveList<SP_ShangPin, SP_ShangPinCollection>
    {
        public SP_ShangPinCollection() { }
        public SP_ShangPinCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SP_ShangPin o = this[i];
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
    public partial class SP_ShangPin : ActiveRecord<SP_ShangPin>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public SP_ShangPin()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public SP_ShangPin(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public SP_ShangPin(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public SP_ShangPin(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("SP_ShangPin", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarWareName = new TableSchema.TableColumn(schema);
                colvarWareName.ColumnName = "WareName";
                colvarWareName.DataType = DbType.String;
                colvarWareName.MaxLength = 50;
                colvarWareName.AutoIncrement = false;
                colvarWareName.IsNullable = true;
                colvarWareName.IsPrimaryKey = false;
                colvarWareName.IsForeignKey = false;
                colvarWareName.IsReadOnly = false;
                colvarWareName.DefaultSetting = @"";
                colvarWareName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarWareName);


                TableSchema.TableColumn colvarWareType = new TableSchema.TableColumn(schema);
                colvarWareType.ColumnName = "WareType";
                colvarWareType.DataType = DbType.String;
                colvarWareType.MaxLength = 50;
                colvarWareType.AutoIncrement = false;
                colvarWareType.IsNullable = true;
                colvarWareType.IsPrimaryKey = false;
                colvarWareType.IsForeignKey = false;
                colvarWareType.IsReadOnly = false;
                colvarWareType.DefaultSetting = @"";
                colvarWareType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarWareType);


                TableSchema.TableColumn colvarWarePrice = new TableSchema.TableColumn(schema);
                colvarWarePrice.ColumnName = "WarePrice";
                colvarWarePrice.DataType = DbType.Decimal;
                colvarWarePrice.MaxLength = 0;
                colvarWarePrice.AutoIncrement = false;
                colvarWarePrice.IsNullable = true;
                colvarWarePrice.IsPrimaryKey = false;
                colvarWarePrice.IsForeignKey = false;
                colvarWarePrice.IsReadOnly = false;
                colvarWarePrice.DefaultSetting = @"";
                colvarWarePrice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarWarePrice);


                TableSchema.TableColumn colvarSpecifications = new TableSchema.TableColumn(schema);
                colvarSpecifications.ColumnName = "Specifications";
                colvarSpecifications.DataType = DbType.String;
                colvarSpecifications.MaxLength = 50;
                colvarSpecifications.AutoIncrement = false;
                colvarSpecifications.IsNullable = true;
                colvarSpecifications.IsPrimaryKey = false;
                colvarSpecifications.IsForeignKey = false;
                colvarSpecifications.IsReadOnly = false;
                colvarSpecifications.DefaultSetting = @"";
                colvarSpecifications.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSpecifications);


                TableSchema.TableColumn colvarSellingPrice = new TableSchema.TableColumn(schema);
                colvarSellingPrice.ColumnName = "SellingPrice";
                colvarSellingPrice.DataType = DbType.Decimal;
                colvarSellingPrice.MaxLength = 0;
                colvarSellingPrice.AutoIncrement = false;
                colvarSellingPrice.IsNullable = true;
                colvarSellingPrice.IsPrimaryKey = false;
                colvarSellingPrice.IsForeignKey = false;
                colvarSellingPrice.IsReadOnly = false;
                colvarSellingPrice.DefaultSetting = @"";
                colvarSellingPrice.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSellingPrice);


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


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 50;
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
                colvarAdminId.IsNullable = true;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                colvarAdminId.DefaultSetting = @"";
                colvarAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAdminId);


                TableSchema.TableColumn colvarPubdate = new TableSchema.TableColumn(schema);
                colvarPubdate.ColumnName = "Pubdate";
                colvarPubdate.DataType = DbType.DateTime;
                colvarPubdate.MaxLength = 0;
                colvarPubdate.AutoIncrement = false;
                colvarPubdate.IsNullable = true;
                colvarPubdate.IsPrimaryKey = false;
                colvarPubdate.IsForeignKey = false;
                colvarPubdate.IsReadOnly = false;
                colvarPubdate.DefaultSetting = @"";
                colvarPubdate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubdate);


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
                DataService.Providers["ZrCon"].AddSchema("SP_ShangPin", schema);
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
        [DisplayName("商品名称")]
        [XmlAttribute("WareName")]
        [Bindable(true)]
        public string WareName
        {
            get { return GetColumnValue<string>(Columns.WareName); }
            set { SetColumnValue(Columns.WareName, value); }
        }
        [DisplayName("商品类型")]
        [XmlAttribute("WareType")]
        [Bindable(true)]
        public string WareType
        {
            get { return GetColumnValue<string>(Columns.WareType); }
            set { SetColumnValue(Columns.WareType, value); }
        }
        [DisplayName("进货价")]
        [XmlAttribute("WarePrice")]
        [Bindable(true)]
        public decimal? WarePrice
        {
            get { return GetColumnValue<decimal?>(Columns.WarePrice); }
            set { SetColumnValue(Columns.WarePrice, value); }
        }
        [DisplayName("规格型号")]
        [XmlAttribute("Specifications")]
        [Bindable(true)]
        public string Specifications
        {
            get { return GetColumnValue<string>(Columns.Specifications); }
            set { SetColumnValue(Columns.Specifications, value); }
        }
        [DisplayName("销售价")]
        [XmlAttribute("SellingPrice")]
        [Bindable(true)]
        public decimal? SellingPrice
        {
            get { return GetColumnValue<decimal?>(Columns.SellingPrice); }
            set { SetColumnValue(Columns.SellingPrice, value); }
        }
        [DisplayName("所属仓库")]
        [XmlAttribute("Warehouse")]
        [Bindable(true)]
        public string Warehouse
        {
            get { return GetColumnValue<string>(Columns.Warehouse); }
            set { SetColumnValue(Columns.Warehouse, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("AdminId")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("Pubdate")]
        [XmlAttribute("Pubdate")]
        [Bindable(true)]
        public DateTime? Pubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.Pubdate); }
            set { SetColumnValue(Columns.Pubdate, value); }
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
        public static void Insert(string varId, string varWareName, string varWareType, decimal? varWarePrice, string varSpecifications, decimal? varSellingPrice, string varWarehouse, string varMemo, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            SP_ShangPin item = new SP_ShangPin();
            item.Id = varId;
            item.WareName = varWareName;
            item.WareType = varWareType;
            item.WarePrice = varWarePrice;
            item.Specifications = varSpecifications;
            item.SellingPrice = varSellingPrice;
            item.Warehouse = varWarehouse;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varWareName, string varWareType, decimal? varWarePrice, string varSpecifications, decimal? varSellingPrice, string varWarehouse, string varMemo, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            SP_ShangPin item = new SP_ShangPin();
            item.Id = varId;
            item.WareName = varWareName;
            item.WareType = varWareType;
            item.WarePrice = varWarePrice;
            item.Specifications = varSpecifications;
            item.SellingPrice = varSellingPrice;
            item.Warehouse = varWarehouse;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
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
        public static TableSchema.TableColumn WareNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn WareTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn WarePriceColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn SpecificationsColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn SellingPriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn WarehouseColumn
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
        public static TableSchema.TableColumn PubdateColumn
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
            public static string WareName = @"WareName";
            public static string WareType = @"WareType";
            public static string WarePrice = @"WarePrice";
            public static string Specifications = @"Specifications";
            public static string SellingPrice = @"SellingPrice";
            public static string Warehouse = @"Warehouse";
            public static string Memo = @"Memo";
            public static string AdminId = @"AdminId";
            public static string Pubdate = @"Pubdate";
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
