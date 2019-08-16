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
namespace ZrSoft{
    /// <summary>
    /// Strongly-typed collection for the VModuleOperate class.
    /// </summary>
    [Serializable]
    public partial class VModuleOperateCollection : ReadOnlyList<VModuleOperate, VModuleOperateCollection>
    {        
        public VModuleOperateCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the VModuleOperate view.
    /// </summary>
    [Serializable]
    public partial class VModuleOperate : ReadOnlyRecord<VModuleOperate>, IReadOnlyRecord
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
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("VModuleOperate", TableType.View, DataService.GetInstance("ZrCon"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.String;
                colvarId.MaxLength = 50;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarKeyCode);
                
                TableSchema.TableColumn colvarModuleID = new TableSchema.TableColumn(schema);
                colvarModuleID.ColumnName = "ModuleID";
                colvarModuleID.DataType = DbType.String;
                colvarModuleID.MaxLength = 50;
                colvarModuleID.AutoIncrement = false;
                colvarModuleID.IsNullable = false;
                colvarModuleID.IsPrimaryKey = false;
                colvarModuleID.IsForeignKey = false;
                colvarModuleID.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarSort);
                
                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.AnsiString;
                colvarUrl.MaxLength = 50;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = true;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                
                schema.Columns.Add(colvarUrl);
                
                TableSchema.TableColumn colvarControllerName = new TableSchema.TableColumn(schema);
                colvarControllerName.ColumnName = "ControllerName";
                colvarControllerName.DataType = DbType.String;
                colvarControllerName.MaxLength = 50;
                colvarControllerName.AutoIncrement = false;
                colvarControllerName.IsNullable = false;
                colvarControllerName.IsPrimaryKey = false;
                colvarControllerName.IsForeignKey = false;
                colvarControllerName.IsReadOnly = false;
                
                schema.Columns.Add(colvarControllerName);
                
                TableSchema.TableColumn colvarIcon = new TableSchema.TableColumn(schema);
                colvarIcon.ColumnName = "Icon";
                colvarIcon.DataType = DbType.AnsiString;
                colvarIcon.MaxLength = 100;
                colvarIcon.AutoIncrement = false;
                colvarIcon.IsNullable = true;
                colvarIcon.IsPrimaryKey = false;
                colvarIcon.IsForeignKey = false;
                colvarIcon.IsReadOnly = false;
                
                schema.Columns.Add(colvarIcon);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ZrCon"].AddSchema("VModuleOperate",schema);
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
	    public VModuleOperate()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VModuleOperate(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VModuleOperate(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VModuleOperate(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public string Id 
	    {
		    get
		    {
			    return GetColumnValue<string>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name");
		    }
            set 
		    {
			    SetColumnValue("Name", value);
            }
        }
	      
        [XmlAttribute("KeyCode")]
        [Bindable(true)]
        public string KeyCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("KeyCode");
		    }
            set 
		    {
			    SetColumnValue("KeyCode", value);
            }
        }
	      
        [XmlAttribute("ModuleID")]
        [Bindable(true)]
        public string ModuleID 
	    {
		    get
		    {
			    return GetColumnValue<string>("ModuleID");
		    }
            set 
		    {
			    SetColumnValue("ModuleID", value);
            }
        }
	      
        [XmlAttribute("Sort")]
        [Bindable(true)]
        public int Sort 
	    {
		    get
		    {
			    return GetColumnValue<int>("Sort");
		    }
            set 
		    {
			    SetColumnValue("Sort", value);
            }
        }
	      
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url 
	    {
		    get
		    {
			    return GetColumnValue<string>("Url");
		    }
            set 
		    {
			    SetColumnValue("Url", value);
            }
        }
	      
        [XmlAttribute("ControllerName")]
        [Bindable(true)]
        public string ControllerName 
	    {
		    get
		    {
			    return GetColumnValue<string>("ControllerName");
		    }
            set 
		    {
			    SetColumnValue("ControllerName", value);
            }
        }
	      
        [XmlAttribute("Icon")]
        [Bindable(true)]
        public string Icon 
	    {
		    get
		    {
			    return GetColumnValue<string>("Icon");
		    }
            set 
		    {
			    SetColumnValue("Icon", value);
            }
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
            
            public static string Url = @"Url";
            
            public static string ControllerName = @"ControllerName";
            
            public static string Icon = @"Icon";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
