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
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the sp_checkPower Procedure
        /// </summary>
        public static StoredProcedure Sp_CheckPower(int? adminid, string url, int? power)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_checkPower", DataService.GetInstance("ZrCon"), "dbo");
        	
            sp.Command.AddParameter("@adminid", adminid, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@url", url, DbType.String, null, null);
        	
            sp.Command.AddOutputParameter("@power", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the sp_MouleIsLast Procedure
        /// </summary>
        public static StoredProcedure Sp_MouleIsLast(string mouleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_MouleIsLast", DataService.GetInstance("ZrCon"), "dbo");
        	
            sp.Command.AddParameter("@mouleId", mouleId, DbType.String, null, null);
        	
            return sp;
        }
        
    }
    
}
