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
    public partial class WeChat_ActivityInfoCollection : ActiveList<WeChat_ActivityInfo, WeChat_ActivityInfoCollection>
    {
        public WeChat_ActivityInfoCollection() { }
        public WeChat_ActivityInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WeChat_ActivityInfo o = this[i];
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
    public partial class WeChat_ActivityInfo : ActiveRecord<WeChat_ActivityInfo>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public WeChat_ActivityInfo()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public WeChat_ActivityInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public WeChat_ActivityInfo(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public WeChat_ActivityInfo(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("WeChat_ActivityInfo", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarActivityTitle = new TableSchema.TableColumn(schema);
                colvarActivityTitle.ColumnName = "ActivityTitle";
                colvarActivityTitle.DataType = DbType.String;
                colvarActivityTitle.MaxLength = 200;
                colvarActivityTitle.AutoIncrement = false;
                colvarActivityTitle.IsNullable = true;
                colvarActivityTitle.IsPrimaryKey = false;
                colvarActivityTitle.IsForeignKey = false;
                colvarActivityTitle.IsReadOnly = false;
                colvarActivityTitle.DefaultSetting = @"";
                colvarActivityTitle.ForeignKeyTableName = "";
                schema.Columns.Add(colvarActivityTitle);


                TableSchema.TableColumn colvarActivityMemo = new TableSchema.TableColumn(schema);
                colvarActivityMemo.ColumnName = "ActivityMemo";
                colvarActivityMemo.DataType = DbType.String;
                colvarActivityMemo.MaxLength = 2000;
                colvarActivityMemo.AutoIncrement = false;
                colvarActivityMemo.IsNullable = true;
                colvarActivityMemo.IsPrimaryKey = false;
                colvarActivityMemo.IsForeignKey = false;
                colvarActivityMemo.IsReadOnly = false;
                colvarActivityMemo.DefaultSetting = @"";
                colvarActivityMemo.ForeignKeyTableName = "";
                schema.Columns.Add(colvarActivityMemo);


                TableSchema.TableColumn colvarActivityContent = new TableSchema.TableColumn(schema);
                colvarActivityContent.ColumnName = "ActivityContent";
                colvarActivityContent.DataType = DbType.String;
                colvarActivityContent.MaxLength = 2000;
                colvarActivityContent.AutoIncrement = false;
                colvarActivityContent.IsNullable = true;
                colvarActivityContent.IsPrimaryKey = false;
                colvarActivityContent.IsForeignKey = false;
                colvarActivityContent.IsReadOnly = false;
                colvarActivityContent.DefaultSetting = @"";
                colvarActivityContent.ForeignKeyTableName = "";
                schema.Columns.Add(colvarActivityContent);


                TableSchema.TableColumn colvarStarTime = new TableSchema.TableColumn(schema);
                colvarStarTime.ColumnName = "StarTime";
                colvarStarTime.DataType = DbType.DateTime;
                colvarStarTime.MaxLength = 0;
                colvarStarTime.AutoIncrement = false;
                colvarStarTime.IsNullable = true;
                colvarStarTime.IsPrimaryKey = false;
                colvarStarTime.IsForeignKey = false;
                colvarStarTime.IsReadOnly = false;
                colvarStarTime.DefaultSetting = @"";
                colvarStarTime.ForeignKeyTableName = "";
                schema.Columns.Add(colvarStarTime);


                TableSchema.TableColumn colvarEndTime = new TableSchema.TableColumn(schema);
                colvarEndTime.ColumnName = "EndTime";
                colvarEndTime.DataType = DbType.DateTime;
                colvarEndTime.MaxLength = 0;
                colvarEndTime.AutoIncrement = false;
                colvarEndTime.IsNullable = true;
                colvarEndTime.IsPrimaryKey = false;
                colvarEndTime.IsForeignKey = false;
                colvarEndTime.IsReadOnly = false;
                colvarEndTime.DefaultSetting = @"";
                colvarEndTime.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEndTime);


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
                DataService.Providers["ZrCon"].AddSchema("WeChat_ActivityInfo", schema);
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
        [DisplayName("活动标题")]
        [XmlAttribute("ActivityTitle")]
        [Bindable(true)]
        public string ActivityTitle
        {
            get { return GetColumnValue<string>(Columns.ActivityTitle); }
            set { SetColumnValue(Columns.ActivityTitle, value); }
        }
        [DisplayName("活动备注")]
        [XmlAttribute("ActivityMemo")]
        [Bindable(true)]
        public string ActivityMemo
        {
            get { return GetColumnValue<string>(Columns.ActivityMemo); }
            set { SetColumnValue(Columns.ActivityMemo, value); }
        }
        [DisplayName("活动内容")]
        [XmlAttribute("ActivityContent")]
        [Bindable(true)]
        public string ActivityContent
        {
            get { return GetColumnValue<string>(Columns.ActivityContent); }
            set { SetColumnValue(Columns.ActivityContent, value); }
        }
        [DisplayName("开始时间")]
        [XmlAttribute("StarTime")]
        [Bindable(true)]
        public DateTime? StarTime
        {
            get { return GetColumnValue<DateTime?>(Columns.StarTime); }
            set { SetColumnValue(Columns.StarTime, value); }
        }
        [DisplayName("结束时间")]
        [XmlAttribute("EndTime")]
        [Bindable(true)]
        public DateTime? EndTime
        {
            get { return GetColumnValue<DateTime?>(Columns.EndTime); }
            set { SetColumnValue(Columns.EndTime, value); }
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
        [DisplayName("EditAdminId")]
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [DisplayName("EditPubDate")]
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        #endregion
        #region ObjectDataSource support 
        public static void Insert(string varId, string varActivityTitle, string varActivityMemo, string varActivityContent, DateTime? varStarTime, DateTime? varEndTime, string varAdminId, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            WeChat_ActivityInfo item = new WeChat_ActivityInfo();
            item.Id = varId;
            item.ActivityTitle = varActivityTitle;
            item.ActivityMemo = varActivityMemo;
            item.ActivityContent = varActivityContent;
            item.StarTime = varStarTime;
            item.EndTime = varEndTime;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varActivityTitle, string varActivityMemo, string varActivityContent, DateTime? varStarTime, DateTime? varEndTime, string varAdminId, DateTime? varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            WeChat_ActivityInfo item = new WeChat_ActivityInfo();
            item.Id = varId;
            item.ActivityTitle = varActivityTitle;
            item.ActivityMemo = varActivityMemo;
            item.ActivityContent = varActivityContent;
            item.StarTime = varStarTime;
            item.EndTime = varEndTime;
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
        public static TableSchema.TableColumn ActivityTitleColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn ActivityMemoColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn ActivityContentColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn StarTimeColumn
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn EndTimeColumn
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn AdminIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        public static TableSchema.TableColumn PubDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[9]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string ActivityTitle = @"ActivityTitle";
            public static string ActivityMemo = @"ActivityMemo";
            public static string ActivityContent = @"ActivityContent";
            public static string StarTime = @"StarTime";
            public static string EndTime = @"EndTime";
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
