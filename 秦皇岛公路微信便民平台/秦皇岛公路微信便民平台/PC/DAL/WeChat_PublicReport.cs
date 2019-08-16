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
    public partial class WeChat_PublicReportCollection : ActiveList<WeChat_PublicReport, WeChat_PublicReportCollection>
    {
        public WeChat_PublicReportCollection() { }
        public WeChat_PublicReportCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WeChat_PublicReport o = this[i];
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
    public partial class WeChat_PublicReport : ActiveRecord<WeChat_PublicReport>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public WeChat_PublicReport()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public WeChat_PublicReport(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public WeChat_PublicReport(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public WeChat_PublicReport(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("WeChat_PublicReport", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarLocation = new TableSchema.TableColumn(schema);
                colvarLocation.ColumnName = "Location";
                colvarLocation.DataType = DbType.String;
                colvarLocation.MaxLength = 200;
                colvarLocation.AutoIncrement = false;
                colvarLocation.IsNullable = true;
                colvarLocation.IsPrimaryKey = false;
                colvarLocation.IsForeignKey = false;
                colvarLocation.IsReadOnly = false;
                colvarLocation.DefaultSetting = @"";
                colvarLocation.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLocation);


                TableSchema.TableColumn colvarLngLat = new TableSchema.TableColumn(schema);
                colvarLngLat.ColumnName = "LngLat";
                colvarLngLat.DataType = DbType.String;
                colvarLngLat.MaxLength = 500;
                colvarLngLat.AutoIncrement = false;
                colvarLngLat.IsNullable = true;
                colvarLngLat.IsPrimaryKey = false;
                colvarLngLat.IsForeignKey = false;
                colvarLngLat.IsReadOnly = false;
                colvarLngLat.DefaultSetting = @"";
                colvarLngLat.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLngLat);


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


                TableSchema.TableColumn colvarReportPerson = new TableSchema.TableColumn(schema);
                colvarReportPerson.ColumnName = "ReportPerson";
                colvarReportPerson.DataType = DbType.String;
                colvarReportPerson.MaxLength = 50;
                colvarReportPerson.AutoIncrement = false;
                colvarReportPerson.IsNullable = true;
                colvarReportPerson.IsPrimaryKey = false;
                colvarReportPerson.IsForeignKey = false;
                colvarReportPerson.IsReadOnly = false;
                colvarReportPerson.DefaultSetting = @"";
                colvarReportPerson.ForeignKeyTableName = "";
                schema.Columns.Add(colvarReportPerson);


                TableSchema.TableColumn colvarTelephone = new TableSchema.TableColumn(schema);
                colvarTelephone.ColumnName = "Telephone";
                colvarTelephone.DataType = DbType.String;
                colvarTelephone.MaxLength = 50;
                colvarTelephone.AutoIncrement = false;
                colvarTelephone.IsNullable = true;
                colvarTelephone.IsPrimaryKey = false;
                colvarTelephone.IsForeignKey = false;
                colvarTelephone.IsReadOnly = false;
                colvarTelephone.DefaultSetting = @"";
                colvarTelephone.ForeignKeyTableName = "";
                schema.Columns.Add(colvarTelephone);


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
                colvarExt2.MaxLength = 500;
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
                colvarExt3.MaxLength = 2000;
                colvarExt3.AutoIncrement = false;
                colvarExt3.IsNullable = true;
                colvarExt3.IsPrimaryKey = false;
                colvarExt3.IsForeignKey = false;
                colvarExt3.IsReadOnly = false;
                colvarExt3.DefaultSetting = @"";
                colvarExt3.ForeignKeyTableName = "";
                schema.Columns.Add(colvarExt3);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("WeChat_PublicReport", schema);
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
        [DisplayName("位置")]
        [XmlAttribute("Location")]
        [Bindable(true)]
        public string Location
        {
            get { return GetColumnValue<string>(Columns.Location); }
            set { SetColumnValue(Columns.Location, value); }
        }
        [DisplayName("经纬度")]
        [XmlAttribute("LngLat")]
        [Bindable(true)]
        public string LngLat
        {
            get { return GetColumnValue<string>(Columns.LngLat); }
            set { SetColumnValue(Columns.LngLat, value); }
        }
        [DisplayName("情况描述")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("上报人")]
        [XmlAttribute("ReportPerson")]
        [Bindable(true)]
        public string ReportPerson
        {
            get { return GetColumnValue<string>(Columns.ReportPerson); }
            set { SetColumnValue(Columns.ReportPerson, value); }
        }
        [DisplayName("联系方式")]
        [XmlAttribute("Telephone")]
        [Bindable(true)]
        public string Telephone
        {
            get { return GetColumnValue<string>(Columns.Telephone); }
            set { SetColumnValue(Columns.Telephone, value); }
        }
        [DisplayName("上传时间")]
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
        public static void Insert(string varId, string varLocation, string varLngLat, string varMemo, string varReportPerson, string varTelephone, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            WeChat_PublicReport item = new WeChat_PublicReport();
            item.Id = varId;
            item.Location = varLocation;
            item.LngLat = varLngLat;
            item.Memo = varMemo;
            item.ReportPerson = varReportPerson;
            item.Telephone = varTelephone;
            item.Pubdate = varPubdate;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varLocation, string varLngLat, string varMemo, string varReportPerson, string varTelephone, DateTime? varPubdate, string varExt1, string varExt2, string varExt3)
        {
            WeChat_PublicReport item = new WeChat_PublicReport();
            item.Id = varId;
            item.Location = varLocation;
            item.LngLat = varLngLat;
            item.Memo = varMemo;
            item.ReportPerson = varReportPerson;
            item.Telephone = varTelephone;
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
        public static TableSchema.TableColumn LocationColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn LngLatColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn ReportPersonColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn TelephoneColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn PubdateColumn
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
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[9]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Location = @"Location";
            public static string LngLat = @"LngLat";
            public static string Memo = @"Memo";
            public static string ReportPerson = @"ReportPerson";
            public static string Telephone = @"Telephone";
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
