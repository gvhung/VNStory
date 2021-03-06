using System.Diagnostics;
using System.Web;
using System.Web.Optimization;

namespace VNStory.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var productVersion = fvi.ProductVersion;

            string minify = "";

#if DEBUG
            BundleTable.EnableOptimizations = false;
            minify = "";
#else
            BundleTable.EnableOptimizations = true;
            minify = "min.";
#endif

            string[] javascriptItems = {
                "~/Resources/jquery/jquery-3.6.0."+minify+"js",
                "~/Resources/jquery/jquery-migrate-3.4.0."+minify+"js",
                "~/Resources/jquery-ui-1.13.1/jquery-ui."+minify+"js",
                //"~/Resources/popper-1.16.0/popper."+minify+"js",
                "~/Resources/bootstrap-5.1.3/js/bootstrap."+minify+"js",
                "~/Resources/jquery-validation-1.19.1/jquery.validate."+minify+"js",
                "~/Resources/jquery-validation-1.19.1/additional-methods."+minify+"js",
                "~/Resources/tablesorter-2.31.3/js/jquery.tablesorter."+minify+"js",
                "~/Resources/tablesorter-2.31.3/js/jquery.tablesorter.widgets."+minify+"js",
                "~/Resources/jquery-blockUI-2.70/jquery.blockUI."+minify+"js",
                "~/Resources/jquery-dateFormat/jquery-dateFormat."+minify+"js",
                "~/Resources/jbox-1.3.3/jBox.all."+minify+"js",
                "~/Resources/SunEditor-2.43.8/suneditor.min.js",
                "~/Resources/WebApplication."+minify+"js"
            };

            string[] styleSheetItems = {
                "~/Resources/StyleSheet."+minify+"css",
                "~/Resources/jquery-ui-1.13.1/jquery-ui."+minify+"css",
                "~/Resources/bootstrap-5.1.3/css/bootstrap."+minify+"css",
                "~/Resources/bootstrap-icons-1.8.1/bootstrap-icons."+minify+"css",
                "~/Resources/tablesorter-2.31.3/css/theme.blue."+minify+"css",
                "~/Resources/jbox-1.3.3/jBox.all."+minify+"css",
                "~/Resources/SunEditor-2.43.8/css/suneditor.min.css",
            };

            //bundles.Add(new ScriptBundle("~/Resources/script").Include(javascriptItems));
            bundles.Add(new Bundle("~/Resources/script").Include(javascriptItems));
            bundles.Add(new StyleBundle("~/Resources/css").Include(styleSheetItems));

        }
    }
}
