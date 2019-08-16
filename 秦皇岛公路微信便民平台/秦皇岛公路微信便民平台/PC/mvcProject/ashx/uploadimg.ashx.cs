using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ZrSoft;
using Core;
using SubSonic;

namespace mvcProject.ashx
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                // context.Response.Write("Hello World");
                foreach (string f in context.Request.Files.AllKeys)
                {
                    string adminId = context.Request["adminId"];
                    HttpPostedFile pfile = context.Request.Files[f];
                    string photoName = pfile.FileName;
                    //若文件夹不存在则新建文件夹
                    if (!Directory.Exists(context.Server.MapPath("~/Content/upload/" + DateTime.Now.Year.ToString())))
                    {
                        Directory.CreateDirectory(context.Server.MapPath("~/Content/upload/" + DateTime.Now.Year.ToString())); //新建文件夹  
                    }
                    //若文件夹不存在则新建文件夹
                    if (!Directory.Exists(context.Server.MapPath("~/Content/upload/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MM-dd"))))
                    {
                        Directory.CreateDirectory(context.Server.MapPath("~/Content/upload/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MM-dd"))); //新建文件夹  
                    }

                    string lujing = context.Server.MapPath("~/Content/upload/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MM-dd")) + "/" + photoName;
                    string imgUrl = "/Content/upload/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MM-dd") + "/" + photoName;
                    string s = string.Format("{0}{1}\\{2}", context.Server.MapPath("~/"), "LadlxtUploadFile", photoName);
                    pfile.SaveAs(lujing);
                                       
                    string FromId = context.Request["Id"];
                    string type = context.Request["type"];
                    string name = context.Request["name"];
                    string Type2 = context.Request["Type2"];
                    //if (Type2 == "1")
                    //{
                    //    Electric_ImgCun list = new Electric_ImgCun(FromId);
                    //    list.imgUrl = imgUrl;
                    //    list.Save();
                           
                    //}
                    //else
                    //{

                        SqlQuery sq = new Select().From<Assist_Resources>()
                         .Where(Assist_Resources.Columns.FromId).IsEqualTo(FromId)
                         .And(Assist_Resources.Columns.FileType).IsEqualTo(type);
                        if (sq.GetRecordCount() > 0)
                        {
                            Assist_Resources model = new Assist_Resources(sq.ExecuteSingle<Assist_Resources>().Id);
                            model.Url = model.Url + imgUrl + ";";
                            model.Name = model.Name + name + ";";
                            model.FileType = type;
                            model.Save();
                        }
                        else
                        {
                            Assist_Resources model = new Assist_Resources();
                            model.Id = Utils.GetNewDateID();
                            model.FromId = FromId;
                            model.Url = imgUrl + ";";
                            model.Name = name + ";";
                            model.FileType = type;
                            model.FromType = 1;
                            model.AdminId = adminId;
                            model.PubDate = DateTime.Now;
                            model.EditAdminId = adminId;
                            model.EditPubDate = DateTime.Now;
                            model.Save();
                        }
                   // }
                 
                    /*巡查记录添加  
                     */
                    /*交通事故添加*/



                }
                context.Response.Write("success");
            }
            catch (Exception e)
            {
                context.Response.Write("false");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}