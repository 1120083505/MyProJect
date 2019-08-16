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
    public partial class VWeChat_DrunkenRoadCollection : ReadOnlyList<VWeChat_DrunkenRoad, VWeChat_DrunkenRoadCollection>
    {
        public VWeChat_DrunkenRoadCollection() { }
    }
    [Serializable]
    public partial class VWeChat_DrunkenRoad : ReadOnlyRecord<VWeChat_DrunkenRoad>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("VWeChat_DrunkenRoad", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarRoadName = new TableSchema.TableColumn(schema);
                colvarRoadName.ColumnName = "RoadName";
                colvarRoadName.DataType = DbType.String;
                colvarRoadName.MaxLength = 200;
                colvarRoadName.AutoIncrement = false;
                colvarRoadName.IsNullable = true;
                colvarRoadName.IsPrimaryKey = false;
                colvarRoadName.IsForeignKey = false;
                colvarRoadName.IsReadOnly = false;
                schema.Columns.Add(colvarRoadName);


                TableSchema.TableColumn colvarRoadNum = new TableSchema.TableColumn(schema);
                colvarRoadNum.ColumnName = "RoadNum";
                colvarRoadNum.DataType = DbType.Int32;
                colvarRoadNum.MaxLength = 0;
                colvarRoadNum.AutoIncrement = false;
                colvarRoadNum.IsNullable = true;
                colvarRoadNum.IsPrimaryKey = false;
                colvarRoadNum.IsForeignKey = false;
                colvarRoadNum.IsReadOnly = false;
                schema.Columns.Add(colvarRoadNum);


                TableSchema.TableColumn colvarRoadVotes = new TableSchema.TableColumn(schema);
                colvarRoadVotes.ColumnName = "RoadVotes";
                colvarRoadVotes.DataType = DbType.Int32;
                colvarRoadVotes.MaxLength = 0;
                colvarRoadVotes.AutoIncrement = false;
                colvarRoadVotes.IsNullable = true;
                colvarRoadVotes.IsPrimaryKey = false;
                colvarRoadVotes.IsForeignKey = false;
                colvarRoadVotes.IsReadOnly = false;
                schema.Columns.Add(colvarRoadVotes);


                TableSchema.TableColumn colvarRoadMemo = new TableSchema.TableColumn(schema);
                colvarRoadMemo.ColumnName = "RoadMemo";
                colvarRoadMemo.DataType = DbType.String;
                colvarRoadMemo.MaxLength = 500;
                colvarRoadMemo.AutoIncrement = false;
                colvarRoadMemo.IsNullable = true;
                colvarRoadMemo.IsPrimaryKey = false;
                colvarRoadMemo.IsForeignKey = false;
                colvarRoadMemo.IsReadOnly = false;
                schema.Columns.Add(colvarRoadMemo);


                TableSchema.TableColumn colvarRoadState = new TableSchema.TableColumn(schema);
                colvarRoadState.ColumnName = "RoadState";
                colvarRoadState.DataType = DbType.Int32;
                colvarRoadState.MaxLength = 0;
                colvarRoadState.AutoIncrement = false;
                colvarRoadState.IsNullable = true;
                colvarRoadState.IsPrimaryKey = false;
                colvarRoadState.IsForeignKey = false;
                colvarRoadState.IsReadOnly = false;
                schema.Columns.Add(colvarRoadState);


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


                TableSchema.TableColumn colvarPubdate = new TableSchema.TableColumn(schema);
                colvarPubdate.ColumnName = "Pubdate";
                colvarPubdate.DataType = DbType.DateTime;
                colvarPubdate.MaxLength = 0;
                colvarPubdate.AutoIncrement = false;
                colvarPubdate.IsNullable = true;
                colvarPubdate.IsPrimaryKey = false;
                colvarPubdate.IsForeignKey = false;
                colvarPubdate.IsReadOnly = false;
                schema.Columns.Add(colvarPubdate);


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


                TableSchema.TableColumn colvarExt1 = new TableSchema.TableColumn(schema);
                colvarExt1.ColumnName = "Ext1";
                colvarExt1.DataType = DbType.String;
                colvarExt1.MaxLength = 50;
                colvarExt1.AutoIncrement = false;
                colvarExt1.IsNullable = true;
                colvarExt1.IsPrimaryKey = false;
                colvarExt1.IsForeignKey = false;
                colvarExt1.IsReadOnly = false;
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
                schema.Columns.Add(colvarExt3);


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


                TableSchema.TableColumn colvarEditRealName = new TableSchema.TableColumn(schema);
                colvarEditRealName.ColumnName = "EditRealName";
                colvarEditRealName.DataType = DbType.String;
                colvarEditRealName.MaxLength = 50;
                colvarEditRealName.AutoIncrement = false;
                colvarEditRealName.IsNullable = false;
                colvarEditRealName.IsPrimaryKey = false;
                colvarEditRealName.IsForeignKey = false;
                colvarEditRealName.IsReadOnly = false;
                schema.Columns.Add(colvarEditRealName);

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("VWeChat_DrunkenRoad", schema);
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
        public VWeChat_DrunkenRoad()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VWeChat_DrunkenRoad(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public VWeChat_DrunkenRoad(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public VWeChat_DrunkenRoad(string columnName, object columnValue)
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
        [XmlAttribute("RoadName")]
        [Bindable(true)]
        public string RoadName
        {
            get { return GetColumnValue<string>(Columns.RoadName); }
            set { SetColumnValue(Columns.RoadName, value); }
        }
        [XmlAttribute("RoadNum")]
        [Bindable(true)]
        public int? RoadNum
        {
            get { return GetColumnValue<int?>(Columns.RoadNum); }
            set { SetColumnValue(Columns.RoadNum, value); }
        }
        [XmlAttribute("RoadVotes")]
        [Bindable(true)]
        public int? RoadVotes
        {
            get { return GetColumnValue<int?>(Columns.RoadVotes); }
            set { SetColumnValue(Columns.RoadVotes, value); }
        }
        [XmlAttribute("RoadMemo")]
        [Bindable(true)]
        public string RoadMemo
        {
            get { return GetColumnValue<string>(Columns.RoadMemo); }
            set { SetColumnValue(Columns.RoadMemo, value); }
        }
        [XmlAttribute("RoadState")]
        [Bindable(true)]
        public int? RoadState
        {
            get { return GetColumnValue<int?>(Columns.RoadState); }
            set { SetColumnValue(Columns.RoadState, value); }
        }
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [XmlAttribute("Pubdate")]
        [Bindable(true)]
        public DateTime? Pubdate
        {
            get { return GetColumnValue<DateTime?>(Columns.Pubdate); }
            set { SetColumnValue(Columns.Pubdate, value); }
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
        [XmlAttribute("Ext1")]
        [Bindable(true)]
        public string Ext1
        {
            get { return GetColumnValue<string>(Columns.Ext1); }
            set { SetColumnValue(Columns.Ext1, value); }
        }
        [XmlAttribute("Ext2")]
        [Bindable(true)]
        public string Ext2
        {
            get { return GetColumnValue<string>(Columns.Ext2); }
            set { SetColumnValue(Columns.Ext2, value); }
        }
        [XmlAttribute("Ext3")]
        [Bindable(true)]
        public string Ext3
        {
            get { return GetColumnValue<string>(Columns.Ext3); }
            set { SetColumnValue(Columns.Ext3, value); }
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
            public static string RoadName = @"RoadName";
            public static string RoadNum = @"RoadNum";
            public static string RoadVotes = @"RoadVotes";
            public static string RoadMemo = @"RoadMemo";
            public static string RoadState = @"RoadState";
            public static string AdminId = @"AdminId";
            public static string Pubdate = @"Pubdate";
            public static string EditAdminId = @"EditAdminId";
            public static string EditPubDate = @"EditPubDate";
            public static string Ext1 = @"Ext1";
            public static string Ext2 = @"Ext2";
            public static string Ext3 = @"Ext3";
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
