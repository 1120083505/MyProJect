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
    public partial class VSys_AdminCollection : ReadOnlyList<VSys_Admin, VSys_AdminCollection>
    {
        public VSys_AdminCollection() { }
    }
    [Serializable]
    public partial class VSys_Admin : ReadOnlyRecord<VSys_Admin>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("VSys_Admin", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarLoginName = new TableSchema.TableColumn(schema);
                colvarLoginName.ColumnName = "LoginName";
                colvarLoginName.DataType = DbType.String;
                colvarLoginName.MaxLength = 500;
                colvarLoginName.AutoIncrement = false;
                colvarLoginName.IsNullable = false;
                colvarLoginName.IsPrimaryKey = false;
                colvarLoginName.IsForeignKey = false;
                colvarLoginName.IsReadOnly = false;
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
                schema.Columns.Add(colvarIsLogin);


                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 50;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = false;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
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
                schema.Columns.Add(colvarPubDate);


                TableSchema.TableColumn colvarRoleName = new TableSchema.TableColumn(schema);
                colvarRoleName.ColumnName = "RoleName";
                colvarRoleName.DataType = DbType.String;
                colvarRoleName.MaxLength = 50;
                colvarRoleName.AutoIncrement = false;
                colvarRoleName.IsNullable = false;
                colvarRoleName.IsPrimaryKey = false;
                colvarRoleName.IsForeignKey = false;
                colvarRoleName.IsReadOnly = false;
                schema.Columns.Add(colvarRoleName);


                TableSchema.TableColumn colvarRoleId = new TableSchema.TableColumn(schema);
                colvarRoleId.ColumnName = "RoleId";
                colvarRoleId.DataType = DbType.String;
                colvarRoleId.MaxLength = 50;
                colvarRoleId.AutoIncrement = false;
                colvarRoleId.IsNullable = false;
                colvarRoleId.IsPrimaryKey = false;
                colvarRoleId.IsForeignKey = false;
                colvarRoleId.IsReadOnly = false;
                schema.Columns.Add(colvarRoleId);


                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 200;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
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
                schema.Columns.Add(colvarPhone);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VSys_Admin", schema);
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
        public VSys_Admin()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSys_Admin(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VSys_Admin(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VSys_Admin(string columnName, object columnValue)
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
        [XmlAttribute("LoginName")]
        [Bindable(true)]
        public string LoginName
        {
            get { return GetColumnValue<string>(Columns.LoginName); }
            set { SetColumnValue(Columns.LoginName, value); }
        }
        [XmlAttribute("LoginPwd")]
        [Bindable(true)]
        public string LoginPwd
        {
            get { return GetColumnValue<string>(Columns.LoginPwd); }
            set { SetColumnValue(Columns.LoginPwd, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [XmlAttribute("IsLogin")]
        [Bindable(true)]
        public int IsLogin
        {
            get { return GetColumnValue<int>(Columns.IsLogin); }
            set { SetColumnValue(Columns.IsLogin, value); }
        }
        [XmlAttribute("Email")]
        [Bindable(true)]
        public string Email
        {
            get { return GetColumnValue<string>(Columns.Email); }
            set { SetColumnValue(Columns.Email, value); }
        }
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [XmlAttribute("RoleName")]
        [Bindable(true)]
        public string RoleName
        {
            get { return GetColumnValue<string>(Columns.RoleName); }
            set { SetColumnValue(Columns.RoleName, value); }
        }
        [XmlAttribute("RoleId")]
        [Bindable(true)]
        public string RoleId
        {
            get { return GetColumnValue<string>(Columns.RoleId); }
            set { SetColumnValue(Columns.RoleId, value); }
        }
        [XmlAttribute("Address")]
        [Bindable(true)]
        public string Address
        {
            get { return GetColumnValue<string>(Columns.Address); }
            set { SetColumnValue(Columns.Address, value); }
        }
        [XmlAttribute("Phone")]
        [Bindable(true)]
        public string Phone
        {
            get { return GetColumnValue<string>(Columns.Phone); }
            set { SetColumnValue(Columns.Phone, value); }
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
            public static string Email = @"Email";
            public static string PubDate = @"PubDate";
            public static string RoleName = @"RoleName";
            public static string RoleId = @"RoleId";
            public static string Address = @"Address";
            public static string Phone = @"Phone";
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
