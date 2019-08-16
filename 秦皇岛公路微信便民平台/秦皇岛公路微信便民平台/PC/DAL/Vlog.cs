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
    public partial class VlogCollection : ReadOnlyList<Vlog, VlogCollection>
    {
        public VlogCollection() { }
    }
    [Serializable]
    public partial class Vlog : ReadOnlyRecord<Vlog>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("Vlog", TableType.View, DataService.GetInstance("ZrCon"));
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


                TableSchema.TableColumn colvarModuleName = new TableSchema.TableColumn(schema);
                colvarModuleName.ColumnName = "ModuleName";
                colvarModuleName.DataType = DbType.String;
                colvarModuleName.MaxLength = 200;
                colvarModuleName.AutoIncrement = false;
                colvarModuleName.IsNullable = false;
                colvarModuleName.IsPrimaryKey = false;
                colvarModuleName.IsForeignKey = false;
                colvarModuleName.IsReadOnly = false;
                schema.Columns.Add(colvarModuleName);


                TableSchema.TableColumn colvarOperateName = new TableSchema.TableColumn(schema);
                colvarOperateName.ColumnName = "OperateName";
                colvarOperateName.DataType = DbType.String;
                colvarOperateName.MaxLength = 500;
                colvarOperateName.AutoIncrement = false;
                colvarOperateName.IsNullable = true;
                colvarOperateName.IsPrimaryKey = false;
                colvarOperateName.IsForeignKey = false;
                colvarOperateName.IsReadOnly = false;
                schema.Columns.Add(colvarOperateName);


                TableSchema.TableColumn colvarOperateMemo = new TableSchema.TableColumn(schema);
                colvarOperateMemo.ColumnName = "OperateMemo";
                colvarOperateMemo.DataType = DbType.String;
                colvarOperateMemo.MaxLength = 0;
                colvarOperateMemo.AutoIncrement = false;
                colvarOperateMemo.IsNullable = false;
                colvarOperateMemo.IsPrimaryKey = false;
                colvarOperateMemo.IsForeignKey = false;
                colvarOperateMemo.IsReadOnly = false;
                schema.Columns.Add(colvarOperateMemo);


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


                TableSchema.TableColumn colvarAdminId = new TableSchema.TableColumn(schema);
                colvarAdminId.ColumnName = "AdminId";
                colvarAdminId.DataType = DbType.String;
                colvarAdminId.MaxLength = 50;
                colvarAdminId.AutoIncrement = false;
                colvarAdminId.IsNullable = false;
                colvarAdminId.IsPrimaryKey = false;
                colvarAdminId.IsForeignKey = false;
                colvarAdminId.IsReadOnly = false;
                schema.Columns.Add(colvarAdminId);


                TableSchema.TableColumn colvarIP = new TableSchema.TableColumn(schema);
                colvarIP.ColumnName = "IP";
                colvarIP.DataType = DbType.String;
                colvarIP.MaxLength = 50;
                colvarIP.AutoIncrement = false;
                colvarIP.IsNullable = false;
                colvarIP.IsPrimaryKey = false;
                colvarIP.IsForeignKey = false;
                colvarIP.IsReadOnly = false;
                schema.Columns.Add(colvarIP);


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

                BaseSchema = schema;
                DataService.Providers["ZrCon"].AddSchema("Vlog", schema);
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
        public Vlog()
        {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public Vlog(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
            {
                ForceDefaults();
            }
            MarkNew();
        }

        public Vlog(object keyID)
        {
            SetSQLProps();
            LoadByKey(keyID);
        }

        public Vlog(string columnName, object columnValue)
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
        [XmlAttribute("ModuleName")]
        [Bindable(true)]
        public string ModuleName
        {
            get { return GetColumnValue<string>(Columns.ModuleName); }
            set { SetColumnValue(Columns.ModuleName, value); }
        }
        [XmlAttribute("OperateName")]
        [Bindable(true)]
        public string OperateName
        {
            get { return GetColumnValue<string>(Columns.OperateName); }
            set { SetColumnValue(Columns.OperateName, value); }
        }
        [XmlAttribute("OperateMemo")]
        [Bindable(true)]
        public string OperateMemo
        {
            get { return GetColumnValue<string>(Columns.OperateMemo); }
            set { SetColumnValue(Columns.OperateMemo, value); }
        }
        [XmlAttribute("PubDate")]
        [Bindable(true)]
        public DateTime PubDate
        {
            get { return GetColumnValue<DateTime>(Columns.PubDate); }
            set { SetColumnValue(Columns.PubDate, value); }
        }
        [XmlAttribute("AdminId")]
        [Bindable(true)]
        public string AdminId
        {
            get { return GetColumnValue<string>(Columns.AdminId); }
            set { SetColumnValue(Columns.AdminId, value); }
        }
        [XmlAttribute("IP")]
        [Bindable(true)]
        public string IP
        {
            get { return GetColumnValue<string>(Columns.IP); }
            set { SetColumnValue(Columns.IP, value); }
        }
        [XmlAttribute("LoginName")]
        [Bindable(true)]
        public string LoginName
        {
            get { return GetColumnValue<string>(Columns.LoginName); }
            set { SetColumnValue(Columns.LoginName, value); }
        }
        [XmlAttribute("RealName")]
        [Bindable(true)]
        public string RealName
        {
            get { return GetColumnValue<string>(Columns.RealName); }
            set { SetColumnValue(Columns.RealName, value); }
        }
        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string ModuleName = @"ModuleName";
            public static string OperateName = @"OperateName";
            public static string OperateMemo = @"OperateMemo";
            public static string PubDate = @"PubDate";
            public static string AdminId = @"AdminId";
            public static string IP = @"IP";
            public static string LoginName = @"LoginName";
            public static string RealName = @"RealName";
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
