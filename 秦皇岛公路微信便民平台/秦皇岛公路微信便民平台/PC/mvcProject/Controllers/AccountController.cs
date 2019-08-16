using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubSonic;
using ZrSoft;
using Core;

namespace mvcProject.Controllers
{
    public class AccountController : Controller
    {
        public string msg = "";
        public int status = 1;

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult NoPower()
        {
            return View();
        }
        public JsonResult Login(string name, string pwd, string code)
        {
            #region 是否可以登录
            //KeyValuePair<int, string> tm = errorHelper.CanUse();
            //if (tm.Key != 1)
            //{
            //    return Json("{Status:'" + 0 + "',Memo:'" + tm.Value + "'}");
            //}
            #endregion
            pwd = Utils.DESEncryptMethod(pwd);
            SqlQuery sq = new Select().From<Sys_Admin>()
                .Where(Sys_Admin.Columns.LoginName).IsEqualTo(name)
                .And(Sys_Admin.Columns.LoginPwd).IsEqualTo(pwd);



            // 先判断Ip是否已被限制
            string NowIp = System.Web.HttpContext.Current.Request.UserHostAddress;//取到当前的Ip
            //查到了  先查Ip  判断这个Ip是否还能登陆
            SqlQuery SqIp = new Select().From<Sys_Admin>()
                .Where(Sys_Admin.Columns.Ip)
                .IsEqualTo(NowIp);
            List<Sys_Admin> SqIpList = SqIp.ExecuteTypedList<Sys_Admin>();
            if (SqIpList.Count == 0)//如果用户表中没有与当前Ip相同的  那就看当前用户的错误登陆次数
            {
                //Sys_Dictionaries SDicEntity = new Sys_Dictionaries(Sys_Dictionaries.Columns.Ident, 1);
                //Sys_Admin adment = new Sys_Admin(Sys_Admin.Columns.LoginName, name);
                //adment.Ip = null;//先将其Ip给清除 防止错误次数引起Ip限制
                //adment.Save();
                //当前时间减去最近登录时间判断是否超过限制登录时间 若超过限制登录时间则 错误登录次数清零
                //DateTime t1s = DateTime.Now;
                //DateTime t2s = DateTime.Now;
                //if (adment.Intime == null)
                //{
                //    t2s = DateTime.Now;
                //}
                //else
                //{
                //    t2s = DateTime.Parse(adment.Intime.ToString());
                //}
                //TimeSpan tss = t1s.Subtract(t2s);
                //int Limtt = tss.Days;
                //if (Limtt >= SDicEntity.LimitLoginTime)
                //{
                //    adment.ErrorCount = 0;
                //    adment.Save();
                //}
                if (sq.GetRecordCount() > 0)//查到该用户 则进行下一步
                {
                    Sys_Admin sad = sq.ExecuteSingle<Sys_Admin>();
                    //if (sad.ErrorCount >= SDicEntity.LimitLoginCount)//该用户的错误登录次数大于等于限制次数 不让登陆
                    //{
                    //    status = 0;
                    //    msg = "该用户已被限制登陆";
                    //    return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
                    //}
                    //else//小于 则可以登陆
                    //{
                    #region
                    if (sad.IsLogin == 1)
                    {

                        //设置cookie过期时间
                        //LoginInfo.outDays = 10;
                        LoginInfo.AdminID = sad.Id;
                        LoginInfo.AdminName = sad.RealName;
                        LoginInfo.RoleID = sad.RoleId;
                        //LoginInfo.CusID = sad.CustodyId;
                        //LoginInfo.discount = new Sys_Custody(sad.CustodyId).Discount;

                        Sys_Admin SadSucess = new Sys_Admin(sad.Id);

                        //SadSucess.Ip = NowIp;//成功登录 将Ip改为当前登录的Ip
                        SadSucess.Intime = DateTime.Now;//最近登录时间改为当前时间
                        SadSucess.ErrorCount = 0;//错误登录次数清零
                        SadSucess.Save();
                        status = 1;
                        GUI.InsertLog("系统登录", "登录", LoginInfo.AdminName + " 登陆成功！");

                    }
                    else
                    {
                        status = 0;
                        msg = "此账户已经被禁用！";
                    }
                    #endregion
                    //}
                }
                else//如果没查到该用户  则要对其账户进行验证 判断是否是密码错误引起的 还是不存在该用户名
                {
                    Sys_Admin sadentity = new Sys_Admin(Sys_Admin.Columns.LoginName, name);
                    Sys_Dictionaries SDicEntitys = new Sys_Dictionaries(Sys_Dictionaries.Columns.Ident, 1);
                    if (sadentity.Id != "")//查到了  用户名存在
                    {
                        //sadentity.Ip = NowIp;//将该用户的Ip改为当前的Ip
                        //if (sadentity.ErrorCount < SDicEntitys.LimitLoginCount)//错误登录次数与限制登录次数作比较
                        //{
                        //    //sadentity.ErrorCount = sadentity.ErrorCount + 1;//如果错误登录次数小于限制登录次数 则错误登录次数+1 等于或者大于不做任何处理
                        //    //sadentity.Save();//进行保存
                        //    status = 0;
                        //    msg = "登陆失败！您还有" + Convert.ToDecimal(SDicEntitys.LimitLoginCount - sadentity.ErrorCount) + "次登录机会";
                        //}
                        //else
                        //{
                        //    status = 0;
                        //    msg = "该用户已被限制登陆";
                        //}
                        status = 0;
                        msg = "密码错误！！！";
                    }
                    else
                    {
                        status = 0;
                        msg = "不存在该用户！";
                    }
                }
            }
            else //有与当前Ip相同的  则Ip进行限制
            {
                int error = 0;
                Sys_Dictionaries SdEntity = new Sys_Dictionaries(Sys_Dictionaries.Columns.Ident, 0);//查同Ip状况下 限制错误登陆次数                
                //循环相加Ip相同的错误登录次数
                foreach (var item in SqIpList)
                {
                    DateTime t1 = DateTime.Now;
                    DateTime t2 = DateTime.Now;
                    if (item.Intime == null)
                    {
                        t2 = DateTime.Now;
                    }
                    else
                    {
                        t2 = DateTime.Parse(item.Intime.ToString());
                    }
                    TimeSpan ts = t2.Subtract(t1);
                    int Limtt = ts.Days;
                    //当前时间减去最近登录时间是否大于限制时间
                    if (Limtt >= SdEntity.LimitLoginTime) //如果超过限制时间
                    {
                        Sys_Admin SadmEntity = new Sys_Admin(Sys_Admin.Columns.Id, item.Id);
                        SadmEntity.ErrorCount = 0;//那么将错误登录次数清零
                        SadmEntity.Save();
                        item.ErrorCount = 0;
                    }
                    //错误登录次数相加
                    error += item.ErrorCount;
                }
                //判断错误登录次数是否大于或等于限制登录次数（大于的情况是防止人为改动数据库导致）
                //if (error >= SdEntity.LimitLoginCount) //如果在这个Ip下全部的错误次数等于限制登陆的错误次数
                //{
                //    status = 0;
                //    msg = "该Ip已被限制";
                //    return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
                //}
                //else//如果这个Ip下全部的错误次数小于限制登陆的错误次数
                //{
                if (sq.GetRecordCount() > 0)//如果查到了这个用户则正常登录
                {
                    Sys_Admin s = sq.ExecuteSingle<Sys_Admin>();
                    #region
                    if (s.IsLogin == 1)
                    {
                        //设置cookie过期时间
                        //LoginInfo.outDays = 10;
                        LoginInfo.AdminID = s.Id;
                        LoginInfo.AdminName = s.RealName;
                        LoginInfo.RoleID = s.RoleId;
                        //LoginInfo.CusID = s.CustodyId;
                        //LoginInfo.discount = new Sys_Custody(s.CustodyId).Discount;

                        Sys_Admin SadSucess1 = new Sys_Admin(s.Id);
                        SadSucess1.Ip = NowIp;
                        SadSucess1.Intime = DateTime.Now;
                        SadSucess1.ErrorCount = 0;
                        SadSucess1.Save();
                        status = 1;
                        GUI.InsertLog("系统登录", "登录", LoginInfo.AdminName + " 登陆成功！");
                    }
                    else
                    {
                        status = 0;
                        msg = "此账户已经被禁用！";
                    }
                    #endregion
                }
                else//需要验证是账号不存在还是密码错误
                {
                    Sys_Admin sadentity = new Sys_Admin(Sys_Admin.Columns.LoginName, name);
                    Sys_Dictionaries SDicEntitys = new Sys_Dictionaries(Sys_Dictionaries.Columns.Ident, 0);
                    if (sadentity.Id != "") //如果该字段不为空 则说明密码错误 该账户错误登录次数+1
                    {
                        sadentity.Ip = NowIp;//将该用户的Ip改为当前的Ip                                                        
                        status = 0;
                        msg = "登陆失败！";
                    }
                    else //如果为空  则说明不存在用户 不管
                    {
                        status = 0;
                        msg = Tip.LoginError;
                    }
                }
                //}
            }
            return Json("{Status:'" + status + "',Memo:'" + msg + "'}");
        }
    }
}
