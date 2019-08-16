using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using SubSonic;
using ZrSoft;
using Core;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;

namespace mvcProject.Areas.Sys.Controllers
{
    public class BackupController : Controller
    {
        public string msg = "";
        public int status = 1;

        ControllerHelper c = new ControllerHelper();
        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("pubdate", typeof(string)));
            dt.Columns.Add(new DataColumn("size", typeof(string)));
            DataRow dr;
            string path = System.Configuration.ConfigurationSettings.AppSettings["backupPath"];
            DirectoryInfo dir = new DirectoryInfo(System.Configuration.ConfigurationSettings.AppSettings["backupPath"]+"\\");
            FileInfo[] fi = dir.GetFiles();
            if (fi.Length > 0)
            {
                foreach (FileInfo dChild in fi)
                {
                    dr = dt.NewRow();
                    dr[0] = dChild.Name;
                    dr[1] = dChild.CreationTime.ToString();
                    dr[2] = string.Format("{0}M", (double.Parse(dChild.Length.ToString()) / 1024 / 1024).ToString("0.00"));
                    dt.Rows.Add(dr);
                }
            }

            var json = new
            {
                total = pager.totalRows,
                rows = (from r in dt.AsEnumerable()
                        select new
                        {
                            Id = r["name"],
                            Name = r["name"],
                            Date = r["pubdate"],
                            Size = r["size"]
                        }
                        ).ToArray()

            };
            return Json(json);
        }

        #region Create
        [PowerFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Create(string Name)
        {
            try
            {
                string url = System.Configuration.ConfigurationSettings.AppSettings["backupPath"]; //Server.MapPath("/Backup");
                //Utils.AutoCreatDir(url);
                string filename = string.Format("{0}{1}.rar", Name, Utils.GetDateTimeNowStr());
                string path = url + "\\" + filename;
                if (System.IO.File.Exists(path) == true)
                {
                    status = 0;
                    msg = Tip.FileIsExist;
                }
                else
                {
                    StringBuilder sb_sql = new StringBuilder();
                    string target = System.Configuration.ConfigurationSettings.AppSettings["target"];
                    sb_sql.Append("use master; backup database [").Append(target).Append("] to disk ='").Append(path).Append("'");
                    DataService.ExecuteQuery(new QueryCommand(sb_sql.ToString()));
                    status = 1;
                    msg = Tip.OperateSucceed;
                }
            }
            catch(Exception e)
            {
                status = 0;
                msg = Tip.OperateFail+e.Message;
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion
        
        #region  Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    string url = Server.MapPath("/Backup");
                    string path = url + "\\" + id;
                    System.IO.File.Delete(path);
                    status = 1;
                    msg = Tip.DeleteSucceed;
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.DeleteFail + Utils.NoHTML(e.Message);
                }
            }
            else
            {

            }
            return ControllerHelper.jsonresult(status, msg);

        }
        #endregion

        #region  ReturnBack
        [HttpPost]
        [PowerFilter]
        public JsonResult ReturnBack(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    string Fname = id;
                    string url = Server.MapPath("/Backup");
                    string server = ConfigurationSettings.AppSettings["datasource"];
                    string name = ConfigurationSettings.AppSettings["name"];
                    string password = ConfigurationSettings.AppSettings["password"];
                    string target = ConfigurationSettings.AppSettings["target"];
                    StringBuilder sb_sql = new StringBuilder();
                    sb_sql.Append(" alter database [").Append(target).Append("] Set OffLine With RollBack Immediate ; restore database [")
                        .Append(target).Append("] from disk='").Append(url + "/" + id).Append("' with replace; ")
                        .Append(" alter database [").Append(target).Append("] Set ONLINE With RollBack Immediate ;");
                    StringBuilder connString = new StringBuilder();
                    connString.Append("server=").Append(server).Append(";database=master;uid=").Append(name).Append(";pwd=").Append(password);
                    try
                    {
                        DataService.ExecuteQuery(new QueryCommand(sb_sql.ToString()));
                        status = 1;
                        msg = Tip.OperateSucceed;

                    }
                    catch (Exception e)
                    {
                        status = 0;
                        msg = Tip.OperateFail + Utils.NoHTML(e.Message);
                    }
                }
                catch (Exception e)
                {
                    status = 0;
                    msg = Tip.OperateFail + Utils.NoHTML(e.Message);
                }
            }
            else
            {
                status = 0;
                msg = Tip.OperateFail + Tip.GetParmError;
            }
            return ControllerHelper.jsonresult(status, msg);

        }
        #endregion
    }
}
