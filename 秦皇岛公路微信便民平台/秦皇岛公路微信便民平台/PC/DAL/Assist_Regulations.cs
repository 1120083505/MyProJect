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
    public partial class Assist_RegulationsCollection : ActiveList<Assist_Regulations, Assist_RegulationsCollection>
    {
        public Assist_RegulationsCollection() { }
        public Assist_RegulationsCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Assist_Regulations o = this[i];
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
    public partial class Assist_Regulations : ActiveRecord<Assist_Regulations>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Assist_Regulations()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Assist_Regulations(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Assist_Regulations(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Assist_Regulations(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Assist_Regulations", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
                colvarType.ColumnName = "Type";
                colvarType.DataType = DbType.String;
                colvarType.MaxLength = 50;
                colvarType.AutoIncrement = false;
                colvarType.IsNullable = false;
                colvarType.IsPrimaryKey = false;
                colvarType.IsForeignKey = false;
                colvarType.IsReadOnly = false;
                colvarType.DefaultSetting = @"";
                colvarType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarType);


                TableSchema.TableColumn colvarKeyword = new TableSchema.TableColumn(schema);
                colvarKeyword.ColumnName = "Keyword";
                colvarKeyword.DataType = DbType.String;
                colvarKeyword.MaxLength = 500;
                colvarKeyword.AutoIncrement = false;
                colvarKeyword.IsNullable = false;
                colvarKeyword.IsPrimaryKey = false;
                colvarKeyword.IsForeignKey = false;
                colvarKeyword.IsReadOnly = false;
                colvarKeyword.DefaultSetting = @"";
                colvarKeyword.ForeignKeyTableName = "";
                schema.Columns.Add(colvarKeyword);


                TableSchema.TableColumn colvarDetailed = new TableSchema.TableColumn(schema);
                colvarDetailed.ColumnName = "Detailed";
                colvarDetailed.DataType = DbType.String;
                colvarDetailed.MaxLength = 500;
                colvarDetailed.AutoIncrement = false;
                colvarDetailed.IsNullable = false;
                colvarDetailed.IsPrimaryKey = false;
                colvarDetailed.IsForeignKey = false;
                colvarDetailed.IsReadOnly = false;
                colvarDetailed.DefaultSetting = @"";
                colvarDetailed.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDetailed);


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


                TableSchema.TableColumn colvarAdminId = new TableSchema.TableColumn(schema);
                colvarAdminId.ColumnName = "AdminId";
                colvarAdminId.DataType = DbType.String;
                colvarAdminId.MaxLength = 50;
                colvarAdminId.AutoIncrement = false;
                colvarAdminId.IsNullable = false;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                colvarAdminId.DefaultSetting = @"";
                colvarAdminId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAdminId);


                TableSchema.TableColumn colvarPubDate = new TableSchema.TableColumn(schema);
                colvarPubDate.ColumnName = "PubDate";
                colvarPubDate.DataType = DbType.String;
                colvarPubDate.MaxLength = 50;
                colvarPubDate.AutoIncrement = false;
                colvarPubDate.IsNullable = false;
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
                DataService.Providers["ZrCon"].AddSchema("Assist_Regulations", schema);
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
        [DisplayName("咨询类型")]
        [XmlAttribute("Type")]
        [Bindable(true)]
        public string Type
        {
            get { return GetColumnValue<string>(Columns.Type); }
            set { SetColumnValue(Columns.Type, value); }
        }
        [DisplayName("咨询关键字")]
        [XmlAttribute("Keyword")]
        [Bindable(true)]
        public string Keyword
        {
            get { return GetColumnValue<string>(Columns.Keyword); }
            set { SetColumnValue(Columns.Keyword, value); }
        }
        [DisplayName("咨询详解")]
        [XmlAttribute("Detailed")]
        [Bindable(true)]
        public string Detailed
        {
            get { return GetColumnValue<string>(Columns.Detailed); }
            set { SetColumnValue(Columns.Detailed, value); }
        }
        [DisplayName("备注")]
        [XmlAttribute("Memo")]
        [Bindable(true)]
        public string Memo
        {
            get { return GetColumnValue<string>(Columns.Memo); }
            set { SetColumnValue(Columns.Memo, value); }
        }
        [DisplayName("操作人")]
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [DisplayName("操作时间")]
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public string PubDate
        {
            get { return GetColumnValue<string>(Columns.PubDate); }
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
        public static void Insert(string varId, string varType, string varKeyword, string varDetailed, string varMemo, string varAdminId, string varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Assist_Regulations item = new Assist_Regulations();
            item.Id = varId;
            item.Type = varType;
            item.Keyword = varKeyword;
            item.Detailed = varDetailed;
            item.Memo = varMemo;
            item.AdminId = varAdminId;
            item.PubDate = varPubDate;
            item.EditAdminId = varEditAdminId;
            item.EditPubDate = varEditPubDate;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, string varType, string varKeyword, string varDetailed, string varMemo, string varAdminId, string varPubDate, string varEditAdminId, DateTime? varEditPubDate)
        {
            Assist_Regulations item = new Assist_Regulations();
            item.Id = varId;
            item.Type = varType;
            item.Keyword = varKeyword;
            item.Detailed = varDetailed;
            item.Memo = varMemo;
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
        public static TableSchema.TableColumn TypeColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn KeywordColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn DetailedColumn
        {
            get { return Schema.Columns[3]; }
        }
        public static TableSchema.TableColumn MemoColumn
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
        public static TableSchema.TableColumn EditAdminIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        public static TableSchema.TableColumn EditPubDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string Type = @"Type";
            public static string Keyword = @"Keyword";
            public static string Detailed = @"Detailed";
            public static string Memo = @"Memo";
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
