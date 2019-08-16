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
    public partial class CK_WarehouseCollection : ActiveList<CK_Warehouse, CK_WarehouseCollection>
    {
        public CK_WarehouseCollection() { }
        public CK_WarehouseCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CK_Warehouse o = this[i];
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
    public partial class CK_Warehouse : ActiveRecord<CK_Warehouse>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public CK_Warehouse()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public CK_Warehouse(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public CK_Warehouse(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public CK_Warehouse(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("CK_Warehouse", TableType.Table, DataService.GetInstance("ZrCon"));
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
                colvarName.IsNullable = true;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                colvarName.DefaultSetting = @"";
                colvarName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarName);


                TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
                colvarArea.ColumnName = "Area";
                colvarArea.DataType = DbType.Decimal;
                colvarArea.MaxLength = 0;
                colvarArea.AutoIncrement = false;
                colvarArea.IsNullable = true;
                colvarArea.IsPrimaryKey = false;
                colvarArea.IsForeignKey = false;
                colvarArea.IsReadOnly = false;
                colvarArea.DefaultSetting = @"";
                colvarArea.ForeignKeyTableName = "";
                schema.Columns.Add(colvarArea);


                TableSchema.TableColumn colvarArdess = new TableSchema.TableColumn(schema);
                colvarArdess.ColumnName = "Ardess";
                colvarArdess.DataType = DbType.String;
                colvarArdess.MaxLength = 50;
                colvarArdess.AutoIncrement = false;
                colvarArdess.IsNullable = true;
                colvarArdess.IsPrimaryKey = false;
                colvarArdess.IsForeignKey = false;
                colvarArdess.IsReadOnly = false;
                colvarArdess.DefaultSetting = @"";
                colvarArdess.ForeignKeyTableName = "";
                schema.Columns.Add(colvarArdess);


                TableSchema.TableColumn colvarStock = new TableSchema.TableColumn(schema);
                colvarStock.ColumnName = "Stock";
                colvarStock.DataType = DbType.String;
                colvarStock.MaxLength = 50;
                colvarStock.AutoIncrement = false;
                colvarStock.IsNullable = true;
                colvarStock.IsPrimaryKey = false;
                colvarStock.IsForeignKey = false;
                colvarStock.IsReadOnly = false;
                colvarStock.DefaultSetting = @"";
                colvarStock.ForeignKeyTableName = "";
                schema.Columns.Add(colvarStock);


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
                colvarExt3.MaxLength = 500;
                colvarExt3.AutoIncrement = false;
                colvarExt3.IsNullable = true;
                colvarExt3.IsPrimaryKey = false;
                colvarExt3.IsForeignKey = false;
                colvarExt3.IsReadOnly = false;
                colvarExt3.DefaultSetting = @"";
                colvarExt3.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt3);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("CK_Warehouse", schema);
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
        [DisplayName("仓库名称")]
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [DisplayName("面积")]
        [XmlAttribute("Area")]
        [Bindable(true)]
        public decimal? Area
        {
            get { return GetColumnValue<decimal?>(Columns.Area); }
            set { SetColumnValue(Columns.Area, value); }
        }
        [DisplayName("地址")]
        [XmlAttribute("Ardess")]
        [Bindable(true)]
        public string Ardess
        {
            get { return GetColumnValue<string>(Columns.Ardess); }
            set { SetColumnValue(Columns.Ardess, value); }
        }
        [DisplayName("库存")]
        [XmlAttribute("Stock")]
        [Bindable(true)]
        public string Stock
        {
            get { return GetColumnValue<string>(Columns.Stock); }
            set { SetColumnValue(Columns.Stock, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
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
        public static void Insert(string varId, string varName, decimal? varArea, string varArdess, string varStock, string varMemo, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            CK_Warehouse item = new CK_Warehouse();
            item.Id = varId;
            item.Name = varName;
            item.Area = varArea;
            item.Ardess = varArdess;
            item.Stock = varStock;
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
        public static void Update(string varId, string varName, decimal? varArea, string varArdess, string varStock, string varMemo, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            CK_Warehouse item = new CK_Warehouse();
            item.Id = varId;
            item.Name = varName;
            item.Area = varArea;
            item.Ardess = varArdess;
            item.Stock = varStock;
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
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn ArdessColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn StockColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn PubdateColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[10]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Name = @"Name";
            public static string Area = @"Area";
            public static string Ardess = @"Ardess";
            public static string Stock = @"Stock";
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
