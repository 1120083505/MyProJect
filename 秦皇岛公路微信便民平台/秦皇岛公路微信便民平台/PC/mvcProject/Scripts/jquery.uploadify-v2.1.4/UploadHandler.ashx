<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using System.IO;
using Core;

public class UploadHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8";


        HttpPostedFile file = context.Request.Files["Filedata"];
        string uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]);
        string shortPath = "\\" + DateTime.Now.Year + "\\" + DateTime.Now.ToString("MM-dd") + "\\";
        if (file != null)
        {
           
            if (!Directory.Exists(uploadPath + shortPath))
            {
                Directory.CreateDirectory(uploadPath + shortPath);
            }
            string fn = Utils.GetNewDateID() + file.FileName;
            file.SaveAs(uploadPath + shortPath + fn);
            //上传成功后让上传队列的显示自动消失
            //context.Response.Write((context.Request["folder"] + shortPath + fn).Replace("\\", "/"));
            context.Response.Write("{\"name\":\"" + file.FileName + "\",\"src\":\"" + (context.Request["folder"] + shortPath + fn).Replace("\\", "/") + "\"},");
        }
        else
        {
            context.Response.Write("0");
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