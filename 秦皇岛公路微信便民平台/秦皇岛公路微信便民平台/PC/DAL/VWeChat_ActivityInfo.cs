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
    public partial class VWeChat_ActivityInfoCollection : ReadOnlyList<VWeChat_ActivityInfo, VWeChat_ActivityInfoCollection>
    {
        public VWeChat_ActivityInfoCollection() { }
    }
    [Serializable]
    public partial class VWeChat_ActivityInfo : ReadOnlyRecord<VWeChat_ActivityInfo>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("VWeChat_ActivityInfo", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarActivityTitle = new TableSchema.TableColumn(schema);
                colvarActivityTitle.ColumnName = "ActivityTitle";
                colvarActivityTitle.DataType = DbType.String;
                colvarActivityTitle.MaxLength = 200;
                colvarActivityTitle.AutoIncrement = false;
                colvarActivityTitle.IsNullable = true;
                colvarActivityTitle.IsPrimaryKey = false;
                colvarActivityTitle.IsForeignKey = false;
                colvarActivityTitle.IsReadOnly = false;
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
                schema.Columns.Add(colvarActivityContent);


                TableSchema.TableColumn colvarAdminId = new TableSchema.TableColumn(schema);
                colvarAdminId.ColumnName = "AdminId";
                colvarAdminId.DataType = DbType.String;
                colvarAdminId.MaxLength = 50;
                colvarAdminId.AutoIncrement = false;
                colvarAdminId.IsNullable = true;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                schema.Columns.Add(colvarAdminId);


                TableSchema.TableColumn colvarEndTime = new TableSchema.TableColumn(schema);
                colvarEndTime.ColumnName = "EndTime";
                colvarEndTime.DataType = DbType.DateTime;
                colvarEndTime.MaxLength = 0;
                colvarEndTime.AutoIncrement = false;
                colvarEndTime.IsNullable = true;
                colvarEndTime.IsPrimaryKey = false;
                colvarEndTime.IsForeignKey = false;
                colvarEndTime.IsReadOnly = false;
                schema.Columns.Add(colvarEndTime);


                TableSchema.TableColumn colvarStarTime = new TableSchema.TableColumn(schema);
                colvarStarTime.ColumnName = "StarTime";
                colvarStarTime.DataType = DbType.DateTime;
                colvarStarTime.MaxLength = 0;
                colvarStarTime.AutoIncrement = false;
                colvarStarTime.IsNullable = true;
                colvarStarTime.IsPrimaryKey = false;
                colvarStarTime.IsForeignKey = false;
                colvarStarTime.IsReadOnly = false;
                schema.Columns.Add(colvarStarTime);


                TableSchema.TableColumn colvarPubDate = new TableSchema.TableColumn(schema);
                colvarPubDate.ColumnName = "PubDate";
                colvarPubDate.DataType = DbType.DateTime;
                colvarPubDate.MaxLength = 0;
                colvarPubDate.AutoIncrement = false;
                colvarPubDate.IsNullable = true;
                colvarPubDate.IsPrimaryKey = false;
                colvarPubDate.IsForeignKey = false;
                colvarPubDate.IsReadOnly = false;
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
                schema.Columns.Add(colvarEditPubDate);


                TableSchema.TableColumn colvarRealName = new TableSchema.TableColumn(schema);
                colvarRealName.ColumnName = "RealName";
                colvarRealName.DataType = DbType.String;
                colvarRealName.MaxLength = 50;
                colvarRealName.AutoIncrement = false;
                colvarRealName.IsNullable = true;
                colvarRealName.IsPrimaryKey = false;
                colvarRealName.IsForeignKey = false;
                colvarRealName.IsReadOnly = false;
                schema.Columns.Add(colvarRealName);


                TableSchema.TableColumn colvarEditRealName = new TableSchema.TableColumn(schema);
                colvarEditRealName.ColumnName = "EditRealName";
                colvarEditRealName.DataType = DbType.String;
                colvarEditRealName.MaxLength = 50;
                colvarEditRealName.AutoIncrement = false;
                colvarEditRealName.IsNullable = true;
                colvarEditRealName.IsPrimaryKey = false;
                colvarEditRealName.IsForeignKey = false;
                colvarEditRealName.IsReadOnly = false;
                schema.Columns.Add(colvarEditRealName);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VWeChat_ActivityInfo", schema);
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
        public VWeChat_ActivityInfo()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VWeChat_ActivityInfo(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VWeChat_ActivityInfo(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VWeChat_ActivityInfo(string columnName, object columnValue)
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
        [XmlAttribute("ActivityTitle")]
        [Bindable(true)]
        public string ActivityTitle
        {
            get { return GetColumnValue<string>(Columns.ActivityTitle); }
            set { SetColumnValue(Columns.ActivityTitle, value); }
        }
        [XmlAttribute("ActivityMemo")]
        [Bindable(true)]
        public string ActivityMemo
        {
            get { return GetColumnValue<string>(Columns.ActivityMemo); }
            set { SetColumnValue(Columns.ActivityMemo, value); }
        }
        [XmlAttribute("ActivityContent")]
        [Bindable(true)]
        public string ActivityContent
        {
            get { return GetColumnValue<string>(Columns.ActivityContent); }
            set { SetColumnValue(Columns.ActivityContent, value); }
        }
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [XmlAttribute("EndTime")]
        [Bindable(true)]
        public DateTime? EndTime
        {
            get { return GetColumnValue<DateTime?>(Columns.EndTime); }
            set { SetColumnValue(Columns.EndTime, value); }
        }
        [XmlAttribute("StarTime")]
        [Bindable(true)]
        public DateTime? StarTime
        {
            get { return GetColumnValue<DateTime?>(Columns.StarTime); }
            set { SetColumnValue(Columns.StarTime, value); }
        }
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime? PubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [XmlAttribute("EditAdminId")]
        [Bindable(true)]
        public string EditAdminId
        {
            get { return GetColumnValue<string>(Columns.EditAdminId); }
            set { SetColumnValue(Columns.EditAdminId, value); }
        }
        [XmlAttribute("EditPubDate")]
        [Bindable(true)]
        public DateTime? EditPubDate
        {
            get { return GetColumnValue<DateTime?>(Columns.EditPubDate); }
            set { SetColumnValue(Columns.EditPubDate, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        [XmlAttribute("EditRealName")]
        [Bindable(true)]
        public string EditRealName
        {
            get { return GetColumnValue<string>(Columns.EditRealName); }
            set { SetColumnValue(Columns.EditRealName, value); }
        }
        #endregion
        #region Columns Struct 
        public struct Columns
        {
            public static string Id = @"Id";
            public static string ActivityTitle = @"ActivityTitle";
            public static string ActivityMemo = @"ActivityMemo";
            public static string ActivityContent = @"ActivityContent";
            public static string AdminId = @"AdminId";
            public static string EndTime = @"EndTime";
            public static string StarTime = @"StarTime";
            public static string PubDate = @"PubDate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
            public static string RealName = @"RealName";
            public static string EditRealName = @"EditRealName";
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
