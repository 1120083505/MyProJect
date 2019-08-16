using Models;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public class QueryPaged
    {

        /// <summary>
        /// 分页
        /// </summary>
        public GridPager pager;

        /// <summary>
        /// 表名
        /// </summary>
        public TableSchema.Table TableName;
        public SqlQuery SqlIn;
        public SqlQuery SqlNotIn;
        public SqlQuery SqlTotal;
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {

            if (pager==null)
            {
                pager = new GridPager();
                pager.rows = Core.Config.PageSize;
                pager.page = 1;
                pager.sort = "id";
                pager.order = "Asc";
            }
            SqlIn = new Select().Top(pager.rows.ToString()).From(TableName);
            int p = pager.rows * (pager.page - 1);
            SqlNotIn = new Select(pager.sort).Top(p.ToString()).From(TableName);
            SqlTotal = new Select().From(TableName);
        }


        #region IsEqualTo
        /// <summary>
        /// SqlQuery 等于（=）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void IsEqualTo(List<QueryModel> qList, string Columns)
        {

            QueryHelper.IsEqualTo(qList, SqlIn, Columns);
            QueryHelper.IsEqualTo(qList, SqlNotIn, Columns);
            QueryHelper.IsEqualTo(qList, SqlTotal, Columns);
        }
        /// <summary>
        /// SqlQuery 等于（=）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void IsEqualTo(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.IsEqualTo(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.IsEqualTo(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.IsEqualTo(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        #region Like
        /// <summary>
        /// SqlQuery 相似（Like）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void Like(List<QueryModel> qList, string Columns)
        {
            QueryHelper.Like(qList, SqlIn, Columns);
            QueryHelper.Like(qList, SqlNotIn, Columns);
            QueryHelper.Like(qList, SqlTotal, Columns);

        }

        /// <summary>
        /// SqlQuery 相似（Like）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void Like(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.Like(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.Like(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.Like(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        #region IsGreaterThan
        /// <summary>
        /// SqlQuery 大于（＞）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void IsGreaterThan(List<QueryModel> qList, string Columns)
        {
            QueryHelper.IsGreaterThan(qList, SqlIn, Columns);
            QueryHelper.IsGreaterThan(qList, SqlNotIn, Columns);
            QueryHelper.IsGreaterThan(qList, SqlTotal, Columns);
        }

        /// <summary>
        /// SqlQuery 大于（＞）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void IsGreaterThan(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.IsGreaterThan(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.IsGreaterThan(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.IsGreaterThan(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        #region IsGreaterThanOrEqualTo
        /// <summary>
        /// SqlQuery 大于等于（≥）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void IsGreaterThanOrEqualTo(List<QueryModel> qList, string Columns)
        {
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlIn, Columns, Columns);
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlNotIn, Columns, Columns);
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlTotal, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 大于等于（≥）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void IsGreaterThanOrEqualTo(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.IsGreaterThanOrEqualTo(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        #region IsLessThan
        /// <summary>
        /// SqlQuery 小于（＜）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void IsLessThan(List<QueryModel> qList, string Columns)
        {
            QueryHelper.IsLessThan(qList, SqlIn, Columns, Columns);
            QueryHelper.IsLessThan(qList, SqlNotIn, Columns, Columns);
            QueryHelper.IsLessThan(qList, SqlTotal, Columns, Columns);

        }

        /// <summary>
        /// SqlQuery 小于（＜）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void IsLessThan(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.IsLessThan(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.IsLessThan(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.IsLessThan(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        #region IsLessThanOrEqualTo
        /// <summary>
        /// SqlQuery 小于等于（≤）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="Columns">列名（列名与查询传值字段相同的情况下）</param>
        public void IsLessThanOrEqualTo(List<QueryModel> qList, string Columns)
        {
            QueryHelper.IsLessThanOrEqualTo(qList, SqlIn, Columns, Columns);
            QueryHelper.IsLessThanOrEqualTo(qList, SqlNotIn, Columns, Columns);
            QueryHelper.IsLessThanOrEqualTo(qList, SqlTotal, Columns, Columns);
        }

        /// <summary>
        /// SqlQuery 小于等于（≤）拼接查询
        /// </summary>
        /// <param name="qList">QueryModel泛型集合</param>
        /// <param name="ColumnsName">列名</param>
        /// <param name="QueryFiledName">查询传至字段名称</param>
        public void IsLessThanOrEqualTo(List<QueryModel> qList, string ColumnsName, string QueryFiledName)
        {
            QueryHelper.IsLessThanOrEqualTo(qList, SqlIn, ColumnsName, QueryFiledName);
            QueryHelper.IsLessThanOrEqualTo(qList, SqlNotIn, ColumnsName, QueryFiledName);
            QueryHelper.IsLessThanOrEqualTo(qList, SqlTotal, ColumnsName, QueryFiledName);
        }
        #endregion

        /// <summary>
        /// 分页查询语句结果
        /// </summary>
        /// <param name="TotalCount">总行数</param>
        /// <returns></returns>
        public SqlQuery Paged(ref int TotalCount)
        {
            TotalCount = paging();

            return Paged();
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <returns></returns>
        int paging()
        {
            pager.totalRows = SqlTotal.GetRecordCount();
            double totalRows = pager.totalRows;
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            double rows = pager.rows;
            pager.totalPages = int.Parse(Math.Ceiling((totalRows / rows)).ToString());
            return pager.totalRows;
        }
        /// <summary>
        /// 分页查询语句结果
        /// </summary>
        /// <returns></returns>
        public SqlQuery Paged()
        {
            SqlQuery sq = new SqlQuery();
            if (pager.order.ToLower() == "asc")
            {
                sq = SqlIn.And(pager.sort).NotIn(
                 SqlNotIn.And("1")
                 .IsEqualTo("1")
                 .OrderAsc(pager.sort))
                 .And("1")
                 .IsEqualTo("1")
                 .OrderAsc(pager.sort);
            }
            else
            {
                sq = SqlIn.And(pager.sort).NotIn(
                 SqlNotIn.And("1")
                 .IsEqualTo("1")
                 .OrderDesc(pager.sort))
                 .And("1")
                 .IsEqualTo("1")
                 .OrderDesc(pager.sort);

            }
            paging();
            return sq;
        }
    }
}
