#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Web;
using System.Web.Optimization;

namespace OneTETH
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
           

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.2.1.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.easing-1.3.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jsrendrer").Include(
                       "~/Scripts/jsrender.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ejweball").Include(
                       "~/Scripts/ej/ej.web.all.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/ejunobstrusive").Include(
                        "~/Scripts/ej/ej.unobtrusive.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/adminlitejs").Include(
                "~/Content/adminlte/bower/bootstrap/dist/js/bootstrap.min.js",
                       "~/Content/adminlte/bower/jquery-sparkline/dist/jquery.sparkline.min.js",
                       "~/Content/adminlte/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                       "~/Content/adminlte/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                       "~/Content/adminlte/bower/jquery-knob/dist/jquery.knob.min.js",
                       "~/Content/adminlte/bower/moment/min/moment.min.js",
                       "~/Content/adminlte/bower/bootstrap-daterangepicker/daterangepicker.js",
                       "~/Content/adminlte/bower/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                       "~/Content/adminlte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                       "~/Content/adminlte/bower/jquery-slimscroll/jquery.slimscroll.min.js",
                       "~/Content/adminlte/bower/fastclick/lib/fastclick.js",
                       "~/Content/adminlte/js/adminlte.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/AdminLiteCss").Include(
                   //"~/Content/bootstrap.css",
                   "~/Content/adminlte/bower/bootstrap/dist/css/bootstrap.min.css",
                   "~/Content/adminlte/bower/Ionicons/css/ionicons.min.css",
                   "~/Content/adminlte/css/AdminLTE.css",
                   "~/Content/adminlte/css/skins/_all-skins.min.css",
                   "~/Content/adminlte/bower/morris.js/morris.css",
                   "~/Content/adminlte/bower/jvectormap/jquery-jvectormap.css",
                   "~/Content/adminlte/bower/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                   "~/Content/adminlte/bower/bootstrap-daterangepicker/daterangepicker.css",
                   "~/Content/adminlte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                   ));


            bundles.Add(new StyleBundle("~/Content/fonts").Include(
                 //"~/Content/bootstrap.css",
                 "~/Content/font-awesome/css/font-awesome.min.css"
                 ));


            bundles.Add(new StyleBundle("~/Content/itecss").Include(
                 "~/Content/1TE.css"
                 ));


            bundles.Add(new StyleBundle("~/Content/ejwebcss").Include(
              "~/Content/ej/web/default-theme/ej.web.all.min.css"
              ));







            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    "~/Content/adminlte/bower/bootstrap/dist/js/bootstrap.min.js",
            //    "~/Content/adminlte/bower/jquery-sparkline/dist/jquery.sparkline.min.js",
            //    "~/Content/adminlte/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
            //    "~/Content/adminlte/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
            //    "~/Content/adminlte/bower/jquery-knob/dist/jquery.knob.min.js",
            //    "~/Content/adminlte/bower/moment/min/moment.min.js",
            //    "~/Content/adminlte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
            //    "~/Content/adminlte/bower/jquery-slimscroll/jquery.slimscroll.min.js",
            //    "~/Content/adminlte/bower/fastclick/lib/fastclick.js",
            //    "~/Content/adminlte/js/adminlte.min.js"                
            //          ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //        //"~/Content/bootstrap.css",
            //        "~/Content/adminlte/bower/bootstrap/dist/css/bootstrap.min.css",
            //        "~/Content/font-awesome/css/font-awesome.css",
            //        "~/Content/adminlte/bower/Ionicons/css/ionicons.min.css",
            //        "~/Content/adminlte/css/AdminLTE.css",
            //        "~/Content/adminlte/css/skins/_all-skins.min.css",
            //        "~/Content/adminlte/bower/morris.js/morris.css",
            //        "~/Content/adminlte/bower/jvectormap/jquery-jvectormap.css",
            //        "~/Content/adminlte/bower/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
            //        "~/Content/adminlte/bower/bootstrap-daterangepicker/daterangepicker.css",
            //        "~/Content/adminlte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
            //        "~/Content/ej/web/default-theme/ej.web.all.min.css",
            //        "~/Content/1TE.css"
            //        //"~/Content/Site.css"
            //        ));

            //bundles.Add(new ScriptBundle("~/bundles/ejscripts").Include(
            //               "~/Scripts/jsrender.min.js",
            //               "~/Scripts/jquery.easing-1.3.min.js",
            //                "~/Scripts/ej/ej.web.all.min.js",
            //                "~/Scripts/ej/ej.unobtrusive.min.js"));
            //bundles.Add(new StyleBundle("~/bundles/ejstyles").Include(
            //          "~/ejThemes/flat-saffron/ej.web.all.min.css"));
        }
    }
}
