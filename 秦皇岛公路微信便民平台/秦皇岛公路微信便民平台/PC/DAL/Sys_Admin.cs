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
    public partial class Sys_AdminCollection : ActiveList<Sys_Admin, Sys_AdminCollection>
    {
        public Sys_AdminCollection() { }
        public Sys_AdminCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Admin o = this[i];
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
    public partial class Sys_Admin : ActiveRecord<Sys_Admin>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public Sys_Admin()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Admin(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Admin(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Admin(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Admin", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarLoginName = new TableSchema.TableColumn(schema);
                colvarLoginName.ColumnName = "LoginName";
                colvarLoginName.DataType = DbType.String;
                colvarLoginName.MaxLength = 500;
                colvarLoginName.AutoIncrement = false;
                colvarLoginName.IsNullable = false;
                colvarLoginName.IsPrimaryKey = false;
                colvarLoginName.IsForeignKey = false;
                colvarLoginName.IsReadOnly = false;
                colvarLoginName.DefaultSetting = @"";
                colvarLoginName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLoginName);


                TableSchema.TableColumn colvarLoginPwd = new TableSchema.TableColumn(schema);
                colvarLoginPwd.ColumnName = "LoginPwd";
                colvarLoginPwd.DataType = DbType.String;
                colvarLoginPwd.MaxLength = 50;
                colvarLoginPwd.AutoIncrement = false;
                colvarLoginPwd.IsNullable = false;
                colvarLoginPwd.IsPrimaryKey = false;
                colvarLoginPwd.IsForeignKey = false;
                colvarLoginPwd.IsReadOnly = false;
                colvarLoginPwd.DefaultSetting = @"";
                colvarLoginPwd.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLoginPwd);


                TableSchema.TableColumn colvarRealName = new TableSchema.TableColumn(schema);
                colvarRealName.ColumnName = "RealName";
                colvarRealName.DataType = DbType.String;
                colvarRealName.MaxLength = 50;
                colvarRealName.AutoIncrement = false;
                colvarRealName.IsNullable = false;
                colvarRealName.IsPrimaryKey = false;
                colvarRealName.IsForeignKey = false;
                colvarRealName.IsReadOnly = false;
                colvarRealName.DefaultSetting = @"";
                colvarRealName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRealName);


                TableSchema.TableColumn colvarIsLogin = new TableSchema.TableColumn(schema);
                colvarIsLogin.ColumnName = "IsLogin";
                colvarIsLogin.DataType = DbType.Int32;
                colvarIsLogin.MaxLength = 0;
                colvarIsLogin.AutoIncrement = false;
                colvarIsLogin.IsNullable = false;
                colvarIsLogin.IsPrimaryKey = false;
                colvarIsLogin.IsForeignKey = false;
                colvarIsLogin.IsReadOnly = false;
                colvarIsLogin.DefaultSetting = @"((1))";
                colvarIsLogin.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsLogin);


                TableSchema.TableColumn colvarRoleId = new TableSchema.TableColumn(schema);
                colvarRoleId.ColumnName = "RoleId";
                colvarRoleId.DataType = DbType.String;
                colvarRoleId.MaxLength = 50;
                colvarRoleId.AutoIncrement = false;
                colvarRoleId.IsNullable = false;
                colvarRoleId.IsPrimaryKey = false;
                colvarRoleId.IsForeignKey = false;
                colvarRoleId.IsReadOnly = false;
                colvarRoleId.DefaultSetting = @"";
                colvarRoleId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarRoleId);


                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 50;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = false;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
                colvarEmail.DefaultSetting = @"";
                colvarEmail.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEmail);


                TableSchema.TableColumn colvarPubDate = new TableSchema.TableColumn(schema);
                colvarPubDate.ColumnName = "PubDate";
                colvarPubDate.DataType = DbType.DateTime;
                colvarPubDate.MaxLength = 0;
                colvarPubDate.AutoIncrement = false;
                colvarPubDate.IsNullable = false;
                colvarPubDate.IsPrimaryKey = false;
                colvarPubDate.IsForeignKey = false;
                colvarPubDate.IsReadOnly = false;
                colvarPubDate.DefaultSetting = @"";
                colvarPubDate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPubDate);


                TableSchema.TableColumn colvarIdent = new TableSchema.TableColumn(schema);
                colvarIdent.ColumnName = "Ident";
                colvarIdent.DataType = DbType.Int32;
                colvarIdent.MaxLength = 0;
                colvarIdent.AutoIncrement = false;
                colvarIdent.IsNullable = false;
                colvarIdent.IsPrimaryKey = false;
                colvarIdent.IsForeignKey = false;
                colvarIdent.IsReadOnly = false;
                colvarIdent.DefaultSetting = @"";
                colvarIdent.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIdent);


                TableSchema.TableColumn colvarErrorCount = new TableSchema.TableColumn(schema);
                colvarErrorCount.ColumnName = "ErrorCount";
                colvarErrorCount.DataType = DbType.Int32;
                colvarErrorCount.MaxLength = 0;
                colvarErrorCount.AutoIncrement = false;
                colvarErrorCount.IsNullable = false;
                colvarErrorCount.IsPrimaryKey = false;
                colvarErrorCount.IsForeignKey = false;
                colvarErrorCount.IsReadOnly = false;
                colvarErrorCount.DefaultSetting = @"";
                colvarErrorCount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarErrorCount);


                TableSchema.TableColumn colvarIntime = new TableSchema.TableColumn(schema);
                colvarIntime.ColumnName = "Intime";
                colvarIntime.DataType = DbType.DateTime;
                colvarIntime.MaxLength = 0;
                colvarIntime.AutoIncrement = false;
                colvarIntime.IsNullable = true;
                colvarIntime.IsPrimaryKey = false;
                colvarIntime.IsForeignKey = false;
                colvarIntime.IsReadOnly = false;
                colvarIntime.DefaultSetting = @"";
                colvarIntime.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIntime);


                TableSchema.TableColumn colvarIp = new TableSchema.TableColumn(schema);
                colvarIp.ColumnName = "Ip";
                colvarIp.DataType = DbType.String;
                colvarIp.MaxLength = 50;
                colvarIp.AutoIncrement = false;
                colvarIp.IsNullable = true;
                colvarIp.IsPrimaryKey = false;
                colvarIp.IsForeignKey = false;
                colvarIp.IsReadOnly = false;
                colvarIp.DefaultSetting = @"";
                colvarIp.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIp);


                TableSchema.TableColumn colvarLimitLogin = new TableSchema.TableColumn(schema);
                colvarLimitLogin.ColumnName = "LimitLogin";
                colvarLimitLogin.DataType = DbType.String;
                colvarLimitLogin.MaxLength = 50;
                colvarLimitLogin.AutoIncrement = false;
                colvarLimitLogin.IsNullable = true;
                colvarLimitLogin.IsPrimaryKey = false;
                colvarLimitLogin.IsForeignKey = false;
                colvarLimitLogin.IsReadOnly = false;
                colvarLimitLogin.DefaultSetting = @"";
                colvarLimitLogin.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLimitLogin);


                TableSchema.TableColumn colvarEditPubdate = new TableSchema.TableColumn(schema);
                colvarEditPubdate.ColumnName = "EditPubdate";
                colvarEditPubdate.DataType = DbType.DateTime;
                colvarEditPubdate.MaxLength = 0;
                colvarEditPubdate.AutoIncrement = false;
                colvarEditPubdate.IsNullable = true;
                colvarEditPubdate.IsPrimaryKey = false;
                colvarEditPubdate.IsForeignKey = false;
                colvarEditPubdate.IsReadOnly = false;
                colvarEditPubdate.DefaultSetting = @"";
                colvarEditPubdate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEditPubdate);


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


                TableSchema.TableColumn colvarPowerType = new TableSchema.TableColumn(schema);
                colvarPowerType.ColumnName = "PowerType";
                colvarPowerType.DataType = DbType.Int32;
                colvarPowerType.MaxLength = 0;
                colvarPowerType.AutoIncrement = false;
                colvarPowerType.IsNullable = true;
                colvarPowerType.IsPrimaryKey = false;
                colvarPowerType.IsForeignKey = false;
                colvarPowerType.IsReadOnly = false;
                colvarPowerType.DefaultSetting = @"";
                colvarPowerType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPowerType);


                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 200;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
                colvarAddress.DefaultSetting = @"";
                colvarAddress.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAddress);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Admin", schema);
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
        [DisplayName("登录名称")]
        [XmlAttribute("LoginName")]
        [Bindable(true)]
        public string LoginName
        {
            get { return GetColumnValue<string>(Columns.LoginName); }
            set { SetColumnValue(Columns.LoginName, value); }
        }
        [DisplayName("密码")]
        [XmlAttribute("LoginPwd")]
        [Bindable(true)]
        public string LoginPwd
        {
            get { return GetColumnValue<string>(Columns.LoginPwd); }
            set { SetColumnValue(Columns.LoginPwd, value); }
        }
        [DisplayName("真实姓名")]
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [DisplayName("登陆状态")]
        [XmlAttribute("IsLogin")]
        [Bindable(true)]
        public int IsLogin
        {
            get { return GetColumnValue<int>(Columns.IsLogin); }
            set { SetColumnValue(Columns.IsLogin, value); }
        }
        [DisplayName("角色名称")]
        [XmlAttribute("RoleId")]
        [Bindable(true)]
        public string RoleId
        {
            get { return GetColumnValue<string>(Columns.RoleId); }
            set { SetColumnValue(Columns.RoleId, value); }
        }
        [DisplayName("Email")]
        [XmlAttribute("Email")]
        [Bindable(true)]
        public string Email
        {
            get { return GetColumnValue<string>(Columns.Email); }
            set { SetColumnValue(Columns.Email, value); }
        }
        [DisplayName("PubDate")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [DisplayName("权限分配（0、按角色1、按人）")]
        [XmlAttribute("Ident")]
        [Bindable(true)]
        public int Ident
        {
            get { return GetColumnValue<int>(Columns.Ident); }
            set { SetColumnValue(Columns.Ident, value); }
        }
        [DisplayName("ErrorCount")]
        [XmlAttribute("ErrorCount")]
        [Bindable(true)]
        public int ErrorCount
        {
            get { return GetColumnValue<int>(Columns.ErrorCount); }
            set { SetColumnValue(Columns.ErrorCount, value); }
        }
        [DisplayName("Intime")]
        [XmlAttribute("Intime")]
        [Bindable(true)]
        public DateTime? Intime
        {
            get { return GetColumnValue<DateTime?>(Columns.Intime); }
            set { SetColumnValue(Columns.Intime, value); }
        }
        [DisplayName("Ip")]
        [XmlAttribute("Ip")]
        [Bindable(true)]
        public string Ip
        {
            get { return GetColumnValue<string>(Columns.Ip); }
            set { SetColumnValue(Columns.Ip, value); }
        }
        [DisplayName("限制登陆方式(0、同Ip限制1、错误次数)")]
        [XmlAttribute("LimitLogin")]
        [Bindable(true)]
        public string LimitLogin
        {
            get { return GetColumnValue<string>(Columns.LimitLogin); }
            set { SetColumnValue(Columns.LimitLogin, value); }
        }
        [DisplayName("EditPubdate")]
        [XmlAttribute("EditPubdate")]
        [Bindable(true)]
        public DateTime? EditPubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubdate); }
            set { SetColumnValue(Columns.EditPubdate, value); }
        }
        [DisplayName("EditAdminId")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [DisplayName("PowerType")]
        [XmlAttribute("PowerType")]
        [Bindable(true)]
        public int? PowerType
        {
            get { return GetColumnValue<int?>(Columns.PowerType); }
            set { SetColumnValue(Columns.PowerType, value); }
        }
        [DisplayName("地址")]
        [XmlAttribute("Address")]
        [Bindable(true)]
        public string Address
        {
            get { return GetColumnValue<string>(Columns.Address); }
            set { SetColumnValue(Columns.Address, value); }
        }
        [DisplayName("联系电话")]
        [XmlAttribute("Phone")]
        [Bindable(true)]
        public string Phone
        {
            get { return GetColumnValue<string>(Columns.Phone); }
            set { SetColumnValue(Columns.Phone, value); }
        }
        [DisplayName("BankAccount")]
        [XmlAttribute("BankAccount")]
        [Bindable(true)]
        public string BankAccount
        {
            get { return GetColumnValue<string>(Columns.BankAccount); }
            set { SetColumnValue(Columns.BankAccount, value); }
        }
        #endregion
        #region ObjectDataSource support 
        public static void Insert(string varId, string varLoginName, string varLoginPwd, string varRealName, int varIsLogin, string varRoleId, string varEmail, DateTime varPubDate, int varIdent, int varErrorCount, DateTime? varIntime, string varIp, string varLimitLogin, DateTime? varEditPubdate, string varEditAdminId, int? varPowerType, string varAddress, string varPhone, string varBankAccount)
        {
            Sys_Admin item = new Sys_Admin();
            item.Id = varId;
            item.LoginName = varLoginName;
            item.LoginPwd = varLoginPwd;
            item.RealName = varRealName;
            item.IsLogin = varIsLogin;
            item.RoleId = varRoleId;
            item.Email = varEmail;
            item.PubDate = varPubDate;
            item.Ident = varIdent;
            item.ErrorCount = varErrorCount;
            item.Intime = varIntime;
            item.Ip = varIp;
            item.LimitLogin = varLimitLogin;
            item.EditPubdate = varEditPubdate;
            item.EditAdminId = varEditAdminId;
            item.PowerType = varPowerType;
            item.Address = varAddress;
            item.Phone = varPhone;
            item.BankAccount = varBankAccount;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varLoginName, string varLoginPwd, string varRealName, int varIsLogin, string varRoleId, string varEmail, DateTime varPubDate, int varIdent, int varErrorCount, DateTime? varIntime, string varIp, string varLimitLogin, DateTime? varEditPubdate, string varEditAdminId, int? varPowerType, string varAddress, string varPhone, string varBankAccount)
        {
            Sys_Admin item = new Sys_Admin();
            item.Id = varId;
            item.LoginName = varLoginName;
            item.LoginPwd = varLoginPwd;
            item.RealName = varRealName;
            item.IsLogin = varIsLogin;
            item.RoleId = varRoleId;
            item.Email = varEmail;
            item.PubDate = varPubDate;
            item.Ident = varIdent;
            item.ErrorCount = varErrorCount;
            item.Intime = varIntime;
            item.Ip = varIp;
            item.LimitLogin = varLimitLogin;
            item.EditPubdate = varEditPubdate;
            item.EditAdminId = varEditAdminId;
            item.PowerType = varPowerType;
            item.Address = varAddress;
            item.Phone = varPhone;
            item.BankAccount = varBankAccount;

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
        public static TableSchema.TableColumn LoginNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn LoginPwdColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn RealNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn IsLoginColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn RoleIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn IdentColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn ErrorCountColumn
        {
            get { return Schema.Columns[9]; }
        }
        public static TableSchema.TableColumn IntimeColumn
        {
            get { return Schema.Columns[10]; }
        }
        public static TableSchema.TableColumn IpColumn
        {
            get { return Schema.Columns[11]; }
        }
        public static TableSchema.TableColumn LimitLoginColumn
        {
            get { return Schema.Columns[12]; }
        }
        public static TableSchema.TableColumn EditPubdateColumn
        {
            get { return Schema.Columns[13]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[14]; }
        }
        public static TableSchema.TableColumn PowerTypeColumn
        {
            get { return Schema.Columns[15]; }
        }
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[16]; }
        }
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[17]; }
        }
        public static TableSchema.TableColumn BankAccountColumn
        {
            get { return Schema.Columns[18]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string LoginName = @"LoginName";
            public static string LoginPwd = @"LoginPwd";
            public static string RealName = @"RealName";
            public static string IsLogin = @"IsLogin";
            public static string RoleId = @"RoleId";
            public static string Email = @"Email";
            public static string PubDate = @"PubDate";
            public static string Ident = @"Ident";
            public static string ErrorCount = @"ErrorCount";
            public static string Intime = @"Intime";
            public static string Ip = @"Ip";
            public static string LimitLogin = @"LimitLogin";
            public static string EditPubdate = @"EditPubdate";
            public static string EditAdminId = @"EditAdminId";
            public static string PowerType = @"PowerType";
            public static string Address = @"Address";
            public static string Phone = @"Phone";
            public static string BankAccount = @"BankAccount";
        }
        #endregion
        #region Update PK Collections 
        #endregion
        #region Deep Save 
        #endregion
    }
}
