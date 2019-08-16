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
	/// Strongly-typed collection for the Sys_Power class.
	/// </summary>
    [Serializable]
	public partial class Sys_PowerCollection : ActiveList<Sys_Power, Sys_PowerCollection>
	{	   
		public Sys_PowerCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>Sys_PowerCollection</returns>
		public Sys_PowerCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Sys_Power o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Power table.
	/// </summary>
	[Serializable]
	public partial class Sys_Power : ActiveRecord<Sys_Power>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Sys_Power()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Sys_Power(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Sys_Power(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Sys_Power(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
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
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Sys_Power", TableType.Table, DataService.GetInstance("ZrCon"));
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
				
				TableSchema.TableColumn colvarRoleID = new TableSchema.TableColumn(schema);
				colvarRoleID.ColumnName = "RoleID";
				colvarRoleID.DataType = DbType.String;
				colvarRoleID.MaxLength = 50;
				colvarRoleID.AutoIncrement = false;
				colvarRoleID.IsNullable = false;
				colvarRoleID.IsPrimaryKey = false;
				colvarRoleID.IsForeignKey = true;
				colvarRoleID.IsReadOnly = false;
				colvarRoleID.DefaultSetting = @"";
				
					colvarRoleID.ForeignKeyTableName = "Sys_Role";
				schema.Columns.Add(colvarRoleID);
				
				TableSchema.TableColumn colvarModuleOperateID = new TableSchema.TableColumn(schema);
				colvarModuleOperateID.ColumnName = "ModuleOperateID";
				colvarModuleOperateID.DataType = DbType.String;
				colvarModuleOperateID.MaxLength = 50;
				colvarModuleOperateID.AutoIncrement = false;
				colvarModuleOperateID.IsNullable = false;
				colvarModuleOperateID.IsPrimaryKey = false;
				colvarModuleOperateID.IsForeignKey = true;
				colvarModuleOperateID.IsReadOnly = false;
				colvarModuleOperateID.DefaultSetting = @"";
				
					colvarModuleOperateID.ForeignKeyTableName = "Sys_ModuleOperate";
				schema.Columns.Add(colvarModuleOperateID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ZrCon"].AddSchema("Sys_Power",schema);
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
		  
		[XmlAttribute("RoleID")]
		[Bindable(true)]
		public string RoleID 
		{
			get { return GetColumnValue<string>(Columns.RoleID); }
			set { SetColumnValue(Columns.RoleID, value); }
		}
		  
		[XmlAttribute("ModuleOperateID")]
		[Bindable(true)]
		public string ModuleOperateID 
		{
			get { return GetColumnValue<string>(Columns.ModuleOperateID); }
			set { SetColumnValue(Columns.ModuleOperateID, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Sys_ModuleOperate ActiveRecord object related to this Sys_Power
		/// 
		/// </summary>
		public ZrSoft.Sys_ModuleOperate Sys_ModuleOperate
		{
			get { return ZrSoft.Sys_ModuleOperate.FetchByID(this.ModuleOperateID); }
			set { SetColumnValue("ModuleOperateID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a Sys_Role ActiveRecord object related to this Sys_Power
		/// 
		/// </summary>
		public ZrSoft.Sys_Role Sys_Role
		{
			get { return ZrSoft.Sys_Role.FetchByID(this.RoleID); }
			set { SetColumnValue("RoleID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varId,string varRoleID,string varModuleOperateID)
		{
			Sys_Power item = new Sys_Power();
			
			item.Id = varId;
			
			item.RoleID = varRoleID;
			
			item.ModuleOperateID = varModuleOperateID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varId,string varRoleID,string varModuleOperateID)
		{
			Sys_Power item = new Sys_Power();
			
				item.Id = varId;
			
				item.RoleID = varRoleID;
			
				item.ModuleOperateID = varModuleOperateID;
			
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
        
        
        
        public static TableSchema.TableColumn RoleIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ModuleOperateIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string RoleID = @"RoleID";
			 public static string ModuleOperateID = @"ModuleOperateID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
