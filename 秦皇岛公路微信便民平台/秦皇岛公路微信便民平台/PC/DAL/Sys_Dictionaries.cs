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
    public partial class Sys_DictionariesCollection : ActiveList<Sys_Dictionaries, Sys_DictionariesCollection>
    {
        public Sys_DictionariesCollection() { }
        public Sys_DictionariesCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Dictionaries o = this[i];
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
    public partial class Sys_Dictionaries : ActiveRecord<Sys_Dictionaries>, IActiveRecord
    {
        #region .ctors and Default Settings
        public Sys_Dictionaries()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }
        private void InitSetDefaults() { SetDefaults(); }
        public Sys_Dictionaries(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }
        public Sys_Dictionaries(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_Dictionaries(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_Dictionaries", TableType.Table, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarLimitLoginCount = new TableSchema.TableColumn(schema);
                colvarLimitLoginCount.ColumnName = "LimitLoginCount";
                colvarLimitLoginCount.DataType = DbType.Int32;
                colvarLimitLoginCount.MaxLength = 0;
                colvarLimitLoginCount.AutoIncrement = false;
                colvarLimitLoginCount.IsNullable = false;
                colvarLimitLoginCount.IsPrimaryKey = false;
                colvarLimitLoginCount.IsForeignKey = false;
                colvarLimitLoginCount.IsReadOnly = false;
                colvarLimitLoginCount.DefaultSetting = @"";
                colvarLimitLoginCount.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLimitLoginCount);


                TableSchema.TableColumn colvarLimitLoginTime = new TableSchema.TableColumn(schema);
                colvarLimitLoginTime.ColumnName = "LimitLoginTime";
                colvarLimitLoginTime.DataType = DbType.Int32;
                colvarLimitLoginTime.MaxLength = 0;
                colvarLimitLoginTime.AutoIncrement = false;
                colvarLimitLoginTime.IsNullable = false;
                colvarLimitLoginTime.IsPrimaryKey = false;
                colvarLimitLoginTime.IsForeignKey = false;
                colvarLimitLoginTime.IsReadOnly = false;
                colvarLimitLoginTime.DefaultSetting = @"";
                colvarLimitLoginTime.ForeignKeyTableName = "";
                schema.Columns.Add(colvarLimitLoginTime);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Sys_Dictionaries", schema);
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
        [DisplayName("限制登录次数")]
        [XmlAttribute("LimitLoginCount")]
        [Bindable(true)]
        public int LimitLoginCount
        {
            get { return GetColumnValue<int>(Columns.LimitLoginCount); }
            set { SetColumnValue(Columns.LimitLoginCount, value); }
        }
        [DisplayName("限制登录时长")]
        [XmlAttribute("LimitLoginTime")]
        [Bindable(true)]
        public int LimitLoginTime
        {
            get { return GetColumnValue<int>(Columns.LimitLoginTime); }
            set { SetColumnValue(Columns.LimitLoginTime, value); }
        }
        [DisplayName("判断是否限制IP登录标识(0、同Ip限制、错误次数)")]
        [XmlAttribute("Ident")]
        [Bindable(true)]
        public int Ident
        {
            get { return GetColumnValue<int>(Columns.Ident); }
            set { SetColumnValue(Columns.Ident, value); }
        }
        #endregion
        #region ObjectDataSource support
        public static void Insert(string varId, int varLimitLoginCount, int varLimitLoginTime, int varIdent)
        {
            Sys_Dictionaries item = new Sys_Dictionaries();
            item.Id = varId;
            item.LimitLoginCount = varLimitLoginCount;
            item.LimitLoginTime = varLimitLoginTime;
            item.Ident = varIdent;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        public static void Update(string varId, int varLimitLoginCount, int varLimitLoginTime, int varIdent)
        {
            Sys_Dictionaries item = new Sys_Dictionaries();
            item.Id = varId;
            item.LimitLoginCount = varLimitLoginCount;
            item.LimitLoginTime = varLimitLoginTime;
            item.Ident = varIdent;

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
        public static TableSchema.TableColumn LimitLoginCountColumn
        {
            get { return Schema.Columns[1]; }
        }
        public static TableSchema.TableColumn LimitLoginTimeColumn
        {
            get { return Schema.Columns[2]; }
        }
        public static TableSchema.TableColumn IdentColumn
        {
            get { return Schema.Columns[3]; }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string LimitLoginCount = @"LimitLoginCount";
            public static string LimitLoginTime = @"LimitLoginTime";
            public static string Ident = @"Ident";
        }
        #endregion
        #region Update PK Collections
        #endregion
        #region Deep Save
        #endregion
    }
}
