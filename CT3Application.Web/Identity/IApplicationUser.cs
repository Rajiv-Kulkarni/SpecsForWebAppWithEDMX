namespace CT3Application.Web.Identity
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        string DisplayName { get; set; }
        string Role { get; set; }
        string UserDomain { get; set; }

        int DummyMethod(string test);

    }

    public abstract class ApplicationUserBase
    {
        public abstract string Id { get; set; }
        public abstract string DisplayName { get; set; }
        public abstract string Role { get; set; }
        public abstract string UserDomain { get; set; }

        public abstract int DummyMethod(string test);

    }

}
