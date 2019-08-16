using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ZrSoft;

namespace mvcProject.ashx
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string fileId = "";
                context.Response.ContentType = "text/plain";
                // context.Response.Write("Hello World");
                foreach (string f in context.Request.Files.AllKeys)
                {
                    HttpPostedFile pfile = context.Request.Files[f];
                    string photoName = Utils.GenerateCheckCode(6) + pfile.FileName;
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

                    pfile.SaveAs(lujing);
                    ///*保存入数据库*/
                    //Basics_Attachment a = new Basics_Attachment();
                    //a.Id = Utils.GetNewDateID();
                    //a.AdminId = "";
                    //a.PubDate = DateTime.Now;
                    //a.Name = pfile.FileName;
                    //a.Url = "/Content/upload/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.ToString("MM-dd") + "/" + photoName;
                    //a.OutId = context.Request["OutId"];
                    //if (!string.IsNullOrEmpty(context.Request["ProjectId"]))
                    //{
                    //    a.Type = context.Request["ProjectId"];
                    //}
                    //a.Save();
                    //fileId += a.Id + ",";
                }
                context.Response.Write(fileId.Substring(0, fileId.Length - 1));
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