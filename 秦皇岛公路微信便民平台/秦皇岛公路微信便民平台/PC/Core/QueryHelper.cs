using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using ZrSoft;
using System.Web;

namespace Core
{
    /// <summary>
    /// query查询帮助类
    /// </summary>
    public class QueryHelper
    {
        #region IsEqualTo
        /// <summary>
        /// SqlQuery 等于（=）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void IsEqualTo(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            IsEqualTo(qList, sq, Columns, Columns);
        }
        /// <summary>
        /// SqlQuery 等于（=）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void IsEqualTo(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                sq.And(ColumnsName).IsEqualTo(c.GetQueryStr(qList, QueryFiledName));
            }
        }
        #endregion

        #region Like
        /// <summary>
        /// SqlQuery 相似（Like）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void Like(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            Like(qList, sq, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 相似（Like）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void Like(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                sq.And(ColumnsName).Like("%" + c.GetQueryStr(qList, QueryFiledName) + "%");
            }
        }
        #endregion

        #region IsGreaterThan
        /// <summary>
        /// SqlQuery 大于（＞）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void IsGreaterThan(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            IsGreaterThan(qList, sq, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 大于（＞）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void IsGreaterThan(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                sq.And(ColumnsName).IsGreaterThan(c.GetQueryStr(qList, QueryFiledName));
            }
        }
        #endregion

        #region IsGreaterThanOrEqualTo
        /// <summary>
        /// SqlQuery 大于等于（≥）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void IsGreaterThanOrEqualTo(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            IsGreaterThanOrEqualTo(qList, sq, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 大于等于（≥）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void IsGreaterThanOrEqualTo(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                sq.And(ColumnsName).IsGreaterThanOrEqualTo(c.GetQueryStr(qList, QueryFiledName));
            }
        }
        #endregion

        #region IsLessThan
        /// <summary>
        /// SqlQuery 小于（＜）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void IsLessThan(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            IsLessThan(qList, sq, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 小于（＜）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void IsLessThan(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                //if (Utils.IsDateTime(c.GetQueryStr(qList, QueryFiledName)))
                //{
                //    DateTime dt = DateTime.Parse(c.GetQueryStr(qList, QueryFiledName));
                //    sq.And(ColumnsName).IsLessThan(dt.AddDays(1));
                //}
                //else
                //{
                //    sq.And(ColumnsName).IsLessThan(c.GetQueryStr(qList, QueryFiledName));
                //}
                sq.And(ColumnsName).IsLessThan(c.GetQueryStr(qList, QueryFiledName));
            }
        }
        #endregion

        #region IsLessThanOrEqualTo
        /// <summary>
        /// SqlQuery 小于等于（≤）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public static void IsLessThanOrEqualTo(List<QueryModel> qList, SqlQuery sq, string Columns)
        {
            IsLessThanOrEqualTo(qList, sq, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 小于等于（≤）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="sq">查询语句</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public static void IsLessThanOrEqualTo(List<QueryModel> qList, SqlQuery sq, string ColumnsName, string QueryFiledName)
        {
            ControllerHelper c = new ControllerHelper();
            if (!string.IsNullOrWhiteSpace(c.GetQueryStr(qList, QueryFiledName)))
            {
                sq.And(ColumnsName).IsLessThanOrEqualTo(c.GetQueryStr(qList, QueryFiledName));
            }
        }
        #endregion

        #region 排序方式
        /// <summary>
        /// 排序方式
        /// </summary>
        /// <param name="sq">原SqlQuery语句</param>
        /// <param name="order">排序方式</param>
        /// <param name="sort">排序字段</param>
        public static void Order(SqlQuery sq, string order, string sort)
        {
            ControllerHelper c = new ControllerHelper();
            if (order.ToLower() == "asc")
                sq.OrderAsc(sort);

            else
                sq.OrderDesc(sort);
        }
        #endregion

        #region Page
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="coulums">查询的值（为空查询全部）</param>
        /// <param name="rows">显示数</param>
        /// <param name="page">页码</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public static SqlQuery Page(List<QueryModel> qList, string[] coulums, Models.GridPager pager, string TableName)
        {
            int rows = pager.rows;
            int page = pager.page;
            ControllerHelper c = new ControllerHelper();
            SqlQuery sq = new SqlQuery();//实例化查询
            SqlQuery sq1 = new SqlQuery();
            SqlQuery sq2 = new SqlQuery();
            if (coulums == null)
            {
                sq = new Select().From("" + TableName + "");
                sq1 = new Select("Id").Top("" + rows + "").From("" + TableName + "");
                int p = rows * (page - 1);
                sq2 = new Select("Id").Top("" + p + "").From("" + TableName + "");
            }
            else
            {
                sq = new Select(coulums).From("" + TableName + "");
                sq1 = new Select("Id").Top("" + rows + "").From("" + TableName + "");
                int p = rows * (page - 1);
                sq2 = new Select("Id").Top("" + p + "").From("" + TableName + "");
            }
            if (c.GetQueryStr(qList, "searchtype") == "0") //精确
            {
                for (int i = 1; i < qList.Count; i++)
                {
                    IsEqualTo(qList, sq1, qList[i].filed);
                    IsEqualTo(qList, sq2, qList[i].filed);
                }
            }
            else//模糊
            {
                for (int i = 1; i < qList.Count; i++)
                {
                    Like(qList, sq1, qList[i].filed);
                    Like(qList, sq2, qList[i].filed);
                }
            }
            sq.Where("Id").In(
             sq1.And("Id").NotIn(
             sq2.And("1")
             .IsEqualTo("1")
             .OrderAsc("Id"))
             .And("1")
             .IsEqualTo("1")
             .OrderAsc("Id"));
            return sq;
        }
        #endregion
    }
}
