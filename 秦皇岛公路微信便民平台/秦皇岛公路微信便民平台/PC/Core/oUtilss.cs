using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using SubSonic;
using ZrSoft;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Core
{
    /// <summary>
    /// 后台外部Utils的扩展类
    /// </summary>
    public class oUtilss
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["ZrSoft"].ConnectionString;
        #region 判断是否为有效日期格式
        /// <summary>
        /// 判断是否为有效日期格式
        /// </summary>
        /// <param name="sdate">需判断值</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyDate(string sdate, bool b)
        {
            try
            {
                if (Regex.IsMatch(sdate, @"^[0-9]{4}(\-|\/)[0-9]{1,2}(\-|\/)[0-9]{1,2}(|\s+[0-9]{1,2}(|:[0-9]{1,2}(|:[0-9]{1,2})))$"))
                    return sdate;
                else if (Regex.IsMatch(sdate, @"[0-9]{8}"))
                {
                    //增加6位数字的判断
                    return sdate.Substring(0, 4) + "-" + sdate.Substring(4, 2) + "-" + sdate.Substring(6, 2);
                }
                else
                {
                    if (Regex.IsMatch(sdate, @"^\d{1,}$"))
                        return getDateStr(sdate, b);
                    else
                        if (b)
                            return null;
                        else
                            return "$";
                }
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        #endregion

        #region 字符串是否可用
        /// <summary>
        /// 字符串是否可用
        /// </summary>
        /// <param name="sNull">字符串</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyStr(string sNull, bool b)
        {
            try
            {
                if (Regex.IsMatch(sNull, @"^[\u4E00-\u9FA5A-Za-z0-9_@~！!￥？?|—+：:;；。.,，·`/、#*()<>{}&%\^\]\-\\]{1,}$"))
                    return sNull;
                else
                {
                    if (b)
                        return null;
                    else
                        return "$";
                }
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        #endregion

        #region 数值日期转字符日期
        /// <summary>
        /// 数值日期转字符日期
        /// </summary>
        /// <param name="strValue">数值日期值</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        private static string getDateStr(string strValue, bool b)
        {
            try
            {
                int i = Convert.ToInt32(strValue);
                DateTime d1 = Convert.ToDateTime("1900-1-1");
                DateTime d2 = d1.AddDays(i - 2);
                return d2.ToString("yyyy-MM-dd");
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        #endregion

        #region 浮点数判断
        /// <summary>
        /// 浮点数判断
        /// </summary>
        /// <param name="sdecimal">需判断值</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyDecimal(string sdecimal, bool b)
        {
            try
            {
                //decimal strtod = decimal.Parse(sdecimal);   @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"
                if (Regex.IsMatch(sdecimal, @"[0-9]+(.[0-9]{0,})?"))
                    return sdecimal;
                else
                {
                    if (Regex.IsMatch(sdecimal, @"^[0-9]*[1-9][0-9]*$"))
                        return sdecimal;
                    else
                    {
                        if (b)
                            return null;
                        else
                            return "$";
                    }
                }
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        #endregion

        #region 读取Excel中的数据
        /// <summary>
        /// 读取Excel中的数据
        /// </summary>
        /// <param name="fileNamePath">路径</param>
        /// <returns></returns>
        public static DataTable ReadExcelByOledb(string fileNamePath)
        {
            try
            {
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Excel 12.0;data source=" + fileNamePath;
                OleDbConnection oledbconn1 = new OleDbConnection(connStr);
                oledbconn1.Open();
                DataTable _table = oledbconn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string strTableName = string.Empty;
                if (_table.Rows.Count > 0)
                {
                    strTableName = _table.Rows[0]["TABLE_NAME"].ToString().Trim();
                    string sql = string.Format("SELECT * FROM [{0}]", strTableName);
                    _table = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, oledbconn1);
                    da.Fill(_table);
                }
                oledbconn1.Close();
                return _table;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region 根据键值找键值 字符
        /// <summary>
        /// 根据表中名称找id 字符
        /// </summary>
        /// <param name="dt">DataTable表全部值</param>
        /// <param name="cname">Key键</param>
        /// <param name="cvalue">Value值</param>
        /// <param name="rk">所需值键</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyValueStr(DataTable dt, string cname, string cvalue, string rk, bool b)
        {
            try
            {
                DataRow[] thecount = dt.Select(" " + cname + "='" + cvalue + "' ");
                if (thecount.Count() > 0)
                    return thecount[0][rk].ToString();
                else
                {
                    if (b)
                        return null;
                    else
                        return "$";
                }
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        /// <summary>
        /// 根据关系找键值 字符
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="querystr">关系</param>
        /// <param name="rk">所需值键</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyValueStr(DataTable dt, string querystr, string rk, bool b)
        {
            try
            {
                DataRow[] thecount = dt.Select(querystr);
                if (thecount.Count() > 0)
                    return thecount[0][rk].ToString();
                else
                {
                    if (b)
                        return null;
                    else
                        return "$";
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 根据表中名称找键值 字符
        /// </summary>
        /// <param name="dt">DataTable表全部值</param>
        /// <param name="cname">Key键</param>
        /// <param name="cvalue">Value值</param>
        /// <param name="rk">所需值键</param>
        /// <param name="o">是否模糊查询</param>
        /// <param name="b">是否可空</param>
        /// <returns></returns>
        public static string oKeyValueStr(DataTable dt, string cname, string cvalue, string rk, bool o, bool b)
        {
            try
            {
                DataRow[] thecount = null;
                if (o == false)
                    thecount = dt.Select(" " + cname + "='" + cvalue + "' ");
                else if (o == true)
                    thecount = dt.Select(" " + cname + " like '%" + cvalue + "%' ");
                if (thecount.Count() > 0)
                    return thecount[0][rk].ToString();
                else
                {
                    if (b)
                        return null;
                    else
                        return "$";
                }
            }
            catch
            {
                if (b)
                    return null;
                else
                    return "$";
            }
        }
        #endregion
        #region 导入数据库所需的类
        /// <summary>
        /// 导入数据库所需的类
        /// </summary>
        public class ImportInfo
        {
            private int _I_ok = 0;
            /// <summary>
            /// 正确行数
            /// </summary>
            public int I_ok { get { return _I_ok; } set { _I_ok = value; } }
            private int _I_no = 0;
            /// <summary>
            /// 错误行数
            /// </summary>
            public int I_no { get { return _I_no; } set { _I_no = value; } }
            private string _S_no = "";
            /// <summary>
            /// 错误行号
            /// </summary>
            public string S_no { get { return _S_no; } set { _S_no = value; } }
            private bool _b = true;
            /// <summary>
            /// 标记改行是否正确,默认值正确
            /// </summary>
            public bool b { get { return _b; } set { _b = value; } }
            /// <summary>
            /// 后：数据表格行变量
            /// </summary>
            public DataRow idr { get; set; }
            /// <summary>
            /// 前：数据表格行变量
            /// </summary>
            public DataRow odr { get; set; }
            /// <summary>
            /// 导入的表格中共有多少条数据
            /// </summary>
            public int I_oi { get; set; }
            public StringBuilder _sb = new StringBuilder();
            /// <summary>
            /// 需要写入数据库的字符串
            /// </summary>
            public StringBuilder sb { get { return _sb; } set { _sb = value; } }
            /// <summary>
            /// 当前已经循环读取到第几条
            /// </summary>
            public int I_ti { get; set; }
            private int _I_wi = 1000;
            /// <summary>
            /// 每次写入的条数
            /// </summary>
            public int I_wi { get { return _I_wi; } set { _I_wi = value; } }
            /// <summary>
            /// 导入到的数据库的表的结构
            /// </summary>
            public DataSet ds { get; set; }
            /// <summary>
            /// 导入表格的列数
            /// </summary>
            public int I_tc { get; set; }
            private string _S_pc = "";
            /// <summary>
            /// 判重所需字段
            /// </summary>
            public string S_pc { get { return _S_pc; } set { _S_pc = value; } }
            /// <summary>
            /// 导入的数据库表名
            /// </summary>
            public string S_NM { get; set; }
            /// <summary>
            /// 共需导入到数据库的次数
            /// </summary>
            public int I_wc { get; set; }
            private int _I_mc = 0;
            /// <summary>
            /// 已经循环到了第几次插入数据库
            /// </summary>
            public int I_mc { get { return _I_mc; } set { _I_mc = value; } }
            private StringBuilder _mb = new StringBuilder();
            /// <summary>
            /// 增加每一条信息是否需要增加其他新的数据
            /// </summary>
            public StringBuilder mb { get { return _mb; } set { _mb = value; } }
            private int _HaveCount = 0;
            /// <summary>
            /// 已经有多少行,来计算需不需要插入数据库,当最后一轮的时候,不满也要写入数据库
            /// </summary>
            public int HaveCount { get { return _HaveCount; } set { _HaveCount = value; } }
            public bool _IsLock = true;
            /// <summary>
            /// 控制查询是否加锁,这样可以提速33%,但风险会上升
            /// </summary>
            public bool IsLock { get { return _IsLock; } set { _IsLock = value; } }
            /// <summary>
            /// 是否启用容错判断
            /// </summary>
            public bool IsUsingJudge = true;
        }
        #endregion
        #region 获取导入到的数据库的表的结构
        /// <summary>
        /// 获取导入到的数据库的表的结构
        /// </summary>
        /// <param name="tName">数据库中表名</param>
        /// <returns></returns>
        public static DataSet dsGet(string tName)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + tName, connStr);
            da.FillSchema(ds, SchemaType.Mapped);
            return ds;
        }
        #endregion
        #region 判断是否加入改数据表格中
        public static void IsIn(ImportInfo ii)
        {
            ii.b = true;//首先赋值为正确的
            //分割所有唯一键/混合主键,移除空字符串
            string[] c = ii.S_pc.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //判断是否启用容错判断
            if (ii.IsUsingJudge)
            {
                //循环所有列,看该行的是否必须,或者错误等
                for (int i = 0; i < ii.I_tc; i++)
                {
                    if (ii.idr[i].ToString() == "$")
                    {
                        ii.I_no++;
                        ii.b = false;
                        ii.S_no += (ii.I_ti + 2).ToString() + "<span style=\"color:blue\">|</span>";
                        break;
                    }
                }
            }
            //这里需要访问数据库字段了,从Config中获取连接字符串
            if (ii.b)
            {
                ii.I_ok++;
                //这里需要判断是否到了需要导入数库的时候;
                //这里先加上其他的需要新增的数据
                //ii.sb.AppendFormat(ii.mb.ToString());//这个字符串需要再外部拼接
                if (c.Length > 0)//如果不填写判重字符串,那么没有更新,只有新增,这里应该要重新写一下,把空格也去掉,以免报错
                {
                    if (ii.IsLock)
                    {
                        //使用not exists提速
                        ii.sb.AppendFormat(" if not exists (select * from {0} Where 1=1 ", ii.S_NM);
                    }
                    else
                    {
                        //使用not exists提速
                        ii.sb.AppendFormat(" if not exists (select * from {0} with(nolock) Where 1=1 ", ii.S_NM);
                    }
                    //循环所有唯一键/混合主键
                    foreach (string item in c)
                    {
                        foreach (DataColumn dc in ii.ds.Tables[0].Columns)
                        {
                            if (dc.ColumnName == item)
                            {
                                if (
                                   dc.DataType == typeof(int) ||
                                   dc.DataType == typeof(decimal) ||
                                   dc.DataType == typeof(float) ||
                                   dc.DataType == typeof(decimal)
                                   )
                                {
                                    ii.sb.AppendFormat(" And {0} = {1} ", item, ii.idr[item]);
                                }
                                else
                                {
                                    ii.sb.AppendFormat(" And {0} = '{1}' ", item, ii.idr[item]);
                                }
                                break;
                            }
                        }
                    }
                    ii.sb.Append(" ) ");
                    //拼接新增语句
                    ii.sb.AppendFormat(" Insert into {0} (", ii.S_NM);
                    //拼接所有列名
                    foreach (DataColumn item in ii.ds.Tables[0].Columns)
                    {
                        ii.sb.AppendFormat(" {0}, ", item.ColumnName);
                    }
                    //移除最后一个逗号
                    if (ii.sb.ToString().TrimEnd().LastIndexOf(',') == ii.sb.ToString().TrimEnd().Length - 1)
                        ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
                    ii.sb.Append(" ) Values");
                    ii.sb.Append(" ( ");
                    //循环所有列
                    foreach (DataColumn item in ii.ds.Tables[0].Columns)
                    {
                        //需不需加引号
                        if (
                           item.DataType == typeof(int) ||
                           item.DataType == typeof(decimal) ||
                           item.DataType == typeof(float) ||
                           item.DataType == typeof(decimal)
                           )
                        {
                            //不为空,不加引号
                            if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
                            {
                                ii.sb.AppendFormat(" {0}, ", ii.idr[item.ColumnName]);
                            }
                            //为空,加引号
                            else
                            {
                                //可空
                                if (item.AllowDBNull)
                                {
                                    ii.sb.Append(" Null, ");
                                }
                                //不可空,却为空,这个分支永远不会进来,进来既是错误
                                else
                                {
                                    ii.sb.AppendFormat(" 0, ");
                                }
                            }
                        }
                        //加引号
                        else
                        {
                            //不为空,加引号
                            if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
                            {
                                ii.sb.AppendFormat(" '{0}', ", ii.idr[item.ColumnName]);
                            }
                            //为空,加引号
                            else
                            {
                                //可空
                                if (item.AllowDBNull)
                                {
                                    ii.sb.Append(" Null, ");
                                }
                                //不可空,却为空,这个分支永远不会进来,进来既是错误
                                else
                                {
                                    ii.sb.AppendFormat(" '{0}', ", ii.idr[item.ColumnName]);
                                }
                            }
                        }
                    }
                    //移除最后一逗号
                    if (ii.sb.ToString().TrimEnd().LastIndexOf(',') == ii.sb.ToString().TrimEnd().Length - 1)
                        ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
                    //拼接换号符
                    ii.sb.Append(" ); ");
                    ii.sb.Append(" else ");
                }
                //更新语句
                ii.sb.AppendFormat(" Update {0} Set ", ii.S_NM);
                //循环所有列
                foreach (DataColumn item in ii.ds.Tables[0].Columns)
                {
                    //不同类型需不需要加引号，不加
                    if (
                        item.DataType == typeof(int) ||
                        item.DataType == typeof(decimal) ||
                        item.DataType == typeof(float) ||
                        item.DataType == typeof(decimal)
                        )
                    {
                        //不为空,不加引号
                        if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
                        {
                            ii.sb.AppendFormat(" {0} = {1}, ", item.ColumnName, ii.idr[item.ColumnName]);
                        }
                        //为空，加引号或赋值NULL
                        else
                        {
                            //该列可空
                            if (item.AllowDBNull)
                            {
                                ii.sb.AppendFormat(" {0} = Null, ", item.ColumnName);
                            }
                            //不可空,却为空,这个分支永远不会进来,进来即错误
                            else
                            {
                                ii.sb.AppendFormat(" {0} = {1}, ", item.ColumnName, ii.idr[item.ColumnName]);
                            }
                        }
                    }
                    //加引号
                    else
                    {
                        //除去主键的更新
                        if (!item.Unique)
                        {
                            //不为空,加引号
                            if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
                            {
                                ii.sb.AppendFormat(" {0} = '{1}', ", item.ColumnName, ii.idr[item.ColumnName]);
                            }
                            //为空，加引号
                            else
                            {
                                //该列可空
                                if (item.AllowDBNull)
                                {
                                    ii.sb.AppendFormat(" {0} = Null, ", item.ColumnName);
                                }
                                //不可空，却为空，这个分支永远不会进来，进来即错误，但这里是字符串
                                else
                                {
                                    ii.sb.AppendFormat(" {0} = '{1}', ", item.ColumnName, ii.idr[item.ColumnName]);
                                }
                            }
                        }
                    }
                }
                //移除最后一逗号
                if (ii.sb.ToString().TrimEnd().LastIndexOf(',') == ii.sb.ToString().TrimEnd().Length - 1)
                    ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
                //拼接容错条件
                ii.sb.Append(" Where 1=1 ");
                foreach (string item in c)
                {
                    //循环所有列名
                    foreach (DataColumn dc in ii.ds.Tables[0].Columns)
                    {
                        if (dc.ColumnName == item)
                        {
                            //需不需要加引号
                            if (
                               dc.DataType == typeof(int) ||
                               dc.DataType == typeof(decimal) ||
                               dc.DataType == typeof(float) ||
                               dc.DataType == typeof(decimal)
                               )
                            {
                                ii.sb.AppendFormat(" And {0} = {1} ", item, ii.idr[item]);
                            }
                            else
                            {
                                ii.sb.AppendFormat(" And {0} = '{1}' ", item, ii.idr[item]);
                            }
                            break;
                        }
                    }
                }
                // ii.sb.Append(" );\r\n ");
                //导入数++
                ii.HaveCount++;
            }
            //开始查询是否需要导入,等于每次写入数
            if (ii.HaveCount >= ii.I_wi)
            {
                //清空计数器
                ii.HaveCount = 0;
                //写入数据库中，防止超长同时也要判错，这里使用动态语句的写法，一开始为了简便，使用可以接受MAX的存储过程
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //写入SQL语句
                    SqlCommand cmd = new SqlCommand(ii.sb.ToString(), conn);
                    //添加事务
                    SqlTransaction varTrans = conn.BeginTransaction();
                    cmd.Transaction = varTrans;
                    try
                    {
                        //执行SQL语句及提交事务
                        cmd.ExecuteNonQuery();
                        varTrans.Commit();
                    }
                    catch
                    {
                        varTrans.Rollback();
                        throw;
                    }
                }
                ii.sb.Clear();
            }
            else if (ii.I_oi == ii.I_ti + 1)
            {
                //清空计数器
                ii.HaveCount = 0;
                //写入数据库中，防止超长同时也要判错，这里使用动态语句的写法，一开始为了简便，使用可以接受MAX的存储过程
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //写入SQL语句
                    SqlCommand cmd = new SqlCommand(ii.sb.ToString(), conn);
                    //添加事务
                    SqlTransaction varTrans = conn.BeginTransaction();
                    cmd.Transaction = varTrans;
                    try
                    {
                        //执行SQL语句及提交事务
                        cmd.ExecuteNonQuery();
                        varTrans.Commit();
                    }
                    catch
                    {
                        varTrans.Rollback();
                    }
                }
                //清空语句变量
                ii.sb.Clear();
            }
        }
        #endregion
        #region 判断是否加入改数据表格中
        //public static void IsIn(ImportInfo ii)
        //{
        //    ii.b = true;//首先赋值为正确的
        //    string[] c = ii.S_pc.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);//移除空字符串
        //    for (int i = 0; i < ii.I_tc; i++)
        //    {
        //        if (ii.idr[i].ToString() == "$")
        //        {
        //            ii.I_no++;
        //            ii.b = false;
        //            ii.S_no += (ii.I_ti + 2).ToString() + "<span style=\"color:blue\">|</span>";
        //            break;
        //        }
        //    }
        //    //这里需要访问数据库字段了,从Config中获取连接字符串
        //    if (ii.b)
        //    {
        //        ii.I_ok++;
        //        //这里需要判断是否到了需要导入数库的时候;
        //        //这里先加上其他的需要新增的数据
        //        //ii.sb.AppendFormat(ii.mb.ToString());//这个字符串需要再外部拼接
        //        if (c.Length > 0)//如果不填写判重字符串,那么没有更新,只有新增,这里应该要重新写一下,把空格也去掉,以免报错
        //        {
        //            ii.sb.AppendFormat(" if((select count(1) from {0} Where 1=1 ", ii.S_NM);
        //            foreach (string item in c)
        //            {
        //                foreach (DataColumn dc in ii.ds.Tables[0].Columns)
        //                {
        //                    if (dc.ColumnName == item)
        //                    {
        //                        if (
        //                           dc.DataType == typeof(int) ||
        //                           dc.DataType == typeof(decimal) ||
        //                           dc.DataType == typeof(float) ||
        //                           dc.DataType == typeof(decimal)
        //                           )
        //                        {
        //                            ii.sb.AppendFormat(" And {0} = {1} ", item, ii.idr[item]);
        //                        }
        //                        else
        //                        {
        //                            ii.sb.AppendFormat(" And {0} = '{1}' ", item, ii.idr[item]);
        //                        }
        //                        break;
        //                    }
        //                }
        //            }
        //            ii.sb.Append(" ) > 0) ");
        //            ii.sb.AppendFormat(" Update {0} Set ", ii.S_NM);
        //            foreach (DataColumn item in ii.ds.Tables[0].Columns)
        //            {
        //                if (
        //                    item.DataType == typeof(int) ||
        //                    item.DataType == typeof(decimal) ||
        //                    item.DataType == typeof(float) ||
        //                    item.DataType == typeof(decimal)
        //                    )
        //                {
        //                    if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
        //                    {
        //                        ii.sb.AppendFormat(" {0} = {1}, ", item.ColumnName, ii.idr[item.ColumnName]);
        //                    }
        //                    else
        //                    {
        //                        if (item.AllowDBNull)
        //                        {
        //                            ii.sb.AppendFormat(" {0} = Null, ", item.ColumnName, ii.idr[item.ColumnName]);
        //                        }
        //                        else
        //                        {
        //                            ii.sb.AppendFormat(" {0} = {1}, ", item.ColumnName, ii.idr[item.ColumnName]);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (!item.Unique)//除去主键的更新
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
        //                        {
        //                            ii.sb.AppendFormat(" {0} = '{1}', ", item.ColumnName, ii.idr[item.ColumnName]);
        //                        }
        //                        else
        //                        {
        //                            if (item.AllowDBNull)
        //                            {
        //                                ii.sb.AppendFormat(" {0} = Null, ", item.ColumnName, ii.idr[item.ColumnName]);
        //                            }
        //                            else
        //                            {
        //                                ii.sb.AppendFormat(" {0} = '{1}', ", item.ColumnName, ii.idr[item.ColumnName]);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            ii.sb = ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
        //            ii.sb.Append(" Where 1=1 ");
        //            foreach (string item in c)
        //            {
        //                foreach (DataColumn dc in ii.ds.Tables[0].Columns)
        //                {
        //                    if (dc.ColumnName == item)
        //                    {
        //                        if (
        //                           dc.DataType == typeof(int) ||
        //                           dc.DataType == typeof(decimal) ||
        //                           dc.DataType == typeof(float) ||
        //                           dc.DataType == typeof(decimal)
        //                           )
        //                        {
        //                            ii.sb.AppendFormat(" And {0} = {1} ", item, ii.idr[item]);
        //                        }
        //                        else
        //                        {
        //                            ii.sb.AppendFormat(" And {0} = '{1}' ", item, ii.idr[item]);
        //                        }
        //                        break;
        //                    }
        //                }
        //            }
        //            ii.sb.Append(";");
        //            ii.sb.Append(" else ");
        //        }
        //        ii.sb.AppendFormat(" Insert into {0} (", ii.S_NM);
        //        foreach (DataColumn item in ii.ds.Tables[0].Columns)
        //        {
        //            ii.sb.AppendFormat(" {0}, ", item.ColumnName);
        //        }
        //        ii.sb = ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
        //        ii.sb.Append(" ) Values ");
        //        ii.sb.Append(" ( ");
        //        foreach (DataColumn item in ii.ds.Tables[0].Columns)
        //        {
        //            if (
        //               item.DataType == typeof(int) ||
        //               item.DataType == typeof(decimal) ||
        //               item.DataType == typeof(float) ||
        //               item.DataType == typeof(decimal)
        //               )
        //            {
        //                if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
        //                {
        //                    ii.sb.AppendFormat(" {0}, ", ii.idr[item.ColumnName]);
        //                }
        //                else
        //                {
        //                    if (item.AllowDBNull)
        //                    {
        //                        ii.sb.Append(" Null, ");
        //                    }
        //                    else
        //                    {
        //                        ii.sb.AppendFormat(" {0}, ", ii.idr[item.ColumnName]);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (!string.IsNullOrWhiteSpace(ii.idr[item.ColumnName].ToString()))
        //                {
        //                    ii.sb.AppendFormat(" '{0}', ", ii.idr[item.ColumnName]);
        //                }
        //                else
        //                {
        //                    if (item.AllowDBNull)
        //                    {
        //                        ii.sb.Append(" Null, ");
        //                    }
        //                    else
        //                    {
        //                        ii.sb.AppendFormat(" '{0}', ", ii.idr[item.ColumnName]);
        //                    }
        //                }
        //            }
        //        }
        //        ii.sb = ii.sb.Remove(ii.sb.ToString().LastIndexOf(','), 1);
        //        ii.sb.Append(" );\r\n ");
        //    }
        //    if (ii.I_wc == 1)//计算是否该插入
        //    {
        //        if (ii.I_oi == ii.I_ti + 1)
        //        {//写入数据库中
        //            try
        //            {
        //                SPs.Sp_mySql(ii.sb.ToString()).Execute();
        //            }
        //            catch
        //            {/*抛出异常,只有一次异常,如果错就是0,全部*/
        //                ii.I_ok = 0;
        //                ii.I_no = ii.I_oi;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (ii.I_mc <= ii.I_wc)
        //        {
        //            if (ii.I_mc != 0)
        //            {
        //                //最后一条,导入
        //                if (ii.I_mc * ii.I_wi + 1 == ii.I_ti + 1)
        //                {
        //                    try
        //                    {
        //                        SPs.Sp_mySql(ii.sb.ToString()).Execute();
        //                    }
        //                    catch
        //                    { /*抛出异常,异常一次,需要减去N*M条数据*/
        //                        if (ii.I_mc == 1)
        //                        {
        //                            ii.I_ok = ii.I_ok - ii.I_wi - 1;
        //                            ii.I_no = ii.I_no + ii.I_wi + 1;
        //                        }
        //                        else
        //                        {
        //                            ii.I_ok = ii.I_ok - ii.I_wi - 0;
        //                            ii.I_no = ii.I_no + ii.I_wi + 0;
        //                        }
        //                    }
        //                    //俩个字符串都进行清空
        //                    ii.sb.Clear();
        //                    //ii.mb.Clear();
        //                    ii.I_mc++;
        //                }
        //                else if (ii.I_oi == ii.I_ti + 1)
        //                {
        //                    //这里的计数,不是那样的,应该这样
        //                    try
        //                    {
        //                        SPs.Sp_mySql(ii.sb.ToString()).Execute();
        //                    }
        //                    catch
        //                    { /*抛出异常,异常一次,需要减去N*M条数据*/
        //                        ii.I_ok = ii.I_ok - (ii.I_oi - (ii.I_mc * ii.I_wi)) - 0;
        //                        ii.I_no = ii.I_no + (ii.I_oi - (ii.I_mc * ii.I_wi)) - 0;
        //                    }
        //                    //俩个字符串都进行清空
        //                    ii.sb.Clear();
        //                    //ii.mb.Clear();
        //                    ii.I_mc++;
        //                }
        //            }
        //            else
        //            {
        //                ii.I_mc++;
        //            }
        //        }
        //    }
        //}
        #endregion

    }
}