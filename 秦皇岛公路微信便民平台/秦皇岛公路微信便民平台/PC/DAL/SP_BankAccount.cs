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
    public partial class SP_BankAccountCollection : ActiveList<SP_BankAccount, SP_BankAccountCollection>
    {
        public SP_BankAccountCollection() { }
        public SP_BankAccountCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SP_BankAccount o = this[i];
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
    public partial class SP_BankAccount : ActiveRecord<SP_BankAccount>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public SP_BankAccount()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public SP_BankAccount(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public SP_BankAccount(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public SP_BankAccount(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("SP_BankAccount", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCardNum = new TableSchema.TableColumn(schema);
                colvarCardNum.ColumnName = "CardNum";
                colvarCardNum.DataType = DbType.String;
                colvarCardNum.MaxLength = 50;
                colvarCardNum.AutoIncrement = false;
                colvarCardNum.IsNullable = true;
                colvarCardNum.IsPrimaryKey = false;
                colvarCardNum.IsForeignKey = false;
                colvarCardNum.IsReadOnly = false;
                colvarCardNum.DefaultSetting = @"";
                colvarCardNum.ForeignKeyTableName = "";
                schema.Columns.Add(colvarCardNum);


                TableSchema.TableColumn colvarBankName = new TableSchema.TableColumn(schema);
                colvarBankName.ColumnName = "BankName";
                colvarBankName.DataType = DbType.String;
                colvarBankName.MaxLength = 50;
                colvarBankName.AutoIncrement = false;
                colvarBankName.IsNullable = true;
                colvarBankName.IsPrimaryKey = false;
                colvarBankName.IsForeignKey = false;
                colvarBankName.IsReadOnly = false;
                colvarBankName.DefaultSetting = @"";
                colvarBankName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarBankName);


                TableSchema.TableColumn colvarBalance = new TableSchema.TableColumn(schema);
                colvarBalance.ColumnName = "Balance";
                colvarBalance.DataType = DbType.Decimal;
                colvarBalance.MaxLength = 0;
                colvarBalance.AutoIncrement = false;
                colvarBalance.IsNullable = true;
                colvarBalance.IsPrimaryKey = false;
                colvarBalance.IsForeignKey = false;
                colvarBalance.IsReadOnly = false;
                colvarBalance.DefaultSetting = @"";
                colvarBalance.ForeignKeyTableName = "";
                schema.Columns.Add(colvarBalance);


                TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
                colvarUserId.ColumnName = "UserId";
                colvarUserId.DataType = DbType.String;
                colvarUserId.MaxLength = 50;
                colvarUserId.AutoIncrement = false;
                colvarUserId.IsNullable = true;
                colvarUserId.IsPrimaryKey = false;
                colvarUserId.IsForeignKey = false;
                colvarUserId.IsReadOnly = false;
                colvarUserId.DefaultSetting = @"";
                colvarUserId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUserId);


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
                colvarExt2.MaxLength = 200;
                colvarExt2.AutoIncrement = false;
                colvarExt2.IsNullable = true;
                colvarExt2.IsPrimaryKey = false;
                colvarExt2.IsForeignKey = false;
                colvarExt2.IsReadOnly = false;
                colvarExt2.DefaultSetting = @"";
                colvarExt2.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt2);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("SP_BankAccount", schema);
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
        [DisplayName("卡号")]
        [XmlAttribute("CardNum")]
        [Bindable(true)]
        public string CardNum
        {
            get { return GetColumnValue<string>(Columns.CardNum); }
            set { SetColumnValue(Columns.CardNum, value); }
        }
        [DisplayName("银行名称")]
        [XmlAttribute("BankName")]
        [Bindable(true)]
        public string BankName
        {
            get { return GetColumnValue<string>(Columns.BankName); }
            set { SetColumnValue(Columns.BankName, value); }
        }
        [DisplayName("余额")]
        [XmlAttribute("Balance")]
        [Bindable(true)]
        public decimal? Balance
        {
            get { return GetColumnValue<decimal?>(Columns.Balance); }
            set { SetColumnValue(Columns.Balance, value); }
        }
        [DisplayName("所属人")]
        [XmlAttribute("UserId")]
        [Bindable(true)]
        public string UserId
        {
            get { return GetColumnValue<string>(Columns.UserId); }
            set { SetColumnValue(Columns.UserId, value); }
        }
        [DisplayName("AdminId")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("PubDate")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime? PubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
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
        public static void Insert(string varId, string varCardNum, string varBankName, decimal? varBalance, string varUserId, string varAdminId, DateTime? varPubDate, string varExt1, string varExt2)
        {
            SP_BankAccount item = new SP_BankAccount();
            item.Id = varId;
            item.CardNum = varCardNum;
            item.BankName = varBankName;
            item.Balance = varBalance;
            item.UserId = varUserId;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varCardNum, string varBankName, decimal? varBalance, string varUserId, string varAdminId, DateTime? varPubDate, string varExt1, string varExt2)
        {
            SP_BankAccount item = new SP_BankAccount();
            item.Id = varId;
            item.CardNum = varCardNum;
            item.BankName = varBankName;
            item.Balance = varBalance;
            item.UserId = varUserId;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
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
        public static TableSchema.TableColumn CardNumColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn BankNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn BalanceColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn UserIdColumn
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
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[8]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string CardNum = @"CardNum";
            public static string BankName = @"BankName";
            public static string Balance = @"Balance";
            public static string UserId = @"UserId";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
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
