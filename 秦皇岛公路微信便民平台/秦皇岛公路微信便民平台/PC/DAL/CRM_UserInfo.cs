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
    public partial class CRM_UserInfoCollection : ActiveList<CRM_UserInfo, CRM_UserInfoCollection>
    {
        public CRM_UserInfoCollection() { }
        public CRM_UserInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CRM_UserInfo o = this[i];
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
    public partial class CRM_UserInfo : ActiveRecord<CRM_UserInfo>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public CRM_UserInfo()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public CRM_UserInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public CRM_UserInfo(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public CRM_UserInfo(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("CRM_UserInfo", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarmemberNameCn = new TableSchema.TableColumn(schema);
                colvarmemberNameCn.ColumnName = "memberNameCn";
                colvarmemberNameCn.DataType = DbType.String;
                colvarmemberNameCn.MaxLength = 50;
                colvarmemberNameCn.AutoIncrement = false;
                colvarmemberNameCn.IsNullable = true;
                colvarmemberNameCn.IsPrimaryKey = false;
                colvarmemberNameCn.IsForeignKey = false;
                colvarmemberNameCn.IsReadOnly = false;
                colvarmemberNameCn.DefaultSetting = @"";
                colvarmemberNameCn.ForeignKeyTableName = "";
                schema.Columns.Add(colvarmemberNameCn);


                TableSchema.TableColumn colvargender = new TableSchema.TableColumn(schema);
                colvargender.ColumnName = "gender";
                colvargender.DataType = DbType.String;
                colvargender.MaxLength = 10;
                colvargender.AutoIncrement = false;
                colvargender.IsNullable = true;
                colvargender.IsPrimaryKey = false;
                colvargender.IsForeignKey = false;
                colvargender.IsReadOnly = false;
                colvargender.DefaultSetting = @"";
                colvargender.ForeignKeyTableName = "";
                schema.Columns.Add(colvargender);


                TableSchema.TableColumn colvarmobile = new TableSchema.TableColumn(schema);
                colvarmobile.ColumnName = "mobile";
                colvarmobile.DataType = DbType.String;
                colvarmobile.MaxLength = 50;
                colvarmobile.AutoIncrement = false;
                colvarmobile.IsNullable = true;
                colvarmobile.IsPrimaryKey = false;
                colvarmobile.IsForeignKey = false;
                colvarmobile.IsReadOnly = false;
                colvarmobile.DefaultSetting = @"";
                colvarmobile.ForeignKeyTableName = "";
                schema.Columns.Add(colvarmobile);


                TableSchema.TableColumn colvarmembershipCode = new TableSchema.TableColumn(schema);
                colvarmembershipCode.ColumnName = "membershipCode";
                colvarmembershipCode.DataType = DbType.String;
                colvarmembershipCode.MaxLength = 50;
                colvarmembershipCode.AutoIncrement = false;
                colvarmembershipCode.IsNullable = true;
                colvarmembershipCode.IsPrimaryKey = false;
                colvarmembershipCode.IsForeignKey = false;
                colvarmembershipCode.IsReadOnly = false;
                colvarmembershipCode.DefaultSetting = @"";
                colvarmembershipCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarmembershipCode);


                TableSchema.TableColumn colvarchannelCode = new TableSchema.TableColumn(schema);
                colvarchannelCode.ColumnName = "channelCode";
                colvarchannelCode.DataType = DbType.String;
                colvarchannelCode.MaxLength = 50;
                colvarchannelCode.AutoIncrement = false;
                colvarchannelCode.IsNullable = true;
                colvarchannelCode.IsPrimaryKey = false;
                colvarchannelCode.IsForeignKey = false;
                colvarchannelCode.IsReadOnly = false;
                colvarchannelCode.DefaultSetting = @"";
                colvarchannelCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarchannelCode);


                TableSchema.TableColumn colvarcertCode = new TableSchema.TableColumn(schema);
                colvarcertCode.ColumnName = "certCode";
                colvarcertCode.DataType = DbType.String;
                colvarcertCode.MaxLength = 50;
                colvarcertCode.AutoIncrement = false;
                colvarcertCode.IsNullable = true;
                colvarcertCode.IsPrimaryKey = false;
                colvarcertCode.IsForeignKey = false;
                colvarcertCode.IsReadOnly = false;
                colvarcertCode.DefaultSetting = @"";
                colvarcertCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarcertCode);


                TableSchema.TableColumn colvarbirthday = new TableSchema.TableColumn(schema);
                colvarbirthday.ColumnName = "birthday";
                colvarbirthday.DataType = DbType.DateTime;
                colvarbirthday.MaxLength = 0;
                colvarbirthday.AutoIncrement = false;
                colvarbirthday.IsNullable = true;
                colvarbirthday.IsPrimaryKey = false;
                colvarbirthday.IsForeignKey = false;
                colvarbirthday.IsReadOnly = false;
                colvarbirthday.DefaultSetting = @"";
                colvarbirthday.ForeignKeyTableName = "";
                schema.Columns.Add(colvarbirthday);


                TableSchema.TableColumn colvarstoreCode = new TableSchema.TableColumn(schema);
                colvarstoreCode.ColumnName = "storeCode";
                colvarstoreCode.DataType = DbType.String;
                colvarstoreCode.MaxLength = 50;
                colvarstoreCode.AutoIncrement = false;
                colvarstoreCode.IsNullable = true;
                colvarstoreCode.IsPrimaryKey = false;
                colvarstoreCode.IsForeignKey = false;
                colvarstoreCode.IsReadOnly = false;
                colvarstoreCode.DefaultSetting = @"";
                colvarstoreCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarstoreCode);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("CRM_UserInfo", schema);
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
        [DisplayName("会员姓名")]
        [XmlAttribute("memberNameCn")]
        [Bindable(true)]
        public string memberNameCn
        {
            get { return GetColumnValue<string>(Columns.memberNameCn); }
            set { SetColumnValue(Columns.memberNameCn, value); }
        }
        [DisplayName("性别")]
        [XmlAttribute("gender")]
        [Bindable(true)]
        public string gender
        {
            get { return GetColumnValue<string>(Columns.gender); }
            set { SetColumnValue(Columns.gender, value); }
        }
        [DisplayName("手机号")]
        [XmlAttribute("mobile")]
        [Bindable(true)]
        public string mobile
        {
            get { return GetColumnValue<string>(Columns.mobile); }
            set { SetColumnValue(Columns.mobile, value); }
        }
        [DisplayName("会员体系")]
        [XmlAttribute("membershipCode")]
        [Bindable(true)]
        public string membershipCode
        {
            get { return GetColumnValue<string>(Columns.membershipCode); }
            set { SetColumnValue(Columns.membershipCode, value); }
        }
        [DisplayName("渠道代码")]
        [XmlAttribute("channelCode")]
        [Bindable(true)]
        public string channelCode
        {
            get { return GetColumnValue<string>(Columns.channelCode); }
            set { SetColumnValue(Columns.channelCode, value); }
        }
        [DisplayName("身份证号")]
        [XmlAttribute("certCode")]
        [Bindable(true)]
        public string certCode
        {
            get { return GetColumnValue<string>(Columns.certCode); }
            set { SetColumnValue(Columns.certCode, value); }
        }
        [DisplayName("生日")]
        [XmlAttribute("birthday")]
        [Bindable(true)]
        public DateTime? birthday
        {
            get { return GetColumnValue<DateTime?>(Columns.birthday); }
            set { SetColumnValue(Columns.birthday, value); }
        }
        [DisplayName("门店编码")]
        [XmlAttribute("storeCode")]
        [Bindable(true)]
        public string storeCode
        {
            get { return GetColumnValue<string>(Columns.storeCode); }
            set { SetColumnValue(Columns.storeCode, value); }
        }
        #endregion
        #region ObjectDataSource support 
        public static void Insert(string varId, string varmemberNameCn, string vargender, string varmobile, string varmembershipCode, string varchannelCode, string varcertCode, DateTime? varbirthday, string varstoreCode)
        {
            CRM_UserInfo item = new CRM_UserInfo();
            item.Id = varId;
            item.memberNameCn = varmemberNameCn;
            item.gender = vargender;
            item.mobile = varmobile;
            item.membershipCode = varmembershipCode;
            item.channelCode = varchannelCode;
            item.certCode = varcertCode;
            item.birthday = varbirthday;
            item.storeCode = varstoreCode;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varmemberNameCn, string vargender, string varmobile, string varmembershipCode, string varchannelCode, string varcertCode, DateTime? varbirthday, string varstoreCode)
        {
            CRM_UserInfo item = new CRM_UserInfo();
            item.Id = varId;
            item.memberNameCn = varmemberNameCn;
            item.gender = vargender;
            item.mobile = varmobile;
            item.membershipCode = varmembershipCode;
            item.channelCode = varchannelCode;
            item.certCode = varcertCode;
            item.birthday = varbirthday;
            item.storeCode = varstoreCode;

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
        public static TableSchema.TableColumn memberNameCnColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn genderColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn mobileColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn membershipCodeColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn channelCodeColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn certCodeColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn birthdayColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn storeCodeColumn
        {
            get { return Schema.Columns[8]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string memberNameCn = @"memberNameCn";
            public static string gender = @"gender";
            public static string mobile = @"mobile";
            public static string membershipCode = @"membershipCode";
            public static string channelCode = @"channelCode";
            public static string certCode = @"certCode";
            public static string birthday = @"birthday";
            public static string storeCode = @"storeCode";
        }
        #endregion
        #region Update PK Collections 
        #endregion
        #region Deep Save 
        #endregion
    }
}
