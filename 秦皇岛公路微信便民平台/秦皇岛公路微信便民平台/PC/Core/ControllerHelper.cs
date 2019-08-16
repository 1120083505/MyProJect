using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Core
{
    /// <summary>
    /// Controller 查询帮助类
    /// </summary>
    public class ControllerHelper
    {
        #region 解析GetList传入参数queryStr,完成查询
        /// <summary>
        /// 截取字符串，存入自定义qList实体对象
        /// <summary>
        /// <param name="pager">分页参数</param>
        /// <param name="queryStr">查询参数</param>
        /// <returns>List</returns>
        public List<QueryModel> getQList(string queryStr)
        {
            List<QueryModel> qList = new List<QueryModel>();
            if (!string.IsNullOrEmpty(queryStr))
            {
                string[] strs = queryStr.Split('&');
                for (int i = 0; i < strs.Length; i++)
                {
                    try
                    {
                        QueryModel q = new QueryModel();
                        q.filed = strs[i].Split('=')[0];
                        q.text = HttpUtility.UrlDecode(strs[i].Split('=')[1]).Trim();
                        qList.Add(q);
                    }
                    catch
                    {
                        //错误
                    }
                }
            }
            return qList;
        }

        /// <summary>
        /// 根据字段名从qList实体对象中查找出对应值
        /// <summary>
        /// <param name="qList"></param>
        /// <param name="filed"></param>
        /// <returns></returns>
        public string GetQueryStr(List<QueryModel> qList, string filed)
        {
            if (qList.Count > 0)
            {
                var q = from r in qList
                        where r.filed.ToLower() == filed.ToLower()
                        select r.text.ToString();
                foreach (string f in q)
                {
                    return f.ToString();
                }
            }
            return "";
        }
        #endregion
        #region JSON 返回结果的JSON
        /// <summary>
        /// JSON 返回结果的JSON
        /// </summary>
        /// <param name="status">返回结果</param>
        /// <param name="Memo">返回结果说明</param>
        /// <returns>JsonResult</returns>
        public static JsonResult jsonresult(int status, string Memo)
        {
            var res = new JsonResult();
            var json = new { Status = status, Memo = Memo };
            res.Data = json;
            return res;
        }
        #endregion
    }
}
