using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mvcProject.Controllers
{
    public class ImportController : Controller
    {
        //
        // GET: /Import/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Read(string url, string cols)
        {
            int num = 0;
            int status = 0;
            try
            {
                DataTable dt = oUtilss.ReadExcelByOledb(Server.MapPath("/" + url));
                if (dt.Rows.Count > 0)
                {
                    num = dt.Rows.Count;
                }
                status = 1;
            }
            catch (Exception ex)
            {
                status = 0;
                num = 0;
            }
            var json = new
            {
                Status = status,
                num = num
            };
            return Json(json);
        }

        #region 将datatable数据转换成JSON数据
        public static string DataTableToJson(DataTable dt, string DateColumns)
        {
            DateColumns = "," + DateColumns + ",";
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (DateColumns.Contains("," + j + ","))
                        {
                            try
                            {
                                Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DateTime.FromOADate(Convert.ToDouble(dt.Rows[i][j])) + "\"");
                            }
                            catch
                            {
                                Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                            }
                        }
                        else
                        {
                            Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]");
            return Json.ToString();
        }
        #endregion

    }
}
