using CT3Application.Web.Identity;

namespace CT3Application.Web.Infrastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
        void AnotherDummyMethod();
    }
}
