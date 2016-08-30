using System.Web.Mvc;

namespace CT3Application.Web.Infrastructure.Alerts
{
    public class AlertDecoratorResult : ActionResult
    {
        public ActionResult InnerResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }
        public string Duration { get; set; }

        public AlertDecoratorResult(ActionResult innerResult, string alertClass, string message, string duration = "3000")
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
            Duration = duration;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass, Message, Duration));
            InnerResult.ExecuteResult(context);
        }
    }
}