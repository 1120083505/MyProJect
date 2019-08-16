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

namespace mvcProject.Areas.Sys.Controllers
{
    public class ModuleController : Controller
    {
        public string msg = "";
        public int status = 1;
        ControllerHelper c = new ControllerHelper();
        string LogStr = "";
        QueryPaged query = new QueryPaged();
        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr, string id)
        {
            List<QueryModel> qList = c.getQList(queryStr);
            SqlQuery sq = GetQuery(qList, id);
            List<Sys_Module> list = sq.ExecuteTypedList<Sys_Module>();
            pager.totalRows = sq.GetRecordCount();
            var json =
                from r in list
                select new
                {
                    Name = r.Name,
                    Id = r.Id,
                    ParentID = r.ParentId,
                    Url = r.Url,
                    EnName = r.EnName,
                    Sort = r.Sort,
                    Icon = r.Icon,
                    IsLast = r.IsLast,
                    state = r.IsLast == 1 ? "open" : "closed",
                    IsShow = r.IsShow,
                    iconCls = r.Icon
                };
            return Json(json);
        }
        [HttpPost]
        public JsonResult NewGetList(GridPager pager, string queryStr, string id)
        {
            if (pager.rows == 0)
                pager.rows = 10000;// Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = Sys_Module.Schema;
            query.init();
            GetQuery(qList, id);
            int total = 0;
            List<Sys_Module> list = GetQuery(qList, id).ExecuteTypedList<Sys_Module>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    Name = r.Name,
                    EnName = r.EnName,
                    ParentId = r.ParentId,
                    Url = r.Url,
                    Icon = r.Icon,
                    IsLast = r.IsLast,
                    Enable = r.Enable,
                    Sort = r.Sort,
                    IsShow = r.IsShow,
                    AdminId = r.AdminId,
                    PubDate = r.PubDate.ToString("yyyy-MM-dd"),
                    Memo = r.Memo

                })
            };
            return Json(json);
        }

        [HttpPost]//点击事件加载
        public JsonResult NewGetOperateList_1(string Id)
        {
            SqlQuery sq = new Select().From<Sys_Module>();
            //Sys_Module model = new Sys_Module(Id);
            //if (model.ParentId == "0")
            //{
            //    Sys_Module model_1 = new Sys_Module(Sys_Module.Columns.ParentId, model.Id);
            //    if (!string.IsNullOrEmpty(model_1.Id))
            //    {
            //        sq.Where(Sys_Module.Columns.ParentId).IsEqualTo(Id);
            //    }
            //    else
            //    {
            //        sq.Where(Sys_Module.Columns.Id).IsEqualTo(Id);
            //    }
            //}
            //else
            //{
            //    sq.Where(Sys_Module.Columns.Id).IsEqualTo(Id);
            //}
            sq.Where(Sys_Module.Columns.Id).IsEqualTo(Id);
            List<Sys_Module> list = sq.ExecuteTypedList<Sys_Module>();
            var json = new
            {
                rows = list.Select((r, i) => new
                {
                    RowNumber = i + 1,
                    Name = r.Name,
                    Id = r.Id,
                    ParentID = r.ParentId,
                    Url = r.Url,
                    EnName = r.EnName,
                    Sort = r.Sort,
                    Icon = r.Icon,
                    IsLast = r.IsLast,
                    state = r.IsLast == 1 ? "open" : "closed",
                    IsShow = r.IsShow == 1 ? "是" : "否",
                    iconCls = r.Icon
                })
            };
            return Json(json);
        }


        [HttpPost]
        public JsonResult GetOperateList(string ModuleID)
        {
            List<Sys_ModuleOperate> list = new Select().From<Sys_ModuleOperate>()
                .Where(Sys_ModuleOperate.Columns.ModuleID).IsEqualTo(ModuleID)
                .OrderAsc(Sys_ModuleOperate.Columns.Sort)
                .ExecuteTypedList<Sys_ModuleOperate>();
            var json =
                from r in list
                select r;
            return Json(json);
        }
        [HttpPost]
        public JsonResult NewGetOperateList(string ModuleId)
        {
            List<Sys_ModuleOperate> list = new Select().From<Sys_ModuleOperate>()
                .Where(Sys_ModuleOperate.Columns.ModuleID).IsEqualTo(ModuleId)
                .OrderAsc(Sys_ModuleOperate.Columns.Sort)
                .ExecuteTypedList<Sys_ModuleOperate>();
            //var json =
            //    from r in list
            //    select r;
            var json = new
            {
                rows = list.Select((r, i) => new
                {
                    Id = r.Id,
                    Name = r.Name,
                    KeyCode = r.KeyCode,
                    ModuleID = r.ModuleID,
                    Sort = r.Sort,
                    Icon = r.Icon,
                    IsBtn = r.IsBtn == 1 ? "是" : "否"
                })
            };
            return Json(json);
        }
        //拼接查询条件
        public SqlQuery GetQuery(List<QueryModel> qList, string id)
        {
            SqlQuery sq = new Select().From<Sys_Module>();
            if (!string.IsNullOrEmpty(id))
            {
                sq.AndExpression(Sys_Module.Columns.ParentId).IsEqualTo(id);
            }
            sq.OrderAsc(Sys_Module.Columns.Sort);
            sq.ExecuteTypedList<Sys_Module>();
            return sq;
        }
        #region Create
        [PowerFilter]
        public ActionResult Create(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.ParentId = id;
                ViewBag.ParentName = new Select(Sys_Module.Columns.Name).From<Sys_Module>().Where(Sys_Module.Columns.Id).IsEqualTo(id).ExecuteScalar<string>();
            }
            else
            {
                ViewBag.ParentId = "0";
                ViewBag.ParentName = "顶级菜单";
            }
            return View();
        }

        [HttpPost]
        public JsonResult Create(Sys_Module model)
        {
            try
            {
                model.Id = Utils.GetNewDateID();
                model.PubDate = DateTime.Now;
                model.AdminId = LoginInfo.AdminID;
                model.Save();
                if (model.IsLast == 1)
                {
                    //最后一项则进行基本操作的添加
                    DataService.ExecuteQuery(new QueryCommand("EXEC sp_MouleIsLast '" + model.Id + "'"));
                }
                msg = Tip.InsertSucceed;
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.InsertFail + Utils.NoHTML(e.Message);
            }
            //return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region Edit

        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Module model = new Sys_Module(id);
            string Name = new Select(Sys_Module.Columns.Name).From<Sys_Module>().Where(Sys_Module.Columns.Id).IsEqualTo(model.ParentId).ExecuteScalar<string>();
            if (!string.IsNullOrEmpty(Name))
            {
                ViewBag.ParentName = Name;
            }
            else
            {
                ViewBag.ParentName = "顶级菜单";
            }

            Sys_Module entity = new Sys_Module(id);
            return View(entity);
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Module model)
        {
            try
            {
                Sys_Module entity = new Sys_Module(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    int entityIslast = entity.IsLast;
                    entity.AdminId = model.AdminId;
                    entity.Enable = model.Enable;
                    entity.EnName = model.EnName;
                    entity.Icon = model.Icon;
                    entity.IsLast = model.IsLast;
                    entity.Memo = model.Memo;
                    entity.Name = model.Name;
                    entity.PubDate = model.PubDate;
                    entity.Sort = model.Sort;
                    entity.Url = model.Url;
                    entity.IsShow = model.IsShow;
                    entity.Save();
                    msg = Tip.EditSucceed;
                    if (model.IsLast == 1 && entityIslast == 0)
                    {
                        //最后一项则进行基本操作的添加
                        DataService.ExecuteQuery(new QueryCommand("EXEC sp_MouleIsLast '" + model.Id + "'"));
                    }
                    else
                    {
                        //修改为不是第一项时，应删除以前的操作。连同权限部分
                    }
                }
                else
                {
                    status = 0;
                    msg = Tip.EditSucceed + Tip.GetParmError;
                }
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.EditFail + Utils.NoHTML(e.Message);
            }
            //return Json("{\"Status\":\"" + status + "\",\"Memo\":\"" + msg + "\"}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region Delete
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    //删除权限表中关联的数据
                    string sql = "DELETE dbo.Sys_Power WHERE ModuleOperateID IN(SELECT ID FROM dbo.Sys_ModuleOperate WHERE ModuleID='" + id + "')";
                    DataService.ExecuteQuery(new QueryCommand(sql));
                    //删除操作
                    Sys_ModuleOperate.Delete(Sys_ModuleOperate.Columns.ModuleID, id);
                    //删除模块
                    Sys_Module.Delete(id);
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
            //return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region  OperateCreate

        //[PowerFilter]
        public ActionResult OperateCreate(string id)
        {
            ViewBag.Module = id;
            return View();
        }

        [HttpPost]
        //[PowerFilter]
        public JsonResult OperateCreate(Sys_ModuleOperate model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //后台解密
                    //byte[] outputb = Convert.FromBase64String(model.Icon);
                    model.Id = Utils.GetNewDateID();
                    //model.Icon = Encoding.Default.GetString(outputb);
                    model.Save();
                    msg = Tip.InsertSucceed;
                }
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            //return Json("{\"Status\":\"" + status + "\",\"Memo\":\"" + msg + "\"}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region OperateEdit
        //[PowerFilter]
        public ActionResult OperateEdit(string id)
        {
            Sys_ModuleOperate entity = new Sys_ModuleOperate(id);
            return View(entity);
        }

        [HttpPost]
        //[PowerFilter]
        public JsonResult OperateEdit(Sys_ModuleOperate model)
        {
            try
            {
                Sys_ModuleOperate entity = new Sys_ModuleOperate(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    entity.IsBtn = model.IsBtn;
                    entity.Icon = model.Icon;
                    entity.KeyCode = model.KeyCode;
                    //entity.ModuleID = model.ModuleID;
                    entity.Name = model.Name;
                    entity.Sort = model.Sort;
                    entity.Save();
                    msg = Tip.EditSucceed;
                }
                else
                {
                    status = 0;
                    msg = Tip.EditSucceed + Tip.GetParmError;
                }
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.EditFail + Utils.NoHTML(e.Message);
            }
            //return Json("{\"Status\":\"" + status + "\",\"Memo\":\"" + msg + "\"}");
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region  OperateDelte
        [HttpPost]
        //[PowerFilter]
        public JsonResult OperateDelete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    //删除已有权限
                    Sys_Power.Delete(Sys_Power.Columns.ModuleOperateID, id);
                    //删除操作
                    Sys_ModuleOperate.Delete(id);
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
                status = 0;
                msg = Tip.DeleteFail + Tip.GetParmError;

            }
            //return Json("{\"Status\":\"" + status + "\",\"Memo\":\"" + msg + "\"}");
            return ControllerHelper.jsonresult(status, msg);

        }
        #endregion

        #region icon
        [HttpPost]
        public JsonResult GetIcons()
        {
            string str = "";
            DataTable dt = new DataTable();
            string url = Server.MapPath("~/Content/icons/icon");
            try
            {
                dt.Columns.Add(new DataColumn("fileName", typeof(string)));
                DataRow dr;
                DirectoryInfo dir = new DirectoryInfo(url);
                FileInfo[] fi = dir.GetFiles();
                if (fi.Length > 0)
                {
                    foreach (FileInfo dChild in fi)
                    {
                        if (dChild.Extension.ToLower() == ".png")
                        {
                            dr = dt.NewRow();
                            dr[0] = dChild.Name;
                            dt.Rows.Add(dr);
                        }
                    }
                }
                str = Utils.DataTableToJson(dt, "1", dt.Rows.Count.ToString(), "");
            }
            catch (Exception eicon)
            {
                str = Utils.DataTableToJson(dt, "0", "", "失败原因：" + eicon.Message);
            }
            return Json(str);
        }
        #endregion


        [HttpPost]
        public JsonResult GetMenuList(string id)
        {
            //id 既可以是RoleId也可以是AdminID


            SqlQuery sq = new Select().From<Sys_Module>().OrderAsc(Sys_Module.Columns.IsLast, Sys_Module.Columns.Sort);
            List<Sys_Module> menuList = sq.ExecuteTypedList<Sys_Module>();
            SqlQuery sqLast = new Select().From<Sys_ModuleOperate>().OrderAsc(Sys_ModuleOperate.Columns.Sort);
            List<Sys_ModuleOperate> pList = sqLast.ExecuteTypedList<Sys_ModuleOperate>();
            List<Sys_Power> ownList = new Select().From<Sys_Power>()
                .Where(Sys_Power.Columns.RoleID).IsEqualTo(id)
                .ExecuteTypedList<Sys_Power>();
            object json = buildSonJson(menuList, pList, ownList, "0");
            return Json(json);
        }
        public object buildSonJson(List<Sys_Module> list, List<Sys_ModuleOperate> pList, List<Sys_Power> ownList, string pid)
        {
            string json = "[";
            var q = from r in list
                    where r.ParentId == pid
                    select new
                    {
                        text = r.Name,
                        id = r.Id,
                        IsLast = r.IsLast,
                        state = "closed",
                        iconCls = r.Icon,
                        children = r.IsLast == 0 ? buildSonJson(list, pList, ownList, r.Id) :
                        from m in pList
                        where m.ModuleID == r.Id
                        select new
                        {
                            text = m.Name,
                            id = m.Id,
                            iconCls = m.Icon,
                            @checked = (from y in ownList
                                        where y.ModuleOperateID == m.Id
                                        select y).Count() == 0 ? false : true
                        }
                    };
            return q;

        }



        [HttpPost]//加载树
        public JsonResult GetMenuList_1(string id)
        {
            object json;
            if (string.IsNullOrEmpty(id))
            {
                //id 既可以是RoleId也可以是AdminID
                SqlQuery sq = new Select().From<Sys_Module>().Where(Sys_Module.Columns.IsShow).IsEqualTo(1).OrderAsc(Sys_Module.Columns.IsLast, Sys_Module.Columns.Sort);
                List<Sys_Module> menuList = sq.ExecuteTypedList<Sys_Module>();
                json = buildSonJson_1(menuList, "0");
                return Json(json);
            }
            else
            {
                //json = "";
                //return Json(json);
                SqlQuery sq = new Select().From<Sys_Module>().Where(Sys_Module.Columns.IsShow).IsEqualTo(1)
                    .And(Sys_Module.Columns.ParentId).IsEqualTo(id).OrderAsc(Sys_Module.Columns.IsLast, Sys_Module.Columns.Sort);
                List<Sys_Module> menuList = sq.ExecuteTypedList<Sys_Module>();
                json = buildSonJson_1(menuList, id);
                return Json(json);
            }
        }
        public object buildSonJson_1(List<Sys_Module> list, string pid)
        {
            var q = from r in list
                    where r.ParentId == pid
                    select new
                    {
                        text = r.Name,
                        id = r.Id,
                        iconCls = r.Icon,
                        state = r.IsLast == 1 ? "open" : "closed",

                        children =
                        from m in list

                        where m.ParentId == r.Id

                        select new
                        {
                            text = m.Name,
                            id = m.Id,
                            iconCls = m.Icon,
                            state = m.IsLast == 1 ? "open" : "closed"
                        }
                    };
            return q;

        }
    }
}
