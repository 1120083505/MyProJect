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
    public partial class Sys_CustodyCollection : ActiveList<Sys_Custody, Sys_CustodyCollection>
    {
        public Sys_CustodyCollection() { }
        public Sys_CustodyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Custody o = this[i];
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
    public partial class Sys_Custody : ActiveRecord<Sys_Custody>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Sys_Custody()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Custody(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Custody(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Custody(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Custody", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarInfoId = new TableSchema.TableColumn(schema);
                colvarInfoId.ColumnName = "InfoId";
                colvarInfoId.DataType = DbType.String;
                colvarInfoId.MaxLength = 50;
                colvarInfoId.AutoIncrement = false;
                colvarInfoId.IsNullable = true;
                colvarInfoId.IsPrimaryKey = false;
                colvarInfoId.IsForeignKey = false;
                colvarInfoId.IsReadOnly = false;
                colvarInfoId.DefaultSetting = @"";
                colvarInfoId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarInfoId);


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


                TableSchema.TableColumn colvarFaxPhone = new TableSchema.TableColumn(schema);
                colvarFaxPhone.ColumnName = "FaxPhone";
                colvarFaxPhone.DataType = DbType.String;
                colvarFaxPhone.MaxLength = 50;
                colvarFaxPhone.AutoIncrement = false;
                colvarFaxPhone.IsNullable = true;
                colvarFaxPhone.IsPrimaryKey = false;
                colvarFaxPhone.IsForeignKey = false;
                colvarFaxPhone.IsReadOnly = false;
                colvarFaxPhone.DefaultSetting = @"";
                colvarFaxPhone.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFaxPhone);


                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 100;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = true;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
                colvarEmail.DefaultSetting = @"";
                colvarEmail.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEmail);


                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 100;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
                colvarAddress.DefaultSetting = @"";
                colvarAddress.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAddress);


                TableSchema.TableColumn colvarGrade = new TableSchema.TableColumn(schema);
                colvarGrade.ColumnName = "Grade";
                colvarGrade.DataType = DbType.String;
                colvarGrade.MaxLength = 50;
                colvarGrade.AutoIncrement = false;
                colvarGrade.IsNullable = true;
                colvarGrade.IsPrimaryKey = false;
                colvarGrade.IsForeignKey = false;
                colvarGrade.IsReadOnly = false;
                colvarGrade.DefaultSetting = @"";
                colvarGrade.ForeignKeyTableName = "";
                schema.Columns.Add(colvarGrade);


                TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
                colvarMemo.ColumnName = "Memo";
                colvarMemo.DataType = DbType.String;
                colvarMemo.MaxLength = 0;
                colvarMemo.AutoIncrement = false;
                colvarMemo.IsNullable = true;
                colvarMemo.IsPrimaryKey = false;
                colvarMemo.IsForeignKey = false;
                colvarMemo.IsReadOnly = false;
                colvarMemo.DefaultSetting = @"";
                colvarMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarMemo);


                TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
                colvarDiscount.ColumnName = "Discount";
                colvarDiscount.DataType = DbType.String;
                colvarDiscount.MaxLength = 50;
                colvarDiscount.AutoIncrement = false;
                colvarDiscount.IsNullable = true;
                colvarDiscount.IsPrimaryKey = false;
                colvarDiscount.IsForeignKey = false;
                colvarDiscount.IsReadOnly = false;
                colvarDiscount.DefaultSetting = @"";
                colvarDiscount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDiscount);


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


                TableSchema.TableColumn colvarEditAdminId = new TableSchema.TableColumn(schema);
                colvarEditAdminId.ColumnName = "EditAdminId";
                colvarEditAdminId.DataType = DbType.String;
                colvarEditAdminId.MaxLength = 50;
                colvarEditAdminId.AutoIncrement = false;
                colvarEditAdminId.IsNullable = true;
                colvarEditAdminId.IsPrimaryKey = false;
                colvarEditAdminId.IsForeignKey = false;
                colvarEditAdminId.IsReadOnly = false;
                colvarEditAdminId.DefaultSetting = @"";
                colvarEditAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEditAdminId);


                TableSchema.TableColumn colvarEditPubDate = new TableSchema.TableColumn(schema);
                colvarEditPubDate.ColumnName = "EditPubDate";
                colvarEditPubDate.DataType = DbType.DateTime;
                colvarEditPubDate.MaxLength = 0;
                colvarEditPubDate.AutoIncrement = false;
                colvarEditPubDate.IsNullable = true;
                colvarEditPubDate.IsPrimaryKey = false;
                colvarEditPubDate.IsForeignKey = false;
                colvarEditPubDate.IsReadOnly = false;
                colvarEditPubDate.DefaultSetting = @"";
                colvarEditPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEditPubDate);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Custody", schema);
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
        [DisplayName("单位名称")]
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }
        [DisplayName("负责人姓名")]
        [XmlAttribute("InfoId")]
        [Bindable(true)]
        public string InfoId
        {
            get { return GetColumnValue<string>(Columns.InfoId); }
            set { SetColumnValue(Columns.InfoId, value); }
        }
        [DisplayName("联系电话")]
        [XmlAttribute("Phone")]
        [Bindable(true)]
        public string Phone
        {
            get { return GetColumnValue<string>(Columns.Phone); }
            set { SetColumnValue(Columns.Phone, value); }
        }
        [DisplayName("传真电话")]
        [XmlAttribute("FaxPhone")]
        [Bindable(true)]
        public string FaxPhone
        {
            get { return GetColumnValue<string>(Columns.FaxPhone); }
            set { SetColumnValue(Columns.FaxPhone, value); }
        }
        [DisplayName("Email")]
        [XmlAttribute("Email")]
        [Bindable(true)]
        public string Email
        {
            get { return GetColumnValue<string>(Columns.Email); }
            set { SetColumnValue(Columns.Email, value); }
        }
        [DisplayName("单位地址")]
        [XmlAttribute("Address")]
        [Bindable(true)]
        public string Address
        {
            get { return GetColumnValue<string>(Columns.Address); }
            set { SetColumnValue(Columns.Address, value); }
        }
        [DisplayName("Grade")]
        [XmlAttribute("Grade")]
        [Bindable(true)]
        public string Grade
        {
            get { return GetColumnValue<string>(Columns.Grade); }
            set { SetColumnValue(Columns.Grade, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("折扣")]
        [XmlAttribute("Discount")]
        [Bindable(true)]
        public string Discount
        {
            get { return GetColumnValue<string>(Columns.Discount); }
            set { SetColumnValue(Columns.Discount, value); }
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
        [DisplayName("最后修改人")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [DisplayName("最后修改时间")]
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, string varName, string varInfoId, string varPhone, string varFaxPhone, string varEmail, string varAddress, string varGrade, string varMemo, string varDiscount, string varAdminId, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Sys_Custody item = new Sys_Custody();
            item.Id = varId;
            item.Name = varName;
            item.InfoId = varInfoId;
            item.Phone = varPhone;
            item.FaxPhone = varFaxPhone;
            item.Email = varEmail;
            item.Address = varAddress;
            item.Grade = varGrade;
            item.Memo = varMemo;
            item.Discount = varDiscount;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varName, string varInfoId, string varPhone, string varFaxPhone, string varEmail, string varAddress, string varGrade, string varMemo, string varDiscount, string varAdminId, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Sys_Custody item = new Sys_Custody();
            item.Id = varId;
            item.Name = varName;
            item.InfoId = varInfoId;
            item.Phone = varPhone;
            item.FaxPhone = varFaxPhone;
            item.Email = varEmail;
            item.Address = varAddress;
            item.Grade = varGrade;
            item.Memo = varMemo;
            item.Discount = varDiscount;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;

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
        public static TableSchema.TableColumn InfoIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn FaxPhoneColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn GradeColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn DiscountColumn
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
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[12]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[13]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Name = @"Name";
            public static string InfoId = @"InfoId";
            public static string Phone = @"Phone";
            public static string FaxPhone = @"FaxPhone";
            public static string Email = @"Email";
            public static string Address = @"Address";
            public static string Grade = @"Grade";
            public static string Memo = @"Memo";
            public static string Discount = @"Discount";
            public static string AdminId = @"AdminId";
            public static string PubDate = @"PubDate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
