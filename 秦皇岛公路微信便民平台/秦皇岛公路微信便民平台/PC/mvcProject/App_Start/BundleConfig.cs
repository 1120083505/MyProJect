using System.Web;
using System.Web.Optimization;

namespace mvcProject
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/icon.css",
                   "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                        "~/Scripts/jquery-1.7.1.js",
                        "~/Scripts/jquery.easyui.js",
                        "~/Scripts/easyui-lang-zh_CN.js",
                        "~/Scripts/jquery.easyui.plus.js",
                        "~/Scripts/Common.js"
                        ));

            bundles.Add(new ScriptBundle("~/ueditor").Include(
                        "~/Scripts/ueditor1_4_3-utf8-net/ueditor.config.js",
                        "~/Scripts/ueditor1_4_3-utf8-net/ueditor.all.js",
                        "~/Scripts/ueditor1_4_3-utf8-net/lang/zh-cn/zh-cn.js"
                        ));

        }
    }
}