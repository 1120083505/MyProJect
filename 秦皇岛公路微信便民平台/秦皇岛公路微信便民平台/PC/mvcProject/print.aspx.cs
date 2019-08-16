using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SubSonic;
using ZrSoft;
namespace mvcProject.Views.Export
{
    public partial class print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlQuery sq = new Select().Top("20").From<Vlog>();
                List<Vlog> list = sq.ExecuteTypedList<Vlog>();
                //LocalReport localReport = new LocalReport();
                //localReport.ReportPath = Server.MapPath("~/Report/Sys_Log.rdlc");
                ReportDataSource reportDataSource = new ReportDataSource("DataSet", list);
                //localReport.DataSources.Add(reportDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Sys_Log.rdlc");
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.DataBind();
              
            }

        }
    }
}