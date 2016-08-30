using CT3Application.Web._Migrations;
using CT3Application.Web.Data;
using CT3Application.Web.Infrastructure;
using SpecsFor.Configuration;
using System.Data.Entity;

namespace IntegrationSpecs.TestHelpers
{
    public class EFDatabaseCreator : Behavior<INeedDatabase>
    {
        private static bool _isInitialized;

        public override void SpecInit(INeedDatabase instance)
        {
            if (_isInitialized) return;

            var strategy = new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>();
            Database.SetInitializer(strategy);

            using (var context = new ApplicationDbContext(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs"))))
            {
                context.Database.Initialize(force: true);
            }

            _isInitialized = true;
        }
    }
}
