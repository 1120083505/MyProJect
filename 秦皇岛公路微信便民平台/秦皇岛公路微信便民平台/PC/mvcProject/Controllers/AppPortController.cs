using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using ZrSoft;
using SubSonic;
using Models;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
//using WxPayAPI;

namespace mvcProject.Controllers
{
    public class AppPortController : Controller
    {
        //
        // GET: /AppPort/
        public string msg = "";
        public int status = 1;
        [HttpPost]
        public JsonResult GetUserinfo(string MOBILE)
        {
            CRM_UserInfo CMUI = new CRM_UserInfo(CRM_UserInfo.Columns.mobile, MOBILE);
            if (string.IsNullOrEmpty(CMUI.Id))
            {
                return ControllerHelper.jsonresult(1, "不存在！");
            }
            var josn = new
            {
                status = 0,
                CMUI.Id,
                CMUI.mobile,
                CMUI.memberNameCn,
                CMUI.membershipCode,
                CMUI.storeCode,
                CMUI.gender,
                birthday=string.Format("{0:yyyy-MM-dd}", CMUI.birthday),
                CMUI.certCode,
                CMUI.channelCode,
            };
            return Json(josn);
        }
        [HttpPost]
        public JsonResult InsertUserinfo(UserInfo model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.channelCode))
                {
                    status = 0;
                    msg = Tip.InsertFail;
                    return ControllerHelper.jsonresult(status, msg);
                }
                CRM_UserInfo CRM = new CRM_UserInfo();
                CRM.Id = Utils.GetNewDateID();
                if (string.IsNullOrEmpty(model.birthday))
                {
                    CRM.birthday= DateTime.Now;
                }
                else
                {
                    CRM.birthday = DateTime.Parse(model.birthday);
                }                
                CRM.certCode = model.certCode;
                CRM.mobile = model.mobile;
                CRM.channelCode = model.channelCode;
                CRM.gender = model.gender == "0" ? "m" : "f";
                CRM.memberNameCn = model.memberNameCn;
                CRM.membershipCode = model.membershipCode;
                CRM.storeCode = model.storeCode;
                CRM.channelCode = model.channelCode;               
                CRM.Save();
                status = 1;
                msg = CRM.Id;
            }
            catch(Exception EX)
            {
                status = 0;
                msg = Tip.InsertFail;
            }           
            return ControllerHelper.jsonresult(status, msg);
        }
        [HttpPost]
        public JsonResult UpdateUserinfo(UserInfo model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.channelCode))
                {
                    status = 0;
                    msg = Tip.InsertFail;
                    return ControllerHelper.jsonresult(status, msg);
                }
                CRM_UserInfo CRM = new CRM_UserInfo(model.id);
                if (string.IsNullOrEmpty(model.birthday))
                {
                    CRM.birthday = DateTime.Now;
                }
                else
                {
                    CRM.birthday = DateTime.Parse(model.birthday);
                }
                CRM.certCode = model.certCode;
                CRM.mobile = model.mobile;
                CRM.channelCode = model.channelCode;
                CRM.gender = model.gender == "0" ? "m" : "f";
                CRM.memberNameCn = model.memberNameCn;
                CRM.membershipCode = model.membershipCode;
                CRM.storeCode = model.storeCode;
                CRM.channelCode = model.channelCode;
                CRM.Save();
                status = 1;
                msg = CRM.Id;
            }
            catch (Exception EX)
            {
                status = 0;
                msg = Tip.InsertFail;
            }
            return ControllerHelper.jsonresult(status, msg);
        }
        public class UserInfo
        {
            public string status { get; set; }
            public string memberNameCn { get; set; }
            public string gender { get; set; }
            public string mobile { get; set; }
            public string membershipCode { get; set; }
            public string channelCode { get; set; }
            public string certCode { get; set; }
            public string birthday { get; set; }
            public string storeCode { get; set; }
            public string id { get; set; }
            public string HYID { get; set; }
            public string GUID { get; set; }
        }
    }
}
