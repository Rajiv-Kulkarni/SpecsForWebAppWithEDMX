namespace CT3Application.Web.Infrastructure
{
    public enum ApplicationRole
    {
        Administrator = 1 //ID starts from 1 in database
    }

    //public class ApplicationRole
    //{
    //    private ApplicationRole(string value)
    //    {
    //        Value = value;
    //    }

    //    public string Value { get; set; }

    //    public static ApplicationRole Administrator => new ApplicationRole("Administrator");
    //    public static ApplicationRole Cam => new ApplicationRole("Cam");
    //    public static ApplicationRole PpAndC => new ApplicationRole("PP&C");
    //    public static ApplicationRole Scheduler => new ApplicationRole("Scheduler");
    //    public static ApplicationRole TpmPm => new ApplicationRole("TPM/PM");
    //}
}