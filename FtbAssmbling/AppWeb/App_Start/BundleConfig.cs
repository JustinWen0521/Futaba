using System.Web;
using System.Web.Optimization;

namespace ftd.mvc.Configs
{
    public class BundleConfig
    {
        // 如需 Bundling 的詳細資訊，請造訪 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js",
                        //"~/Scripts/jquery-migrate-{version}.js"
                        "~/Scripts/jquery-1.11.1.min.js", 
                        "~/Scripts/jquery-migrate-1.2.1.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"
                        ));

            //bundles.Add(new ScriptBundle("~/bundles/jquerylayout").Include(
            //            "~/Scripts/jquery-latest.js",
            //            "~/Scripts/jquery-ui-latest.js",
            //            "~/Scripts/jquery.layout-latest.js"
            //            ));

            bundles.Add(new ScriptBundle("~/bundles/kfcp").Include(
                        //"~/Scripts/accordionmenu.js",
                        "~/Scripts/debug.js",
                        "~/Scripts/jquery-latest.js",
                        "~/Scripts/jquery-ui-latest.js",
                        "~/Scripts/jquery.layout-latest.js"
                        //alertfyjs
                        //,"~/Scripts/alertfy/alertfy.min.js"
                        //"~/Scripts/marquee"
                        ));

            // Scripts for jTable
            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                        "~/Scripts/jtable/jquery.jtable.js",
                        "~/Scripts/jtable/localization/jquery.jtable.zh-TW.js",
                        "~/Scripts/validationEngine/jquery.validationEngine.js",
                        //"~/Scripts/validationEngine/jquery.validationEngine-en.js"
                         "~/Scripts/validationEngine/jquery.validationEngine-tw.js", //August Lee 2014/10/20 中文化
                        "~/Scripts/jtable/extensions/jquery.jtable.buttonleft.js",
                        "~/Scripts/date.format.js"  //DateTime formate
                        ));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/csspub").Include("~/Content/site.css"));

            string style = "green";
            string mainStyle = "main_" + style;
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        //"~/Content/site.css",
                        "~/Content/" + mainStyle + "/layout-default-latest.css",
                        "~/Content/" + mainStyle + "/layout-gray.css",
                        "~/Content/" + mainStyle + "/style.css",
                        //"~/Content/" + mainStyle + "/accordionmenu.css",
                        "~/Scripts/validationEngine/validationEngine.jquery.css"
                        //"~/Content/marquee.css",
                        //alertfyjs
                        //,"~/Scripts/alertfy/alertfy.core.css",
                        //"~/Scripts/alertfy/alertfy.default.css"
                        ));

            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                        "~/Content/" + mainStyle + "/login.css"
                        ));

            //string jqUIStyle = "base";
            //string jqUIStyle = "cupertino";
            //string jqUIStyle = "excite-bike";
            //string jqUIStyle = "start";
            //string jqUIStyle = "sunny";
            //string jqUIStyle = "ui-darkness";
            //string jqUIStyle = "smoothness";
            //string jqUIStyle = "kfcp_" + style;
            //string jqUIStyle = "kfcp_" + style;
            //string jqUIStyle = "kfcp_" + style;
            //string gridStyle = "ui.jqgrid.blue.css";

            string jqUIStyle = "redmond"; 
            //string jqUIStyle = "ui-lightness";
            //string jqUIStyle = "south-street";

            bundles.Add(new StyleBundle("~/Content/themes/kfcp/css").Include(
                        "~/Content/treeview.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery-ui.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.core.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.resizable.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.selectable.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.accordion.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.autocomplete.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.button.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.dialog.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.slider.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.tabs.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.datepicker.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.progressbar.css",
                        "~/Content/themes/" + jqUIStyle + "/jquery.ui.theme.css",
                        //"~/Scripts/jtable/themes/metro/blue/jtable.css"
                        //"~/Scripts/jtable/themes/lightcolor/blue/jtable.css"
                        //"~/Scripts/jtable/themes/lightcolor/green/jtable.css"
                        //"~/Scripts/jtable/themes/lightcolor/orange/jtable.css"
                        //"~/Content/themes/jquery.jqGrid/" + gridStyle
                         "~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css"
                        ));
        }
    }
}