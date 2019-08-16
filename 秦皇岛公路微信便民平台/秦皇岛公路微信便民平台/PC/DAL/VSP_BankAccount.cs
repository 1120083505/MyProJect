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
    public partial class VSP_BankAccountCollection : ReadOnlyList<VSP_BankAccount, VSP_BankAccountCollection>
    {
        public VSP_BankAccountCollection() { }
    }
    [Serializable]
    public partial class VSP_BankAccount : ReadOnlyRecord<VSP_BankAccount>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("VSP_BankAccount", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarCardNum = new TableSchema.TableColumn(schema);
                colvarCardNum.ColumnName = "CardNum";
                colvarCardNum.DataType = DbType.String;
                colvarCardNum.MaxLength = 50;
                colvarCardNum.AutoIncrement = false;
                colvarCardNum.IsNullable = true;
                colvarCardNum.IsPrimaryKey = false;
                colvarCardNum.IsForeignKey = false;
                colvarCardNum.IsReadOnly = false;
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


                TableSchema.TableColumn colvarExt2 = new TableSchema.TableColumn(schema);
                colvarExt2.ColumnName = "Ext2";
                colvarExt2.DataType = DbType.String;
                colvarExt2.MaxLength = 200;
                colvarExt2.AutoIncrement = false;
                colvarExt2.IsNullable = true;
                colvarExt2.IsPrimaryKey = false;
                colvarExt2.IsForeignKey = false;
                colvarExt2.IsReadOnly = false;
                schema.Columns.Add(colvarExt2);


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


                TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
                colvarUserName.ColumnName = "UserName";
                colvarUserName.DataType = DbType.String;
                colvarUserName.MaxLength = 50;
                colvarUserName.AutoIncrement = false;
                colvarUserName.IsNullable = false;
                colvarUserName.IsPrimaryKey = false;
                colvarUserName.IsForeignKey = false;
                colvarUserName.IsReadOnly = false;
                schema.Columns.Add(colvarUserName);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VSP_BankAccount", schema);
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
        public VSP_BankAccount()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSP_BankAccount(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VSP_BankAccount(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VSP_BankAccount(string columnName, object columnValue)
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
        [XmlAttribute("CardNum")]
        [Bindable(true)]
        public string CardNum
        {
            get { return GetColumnValue<string>(Columns.CardNum); }
            set { SetColumnValue(Columns.CardNum, value); }
        }
        [XmlAttribute("BankName")]
        [Bindable(true)]
        public string BankName
        {
            get { return GetColumnValue<string>(Columns.BankName); }
            set { SetColumnValue(Columns.BankName, value); }
        }
        [XmlAttribute("Balance")]
        [Bindable(true)]
        public decimal? Balance
        {
            get { return GetColumnValue<decimal?>(Columns.Balance); }
            set { SetColumnValue(Columns.Balance, value); }
        }
        [XmlAttribute("UserId")]
        [Bindable(true)]
        public string UserId
        {
            get { return GetColumnValue<string>(Columns.UserId); }
            set { SetColumnValue(Columns.UserId, value); }
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
        [XmlAttribute("Ext2")]
        [Bindable(true)]
        public string Ext2
        {
            get { return GetColumnValue<string>(Columns.Ext2); }
            set { SetColumnValue(Columns.Ext2, value); }
        }
        [XmlAttribute("Ext1")]
        [Bindable(true)]
        public string Ext1
        {
            get { return GetColumnValue<string>(Columns.Ext1); }
            set { SetColumnValue(Columns.Ext1, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [XmlAttribute("UserName")]
        [Bindable(true)]
        public string UserName
        {
            get { return GetColumnValue<string>(Columns.UserName); }
            set { SetColumnValue(Columns.UserName, value); }
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
            public static string Ext2 = @"Ext2";
            public static string Ext1 = @"Ext1";
            public static string RealName = @"RealName";
            public static string UserName = @"UserName";
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
