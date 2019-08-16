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
    public partial class WeChat_RoadVoteInfoCollection : ActiveList<WeChat_RoadVoteInfo, WeChat_RoadVoteInfoCollection>
    {
        public WeChat_RoadVoteInfoCollection() { }
        public WeChat_RoadVoteInfoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WeChat_RoadVoteInfo o = this[i];
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
    public partial class WeChat_RoadVoteInfo : ActiveRecord<WeChat_RoadVoteInfo>, IActiveRecord
    {
        #region .ctors and Default Settings 
        public WeChat_RoadVoteInfo()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public WeChat_RoadVoteInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public WeChat_RoadVoteInfo(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public WeChat_RoadVoteInfo(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("WeChat_RoadVoteInfo", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarOpenId = new TableSchema.TableColumn(schema);
                colvarOpenId.ColumnName = "OpenId";
                colvarOpenId.DataType = DbType.String;
                colvarOpenId.MaxLength = 50;
                colvarOpenId.AutoIncrement = false;
                colvarOpenId.IsNullable = true;
                colvarOpenId.IsPrimaryKey = false;
                colvarOpenId.IsForeignKey = false;
                colvarOpenId.IsReadOnly = false;
                colvarOpenId.DefaultSetting = @"";
                colvarOpenId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarOpenId);


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


                TableSchema.TableColumn colvarFromId = new TableSchema.TableColumn(schema);
                colvarFromId.ColumnName = "FromId";
                colvarFromId.DataType = DbType.String;
                colvarFromId.MaxLength = 50;
                colvarFromId.AutoIncrement = false;
                colvarFromId.IsNullable = true;
                colvarFromId.IsPrimaryKey = false;
                colvarFromId.IsForeignKey = false;
                colvarFromId.IsReadOnly = false;
                colvarFromId.DefaultSetting = @"";
                colvarFromId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarFromId);


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
                DataService.Providers["ZrCon"].AddSchema("WeChat_RoadVoteInfo", schema);
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
        [DisplayName("公众号用户Id")]
        [XmlAttribute("OpenId")]
        [Bindable(true)]
        public string OpenId
        {
            get { return GetColumnValue<string>(Columns.OpenId); }
            set { SetColumnValue(Columns.OpenId, value); }
        }
        [DisplayName("创建时间")]
        [XmlAttribute("Pubdate")]
        [Bindable(true)]
        public DateTime? Pubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.Pubdate); }
            set { SetColumnValue(Columns.Pubdate, value); }
        }
        [DisplayName("公路Id")]
        [XmlAttribute("FromId")]
        [Bindable(true)]
        public string FromId
        {
            get { return GetColumnValue<string>(Columns.FromId); }
            set { SetColumnValue(Columns.FromId, value); }
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
        public static void Insert(string varId, string varOpenId, DateTime? varPubdate, string varFromId, string varExt1, string varExt2, string varExt3)
        {
            WeChat_RoadVoteInfo item = new WeChat_RoadVoteInfo();
            item.Id = varId;
            item.OpenId = varOpenId;
            item.Pubdate = varPubdate;
            item.FromId = varFromId;
            item.Ext1 = varExt1;
            item.Ext2 = varExt2;
            item.Ext3 = varExt3;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varOpenId, DateTime? varPubdate, string varFromId, string varExt1, string varExt2, string varExt3)
        {
            WeChat_RoadVoteInfo item = new WeChat_RoadVoteInfo();
            item.Id = varId;
            item.OpenId = varOpenId;
            item.Pubdate = varPubdate;
            item.FromId = varFromId;
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
        public static TableSchema.TableColumn OpenIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn PubdateColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn FromIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn Ext1Column
        {
            get { return Schema.Columns[4]; }
        }
        public static TableSchema.TableColumn Ext2Column
        {
            get { return Schema.Columns[5]; }
        }
        public static TableSchema.TableColumn Ext3Column
        {
            get { return Schema.Columns[6]; }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string OpenId = @"OpenId";
            public static string Pubdate = @"Pubdate";
            public static string FromId = @"FromId";
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
