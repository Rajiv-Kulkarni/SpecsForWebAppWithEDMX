using System.Collections.Generic;
using System.Web.Mvc;

namespace CT3Application.Web.Infrastructure.Alerts
{
    public static class AlertExtensions
    {
        const string Alerts = "_Alerts";

        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<Alert>();
            }

            return (List<Alert>)tempData[Alerts];
        }

        public static ActionResult WithSuccess(this ActionResult result, string message, string duration = "3000")
        {
            return new AlertDecoratorResult(result, "alert-success", message, duration);
        }

        public static ActionResult WithInfo(this ActionResult result, string message, string duration = "3000")
        {
            return new AlertDecoratorResult(result, "alert-info", message, duration);
        }

        public static ActionResult WithWarning(this ActionResult result, string message, string duration = "3000")
        {
            return new AlertDecoratorResult(result, "alert-warning", message, duration);
        }

        public static ActionResult WithError(this ActionResult result, string message, string duration = "3000")
        {
            return new AlertDecoratorResult(result, "alert-danger", message, duration);
        }
    }
}