using Core;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace mvcProject.App_Code
{
    public class NodeHelper
    {
        static DataTable dt = new DataTable();
        public static DataTable GetTreeList(string id)
        {

            //过滤权限
            if (string.IsNullOrEmpty(id))
            {
                id = "0";
            }
            string sql = "SELECT *,dbo.f_GetPowerCount('" + LoginInfo.RoleID + "',ID) as Count FROM dbo.Sys_Module ";
            DataTable dtB = DataService.GetDataSet(new QueryCommand(sql + " WHERE IsLast=1  order by sort asc")).Tables[0];
            DataTable dtA = DataService.GetDataSet(new QueryCommand(sql + " WHERE IsShow=1 order by sort asc")).Tables[0];
            dt = dtA.Clone();
            for (int i = 0; i < dtB.Rows.Count; i++)
            {
                if (dtB.Rows[i]["count"].ToString() != "0")
                {
                    GetMenu(dtA, id, dtB.Rows[i]["parentid"].ToString(), dtB.Rows[i]["islast"].ToString());
                }
            }
            return dt;
        }
        public static string GetMenuHtml()
        {
            string html = "";
            DataTable dt = NodeHelper.GetTreeList("0");
            foreach (DataRow dr in dt.Select("", "Sort asc"))
            {
                html += " <li class=\"\">"
                     + "<a href=\"#\" class=\"dropdown-toggle\">"
                     + "    <i class=\"menu-icon fa "+dr["icon"]+"\"></i>"
                       + "  <span class=\"menu-text\">" + dr["Name"] + " </span>"
                     + "<b class=\"arrow fa icon-arrowdown\" style='font-size:8px'></b></a>";

                html += "<b class=\"arrow\"></b><ul class=\"submenu\">";
                html += GetSonMenu(dr["Id"].ToString());
                html += "</ul></li>";
            }
            return html;
        }
        public static string GetSonMenu(string id)
        {
            string html = "";
            DataTable dt = NodeHelper.GetTreeList(id);
            foreach (DataRow dr in dt.Select("", "Sort asc"))
            {
                html += "  <li class=\"" + (dr["islast"].ToString() =="1"?"islast ":"")+ "\">";
                if (dr["islast"].ToString() == "1")
                {
                    html += "<a href=\"" + dr["Url"] + "\" target=\"main\">";
                }
                else
                {
                    html += "<a href=\"#\" class=\"dropdown-toggle\">";
                }
                html += "   <i class=\"menu-icon fa " + dr["icon"] + "\" ></i>"
                     + dr["Name"];
                if (dr["islast"].ToString() == "0")
                {
                    html += "<b class=\"arrow fa icon-arrowdown\" style='font-size:8px'></b></a>";
                    html += "<ul class=\"submenu\">";
                    html += GetSonMenu(dr["id"].ToString());
                    html += "</ul>";

                }
                else
                {

                   // html += "<b class=\"\"></b></a>";
                    html += "</a>";
                }
                html += "<b class=\"arrow\"></b></li>"
             + "";
            }

//<ul class="submenu">
//                   <li class="">
//                       <a href="#">
//                           <i class="menu-icon fa fa-leaf green"></i>
//                           Item #1
//                       </a>

//                       <b class="arrow"></b>
//                   </li>

//                   <li class="">
//                       <a href="#" class="dropdown-toggle">
//                           <i class="menu-icon fa fa-pencil orange"></i>

//                           4th level
//                               <b class="arrow fa fa-angle-down"></b>
//                       </a>

//                       <b class="arrow"></b>

//                       <ul class="submenu">
//                           <li class="">
//                               <a href="#">
//                                   <i class="menu-icon fa fa-plus purple"></i>
//                                   Add Product
//                               </a>

//                               <b class="arrow"></b>
//                           </li>

//                           <li class="">
//                               <a href="#">
//                                   <i class="menu-icon fa fa-eye pink"></i>
//                                   View Products
//                               </a>

//                               <b class="arrow"></b>
//                           </li>
//                       </ul>
//                   </li>
//               </ul>
            return html;
        }
        public static DataRow GetMenu(DataTable dtA, string id, string pid, string islast)
        {
            string filter = "[id]='" + pid + "'";
            if (islast == "0")
            {
                filter = "[parentid]='" + id + "'";
            }

            DataRow[] drs = dtA.Select(filter);
            foreach (DataRow dr in drs)
            {
                string parentid = dr["parentid"].ToString();
                if (parentid == id)
                {
                    DataRow[] tempr = dt.Select("[id]='" + dr["id"] + "'");

                    if (tempr.Length == 0)
                    {
                        if (dr["isLast"].ToString() != "1")
                        {
                            dt.Rows.Add(dr.ItemArray);

                        }
                        else if (int.Parse(dr["count"].ToString()) > 0)
                        {
                            dt.Rows.Add(dr.ItemArray);
                        }
                    }

                }
                else
                {
                    if (dr["isLast"].ToString() != "1")
                    {
                        GetMenu(dtA, id, dr["parentid"].ToString(), "0");
                    }
                }
            }

            return null;
        }
    }
}