using CT3Application.Web.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace CT3Application.Web.Data
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs")));
        }
    }
}