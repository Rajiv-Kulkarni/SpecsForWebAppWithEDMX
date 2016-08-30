using CT3Application.Web.Data;
using CT3Application.Web.Infrastructure;
using SpecsFor.Configuration;

namespace IntegrationSpecs.TestHelpers
{
    public class EFContextFactory : Behavior<INeedDatabase>
    {
        public override void SpecInit(INeedDatabase instance)
        {
            instance.Database = new ApplicationDbContext(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs")));

            instance.MockContainer
                .Configure(cfg => cfg.For<ApplicationDbContext>().Use(instance.Database));
        }

        public override void AfterSpec(INeedDatabase instance)
        {
            instance.Database.Dispose();
        }
    }
}
