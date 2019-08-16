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
    /// <summary>
    /// Strongly-typed collection for the Sys_ModuleOperate class.
    /// </summary>
    [Serializable]
    public partial class Sys_ModuleOperateCollection : ActiveList<Sys_ModuleOperate, Sys_ModuleOperateCollection>
    {
        public Sys_ModuleOperateCollection() { }

        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>Sys_ModuleOperateCollection</returns>
        public Sys_ModuleOperateCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_ModuleOperate o = this[i];
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
    /// <summary>
    /// This is an ActiveRecord class which wraps the Sys_ModuleOperate table.
    /// </summary>
    [Serializable]
    public partial class Sys_ModuleOperate : ActiveRecord<Sys_ModuleOperate>, IActiveRecord
    {
        #region .ctors and Default Settings

        public Sys_ModuleOperate()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        private void InitSetDefaults() { SetDefaults(); }

        public Sys_ModuleOperate(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public Sys_ModuleOperate(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public Sys_ModuleOperate(string columnName, object columnValue)
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
                TableSchema.Table schema = new TableSchema.Table("Sys_ModuleOperate", TableType.Table, DataService.GetInstance("ZrCon"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns

                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
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

                TableSchema.TableColumn colvarKeyCode = new TableSchema.TableColumn(schema);
                colvarKeyCode.ColumnName = "KeyCode";
                colvarKeyCode.DataType = DbType.AnsiString;
                colvarKeyCode.MaxLength = 50;
                colvarKeyCode.AutoIncrement = false;
                colvarKeyCode.IsNullable = false;
                colvarKeyCode.IsPrimaryKey = false;
                colvarKeyCode.IsForeignKey = false;
                colvarKeyCode.IsReadOnly = false;
                colvarKeyCode.DefaultSetting = @"";
                colvarKeyCode.ForeignKeyTableName = "";
                schema.Columns.Add(colvarKeyCode);

                TableSchema.TableColumn colvarModuleID = new TableSchema.TableColumn(schema);
                colvarModuleID.ColumnName = "ModuleID";
                colvarModuleID.DataType = DbType.String;
                colvarModuleID.MaxLength = 50;
                colvarModuleID.AutoIncrement = false;
                colvarModuleID.IsNullable = false;
                colvarModuleID.IsPrimaryKey = false;
                colvarModuleID.IsForeignKey = true;
                colvarModuleID.IsReadOnly = false;
                colvarModuleID.DefaultSetting = @"";

                colvarModuleID.ForeignKeyTableName = "Sys_Module";
                schema.Columns.Add(colvarModuleID);

                TableSchema.TableColumn colvarSort = new TableSchema.TableColumn(schema);
                colvarSort.ColumnName = "Sort";
                colvarSort.DataType = DbType.Int32;
                colvarSort.MaxLength = 0;
                colvarSort.AutoIncrement = false;
                colvarSort.IsNullable = false;
                colvarSort.IsPrimaryKey = false;
                colvarSort.IsForeignKey = false;
                colvarSort.IsReadOnly = false;

                colvarSort.DefaultSetting = @"((0))";
                colvarSort.ForeignKeyTableName = "";
                schema.Columns.Add(colvarSort);

                TableSchema.TableColumn colvarIcon = new TableSchema.TableColumn(schema);
                colvarIcon.ColumnName = "Icon";
                colvarIcon.DataType = DbType.AnsiString;
                colvarIcon.MaxLength = 100;
                colvarIcon.AutoIncrement = false;
                colvarIcon.IsNullable = false;
                colvarIcon.IsPrimaryKey = false;
                colvarIcon.IsForeignKey = false;
                colvarIcon.IsReadOnly = false;
                colvarIcon.DefaultSetting = @"";
                colvarIcon.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIcon);

                TableSchema.TableColumn colvarIsBtn = new TableSchema.TableColumn(schema);
                colvarIsBtn.ColumnName = "IsBtn";
                colvarIsBtn.DataType = DbType.Int32;
                colvarIsBtn.MaxLength = 0;
                colvarIsBtn.AutoIncrement = false;
                colvarIsBtn.IsNullable = false;
                colvarIsBtn.IsPrimaryKey = false;
                colvarIsBtn.IsForeignKey = false;
                colvarIsBtn.IsReadOnly = false;

                colvarIsBtn.DefaultSetting = @"((1))";
                colvarIsBtn.ForeignKeyTableName = "";
                schema.Columns.Add(colvarIsBtn);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ZrCon"].AddSchema("Sys_ModuleOperate", schema);
            }
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
        [DisplayName("操作名称")]
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name
        {
            get { return GetColumnValue<string>(Columns.Name); }
            set { SetColumnValue(Columns.Name, value); }
        }

        [DisplayName("操作码")]
        [XmlAttribute("KeyCode")]
        [Bindable(true)]
        public string KeyCode
        {
            get { return GetColumnValue<string>(Columns.KeyCode); }
            set { SetColumnValue(Columns.KeyCode, value); }
        }

        [XmlAttribute("ModuleID")]
        [Bindable(true)]
        public string ModuleID
        {
            get { return GetColumnValue<string>(Columns.ModuleID); }
            set { SetColumnValue(Columns.ModuleID, value); }
        }

        [DisplayName("排序")]
        [XmlAttribute("Sort")]
        [Bindable(true)]
        public int Sort
        {
            get { return GetColumnValue<int>(Columns.Sort); }
            set { SetColumnValue(Columns.Sort, value); }
        }

        [DisplayName("图标")]
        [XmlAttribute("Icon")]
        [Bindable(true)]
        public string Icon
        {
            get { return GetColumnValue<string>(Columns.Icon); }
            set { SetColumnValue(Columns.Icon, value); }
        }

        [DisplayName("生成按钮")]
        [XmlAttribute("IsBtn")]
        [Bindable(true)]
        public int IsBtn
        {
            get { return GetColumnValue<int>(Columns.IsBtn); }
            set { SetColumnValue(Columns.IsBtn, value); }
        }

        #endregion


        #region PrimaryKey Methods

        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);

            SetPKValues();
        }


        public ZrSoft.Sys_PowerCollection Sys_PowerRecords()
        {
            return new ZrSoft.Sys_PowerCollection().Where(Sys_Power.Columns.ModuleOperateID, Id).Load();
        }
        #endregion



        #region ForeignKey Properties

        /// <summary>
        /// Returns a Sys_Module ActiveRecord object related to this Sys_ModuleOperate
        /// 
        /// </summary>
        public ZrSoft.Sys_Module Sys_Module
        {
            get { return ZrSoft.Sys_Module.FetchByID(this.ModuleID); }
            set { SetColumnValue("ModuleID", value.Id); }
        }


        #endregion



        //no ManyToMany tables defined (0)



        #region ObjectDataSource support


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(string varId, string varName, string varKeyCode, string varModuleID, int varSort, string varIcon, int varIsBtn)
        {
            Sys_ModuleOperate item = new Sys_ModuleOperate();

            item.Id = varId;

            item.Name = varName;

            item.KeyCode = varKeyCode;

            item.ModuleID = varModuleID;

            item.Sort = varSort;

            item.Icon = varIcon;

            item.IsBtn = varIsBtn;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(string varId, string varName, string varKeyCode, string varModuleID, int varSort, string varIcon, int varIsBtn)
        {
            Sys_ModuleOperate item = new Sys_ModuleOperate();

            item.Id = varId;

            item.Name = varName;

            item.KeyCode = varKeyCode;

            item.ModuleID = varModuleID;

            item.Sort = varSort;

            item.Icon = varIcon;

            item.IsBtn = varIsBtn;

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



        public static TableSchema.TableColumn KeyCodeColumn
        {
            get { return Schema.Columns[2]; }
        }



        public static TableSchema.TableColumn ModuleIDColumn
        {
            get { return Schema.Columns[3]; }
        }



        public static TableSchema.TableColumn SortColumn
        {
            get { return Schema.Columns[4]; }
        }



        public static TableSchema.TableColumn IconColumn
        {
            get { return Schema.Columns[5]; }
        }



        public static TableSchema.TableColumn IsBtnColumn
        {
            get { return Schema.Columns[6]; }
        }



        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"ID";
            public static string Name = @"Name";
            public static string KeyCode = @"KeyCode";
            public static string ModuleID = @"ModuleID";
            public static string Sort = @"Sort";
            public static string Icon = @"Icon";
            public static string IsBtn = @"IsBtn";

        }
        #endregion

        #region Update PK Collections

        public void SetPKValues()
        {
        }
        #endregion

        #region Deep Save

        public void DeepSave()
        {
            Save();

        }
        #endregion
    }
}
