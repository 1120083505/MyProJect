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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string Sys_Admin = @"Sys_Admin";
        
		public static readonly string Sys_Module = @"Sys_Module";
        
		public static readonly string Sys_ModuleOperate = @"Sys_ModuleOperate";
        
		public static readonly string Sys_Power = @"Sys_Power";
        
		public static readonly string Sys_Role = @"Sys_Role";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Sys_Admin
		{
            get { return DataService.GetSchema("Sys_Admin", "ZrCon"); }
		}
        
		public static TableSchema.Table Sys_Module
		{
            get { return DataService.GetSchema("Sys_Module", "ZrCon"); }
		}
        
		public static TableSchema.Table Sys_ModuleOperate
		{
            get { return DataService.GetSchema("Sys_ModuleOperate", "ZrCon"); }
		}
        
		public static TableSchema.Table Sys_Power
		{
            get { return DataService.GetSchema("Sys_Power", "ZrCon"); }
		}
        
		public static TableSchema.Table Sys_Role
		{
            get { return DataService.GetSchema("Sys_Role", "ZrCon"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static readonly string VSys_Admin = @"VSys_Admin";
        
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["ZrCon"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static readonly string ZrCon = @"ZrCon";
    
}
#endregion