using System;
using System.Web;

namespace CT3Application.Web.App_Start
{
    public static class ApplicationConfig
    {
        public static string ApplicationPath { get; set; }
        public static string ApplicationServer { get; set; }
        public static void Execute()
        {
            ApplicationServer = System.Environment.MachineName.ToLower();
            HttpContext.Current.Application["ApplicationServer"] = ApplicationServer;

            ApplicationPath = HttpContext.Current.Server.MapPath("~").ToLower();//HttpContext.Current.Server.MapPath("~/isat_admin/").ToLower();
            HttpContext.Current.Application["ApplicationPath"] = ApplicationPath;
            HttpContext.Current.Application["ApplicationEnvironment"] = Properties.Settings.Default.DEVApplicationEnvironment;

            //if (ApplicationServer == "specops01" || ApplicationServer == "crntct3sql01")
            //{
            //    if (ApplicationPath.Contains("staffingcenter_qa"))
            //    {
            //        HttpContext.Current.Application["ApplicationEnvironment"] = Properties.Settings.Default.QAApplicationEnvironment;
            //    }
            //    else if (ApplicationPath.Contains("staffingcenter_demo"))
            //    {
            //        HttpContext.Current.Application["ApplicationEnvironment"] = Properties.Settings.Default.DEMOApplicationEnvironment;
            //    }
            //    else
            //    {
            //        HttpContext.Current.Application["ApplicationEnvironment"] = Properties.Settings.Default.DEVApplicationEnvironment;
            //    }
            //}
            //else
            //{
            //    HttpContext.Current.Application["ApplicationEnvironment"] = Properties.Settings.Default.DEVApplicationEnvironment;
            //}
            AppDomain.CurrentDomain.SetData("isUsedForSpecs", false);

        }
    }
}