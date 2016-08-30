namespace CT3Application.Web.Infrastructure.Alerts
{
    public class Alert
    {
        public string AlertClass { get; set; }
        public string Message { get; set; }
        public string Duration { get; set; }

        public Alert(string alertClass, string message, string duration = "3000")
        {
            AlertClass = alertClass;
            Message = message;
            Duration = duration;
        }
    }
}