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
    public partial class VSP_ShangPinCollection : ReadOnlyList<VSP_ShangPin, VSP_ShangPinCollection>
    {
        public VSP_ShangPinCollection() { }
    }
    [Serializable]
    public partial class VSP_ShangPin : ReadOnlyRecord<VSP_ShangPin>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("VSP_ShangPin", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarWareType = new TableSchema.TableColumn(schema);
                colvarWareType.ColumnName = "WareType";
                colvarWareType.DataType = DbType.String;
                colvarWareType.MaxLength = 50;
                colvarWareType.AutoIncrement = false;
                colvarWareType.IsNullable = true;
                colvarWareType.IsPrimaryKey = false;
                colvarWareType.IsForeignKey = false;
                colvarWareType.IsReadOnly = false;
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


                TableSchema.TableColumn colvarRealName = new TableSchema.TableColumn(schema);
                colvarRealName.ColumnName = "RealName";
                colvarRealName.DataType = DbType.String;
                colvarRealName.MaxLength = 50;
                colvarRealName.AutoIncrement = false;
                colvarRealName.IsNullable = false;
                colvarRealName.IsPrimaryKey = false;
                colvarRealName.IsForeignKey = false;
                colvarRealName.IsReadOnly = false;
                schema.Columns.Add(colvarRealName);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VSP_ShangPin", schema);
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
        public VSP_ShangPin()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSP_ShangPin(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VSP_ShangPin(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VSP_ShangPin(string columnName, object columnValue)
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
        [XmlAttribute("WareName")]
        [Bindable(true)]
        public string WareName
        {
            get { return GetColumnValue<string>(Columns.WareName); }
            set { SetColumnValue(Columns.WareName, value); }
        }
        [XmlAttribute("WareType")]
        [Bindable(true)]
        public string WareType
        {
            get { return GetColumnValue<string>(Columns.WareType); }
            set { SetColumnValue(Columns.WareType, value); }
        }
        [XmlAttribute("WarePrice")]
        [Bindable(true)]
        public decimal? WarePrice
        {
            get { return GetColumnValue<decimal?>(Columns.WarePrice); }
            set { SetColumnValue(Columns.WarePrice, value); }
        }
        [XmlAttribute("Specifications")]
        [Bindable(true)]
        public string Specifications
        {
            get { return GetColumnValue<string>(Columns.Specifications); }
            set { SetColumnValue(Columns.Specifications, value); }
        }
        [XmlAttribute("SellingPrice")]
        [Bindable(true)]
        public decimal? SellingPrice
        {
            get { return GetColumnValue<decimal?>(Columns.SellingPrice); }
            set { SetColumnValue(Columns.SellingPrice, value); }
        }
        [XmlAttribute("Warehouse")]
        [Bindable(true)]
        public string Warehouse
        {
            get { return GetColumnValue<string>(Columns.Warehouse); }
            set { SetColumnValue(Columns.Warehouse, value); }
        }
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [XmlAttribute("Pubdate")]
        [Bindable(true)]
        public DateTime? Pubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.Pubdate); }
            set { SetColumnValue(Columns.Pubdate, value); }
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
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [XmlAttribute("Ext3")]
        [Bindable(true)]
        public string Ext3
        {
            get { return GetColumnValue<string>(Columns.Ext3); }
            set { SetColumnValue(Columns.Ext3, value); }
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
            public static string Name = @"Name";
            public static string RealName = @"RealName";
            public static string Ext3 = @"Ext3";
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
