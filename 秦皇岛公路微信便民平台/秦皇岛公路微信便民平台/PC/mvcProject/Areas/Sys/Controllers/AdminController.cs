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

namespace mvcProject.Areas.Sys.Controllers
{
    public class AdminController : Controller
    {
        public string msg = "";
        string LogStr = "";
        public int status = 1;//1代表成功 0 失败

        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        [PowerFilter]
        public ActionResult Index()
        {
            return View();
        }
        // [PowerFilter]
        public ActionResult Info(string id)
        {
            Sys_Admin entity = new Sys_Admin(id);
            entity.LoginPwd = Utils.DESDecryptMethod(entity.LoginPwd);
            return View(entity);
        }
        [HttpPost]
        [LoginPower]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            if (pager.rows == 0)
                pager.rows = Core.Config.PageSize;
            List<QueryModel> qList = c.getQList(queryStr);
            query.pager = pager;
            query.TableName = VSys_Admin.Schema;
            query.init();
            GetQuery(qList);
            int total = 0;
            List<VSys_Admin> list = query.Paged(ref total).ExecuteTypedList<VSys_Admin>();
            var json = new
            {
                total = total,
                pager = query.pager,
                rows = list.Select((r, i) => new
                {
                    RowNumber = (i++) + (pager.page - 1) * pager.rows + 1,
                    Id = r.Id,
                    RealName = r.RealName,
                    PubDate = r.PubDate.ToShortDateString(),
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                    IsLogin = r.IsLogin,
                    LoginName = r.LoginName,
                    Email = r.Email
                })
            };
            return Json(json);
        }
        [HttpPost]
        public JsonResult GetAllList()
        {
            SqlQuery sq = new Select().From<Sys_Admin>();
            List<Sys_Admin> list = sq.ExecuteTypedList<Sys_Admin>();
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new
                        {
                            Id = r.Id,
                            Name = r.LoginName,
                            RealName = r.RealName,
                        }
                ).ToArray()
            };
            return Json(json);
        }
        #region 拼接查询条件
        //拼接查询条件
        public void GetQuery(List<QueryModel> qList)
        {
            query.Like(qList, VSys_Admin.Columns.RealName);
            query.Like(qList, VSys_Admin.Columns.LoginName);
            query.Like(qList, VSys_Admin.Columns.RoleId);

        }
        #endregion

        #region Create
        [PowerFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Create(Sys_Admin model)
        {
            try
            {
                SqlQuery sq = new Select().From<Sys_Admin>()
                    .Where(Sys_Admin.Columns.LoginName).IsEqualTo(model.LoginName);
                if (sq.GetRecordCount() == 0)
                {
                    model.Id = Utils.GetNewDateID();
                    model.PubDate = DateTime.Now;
                    model.LoginPwd = Utils.DESEncryptMethod(model.LoginPwd);
                    model.Save();
                    status = 1;
                    msg = Tip.InsertSucceed;
                    GUI.InsertLog("管理员管理", "新增", "[" + model.Id + "]用户名：" + model.LoginName + ",真实姓名:" + model.RealName);
                }
                else
                {
                    status = 0;
                    msg = Tip.InsertFail + "登录名称已经存在！";
                    GUI.InsertLog("管理员管理", "新增", "失败：" + msg + ",[" + model.Id + "]用户名：" + model.LoginName + ",真实姓名:" + model.RealName);
                }
            }
            catch
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region Edit
        [PowerFilter]
        public ActionResult Edit(string id)
        {
            Sys_Admin entity = new Sys_Admin(id);
            entity.LoginPwd = Utils.DESDecryptMethod(entity.LoginPwd);
            return View(entity);
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult Edit(Sys_Admin model)
        {
            string LogStr = "";
            try
            {
                Sys_Admin entity = new Sys_Admin(model.Id);
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    SqlQuery sq = new Select().From<Sys_Admin>()
                   .Where(Sys_Admin.Columns.LoginName).IsEqualTo(model.LoginName)
                   .AndExpression(Sys_Admin.Columns.Id).IsNotEqualTo(entity.Id);
                    if (sq.GetRecordCount() == 0)
                    {
                        LogStr = "[" + model.Id + "]"
                           + "用户名：" + model.LoginName + "[" + entity.LoginName + "],"
                           + "真实姓名:" + model.RealName + "[" + entity.RealName + "]";
                        entity.RealName = model.RealName;
                        entity.IsLogin = model.IsLogin;
                        entity.LoginName = model.LoginName;
                        //entity.CustodyId = model.CustodyId;
                        entity.LoginPwd = Utils.DESEncryptMethod(model.LoginPwd);
                        entity.RoleId = model.RoleId;
                        entity.Email = model.Email;
                        entity.Address = model.Address;
                        entity.Phone = model.Phone;
                        entity.Save();
                        status = 1;
                        msg = Tip.EditSucceed;
                    }
                    else
                    {
                        status = 0;
                        msg = Tip.InsertFail + "登录名称已经存在！";
                    }
                }
                else
                {
                    status = 0;
                    msg = Tip.EditFail;
                }
                GUI.InsertLog("管理员管理", "编辑", msg + "。" + LogStr);
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.EditFail + Utils.NoHTML(e.Message);
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        #endregion

        #region changepass
        [PowerFilter]
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        [PowerFilter]
        public JsonResult ChangePass(string pass, string OldPass)
        {
            try
            {
                Sys_Admin entity = new Sys_Admin(LoginInfo.AdminID);

                if (OldPass == Utils.DESDecryptMethod(entity.LoginPwd))
                {
                    entity.LoginPwd = Utils.DESEncryptMethod(pass);
                    entity.Save();
                    status = 1;
                    msg = Tip.OperateSucceed;
                }
                else
                {
                    status = 0;
                    msg = Tip.EditFail + "原密码错误！";
                }
            }
            catch (Exception e)
            {
                status = 0;
                msg = Tip.EditFail + Utils.NoHTML(e.Message);
            }
            GUI.InsertLog("首页", "修改密码", msg);
            return Json("{\"Status\":\"" + status + "\",\"Memo\":\"" + msg + "\"}");
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
                    //这里书写需要删除的逻辑代码
                    new Delete().From<Sys_Admin>().Where(Sys_Admin.Columns.Id).In(id.Split(','))
                        .AndExpression(Sys_Admin.Columns.Id).IsNotEqualTo("201411121153127198-3bbd-l4j82l")
                    .Execute();
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
            GUI.InsertLog("管理员管理", "删除", msg + LogStr);
            return ControllerHelper.jsonresult(status, msg);

        }
        #endregion
    }
}
