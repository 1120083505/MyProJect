using Core;
using Microsoft.Reporting.WebForms;
using Models;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using ZrSoft;

namespace mvcProject.Areas.SalesStatistics.Controllers
{
    public class YearStatisticsController : Controller
    {
        //
        // GET: /SalesStatistics/YearStatistics/
        ControllerHelper c = new ControllerHelper();
        QueryPaged query = new QueryPaged();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<QueryModel> qList = c.getQList(queryStr);
            var Year = DateTime.Now.Year.ToString();
            if (!string.IsNullOrEmpty(qList[0].text))
            {
                var Date = qList[0].text;
                Year = DateTime.Parse(Date).Year.ToString();
            }
          
            SqlQuery sq = new Select().From<SP_SaleMain>().Where(SP_SaleMain.Columns.Year).IsEqualTo(Year);
            List<SP_SaleMain> list = sq.ExecuteTypedList<SP_SaleMain>();
            List<YearCount> MonthList = new List<YearCount>();
            if (list.Count>0)
            {
                int max = list.Max(x => int.Parse(x.Month));                
                for (int i = 1; i <= max; i++)
                {
                    YearCount YC = new YearCount();
                    YC.Month = i.ToString();
                    YC.AllSaleSum = 
                        (
                         from x in list
                         where x.Month == i.ToString() && x.Ext1 == "1"
                         select x.TotalPrice
                         ).Sum().ToString();
                    YC.AllReceiptSum = 
                        (
                        from x in list
                        where x.Month == i.ToString() && x.Ext1 == "0"
                        select x.TotalPrice
                        ).Sum().ToString();
                    YC.NetProfit = (decimal.Parse(YC.AllSaleSum) - decimal.Parse(YC.AllReceiptSum)).ToString();
                    MonthList.Add(YC);
                }
                MonthList.OrderBy(x => x.Month);
            }
            var json = new
            {
                total = MonthList.Count,
                rows = (from r in MonthList
                        select new
                        {
                            r.Month,
                            r.AllSaleSum,
                            r.AllReceiptSum,
                            r.NetProfit
                        }
              ).ToArray()
            };
            return Json(json);
        }

        public class YearCount
        {
            /// <summary>
            /// 月份
            /// </summary>
            public string Month { get; set; }
            /// <summary>
            /// 销售金额
            /// </summary>
            public string AllSaleSum { get; set; }
            /// <summary>
            /// 进货金额
            /// </summary>
            public string AllReceiptSum { get; set; }
            /// <summary>
            /// 净利润
            /// </summary>
            public string NetProfit { get; set; }
        }
    }
}
