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
    public partial class SP_CustomerCollection : ActiveList<SP_Customer, SP_CustomerCollection>
    {
        public SP_CustomerCollection() { }
        public SP_CustomerCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SP_Customer o = this[i];
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
    public partial class SP_Customer : ActiveRecord<SP_Customer>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public SP_Customer()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public SP_Customer(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public SP_Customer(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public SP_Customer(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("SP_Customer", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCustomerName = new TableSchema.TableColumn(schema);
                colvarCustomerName.ColumnName = "CustomerName";
                colvarCustomerName.DataType = DbType.String;
                colvarCustomerName.MaxLength = 50;
                colvarCustomerName.AutoIncrement = false;
                colvarCustomerName.IsNullable = true;
                colvarCustomerName.IsPrimaryKey = false;
                colvarCustomerName.IsForeignKey = false;
                colvarCustomerName.IsReadOnly = false;
                colvarCustomerName.DefaultSetting = @"";
                colvarCustomerName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCustomerName);


                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 50;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                colvarPhone.DefaultSetting = @"";
                colvarPhone.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPhone);


                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 50;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
                colvarAddress.DefaultSetting = @"";
                colvarAddress.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAddress);


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


                TableSchema.TableColumn colvarBankAccount = new TableSchema.TableColumn(schema);
                colvarBankAccount.ColumnName = "BankAccount";
                colvarBankAccount.DataType = DbType.String;
                colvarBankAccount.MaxLength = 50;
                colvarBankAccount.AutoIncrement = false;
                colvarBankAccount.IsNullable = true;
                colvarBankAccount.IsPrimaryKey = false;
                colvarBankAccount.IsForeignKey = false;
                colvarBankAccount.IsReadOnly = false;
                colvarBankAccount.DefaultSetting = @"";
                colvarBankAccount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarBankAccount);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("SP_Customer", schema);
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
        [DisplayName("客户名称")]
        [XmlAttribute("CustomerName")]
        [Bindable(true)]
        public string CustomerName
        {
            get { return GetColumnValue<string>(Columns.CustomerName); }
            set { SetColumnValue(Columns.CustomerName, value); }
        }
        [DisplayName("联系电话")]
        [XmlAttribute("Phone")]
        [Bindable(true)]
        public string Phone
        {
            get { return GetColumnValue<string>(Columns.Phone); }
            set { SetColumnValue(Columns.Phone, value); }
        }
        [DisplayName("地址")]
        [XmlAttribute("Address")]
        [Bindable(true)]
        public string Address
        {
            get { return GetColumnValue<string>(Columns.Address); }
            set { SetColumnValue(Columns.Address, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("银行账户")]
        [XmlAttribute("BankAccount")]
        [Bindable(true)]
        public string BankAccount
        {
            get { return GetColumnValue<string>(Columns.BankAccount); }
            set { SetColumnValue(Columns.BankAccount, value); }
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
        #endregion
        #region ObjectDataSource support 
        public static void Insert(string varId, string varCustomerName, string varPhone, string varAddress, string varMemo, string varBankAccount, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2)
        {
            SP_Customer item = new SP_Customer();
            item.Id = varId;
            item.CustomerName = varCustomerName;
            item.Phone = varPhone;
            item.Address = varAddress;
            item.Memo = varMemo;
            item.BankAccount = varBankAccount;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varCustomerName, string varPhone, string varAddress, string varMemo, string varBankAccount, string varAdminId, DateTime? varPubdate, string varExt1, string varExt2)
        {
            SP_Customer item = new SP_Customer();
            item.Id = varId;
            item.CustomerName = varCustomerName;
            item.Phone = varPhone;
            item.Address = varAddress;
            item.Memo = varMemo;
            item.BankAccount = varBankAccount;
            item.AdminId = varAdminId;
            item.Pubdate = varPubdate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;

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
        public static TableSchema.TableColumn CustomerNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn BankAccountColumn
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
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string CustomerName = @"CustomerName";
            public static string Phone = @"Phone";
            public static string Address = @"Address";
            public static string Memo = @"Memo";
            public static string BankAccount = @"BankAccount";
            public static string AdminId = @"AdminId";
            public static string Pubdate = @"Pubdate";
            public static string Ext1 = @"Ext1";
            public static string Ext2 = @"Ext2";
        }
        #endregion
        #region Update PK Collections 
        #endregion
        #region Deep Save 
        #endregion
    }
}
