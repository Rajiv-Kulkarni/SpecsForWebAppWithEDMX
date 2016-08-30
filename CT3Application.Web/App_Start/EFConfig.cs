using CT3Application.Web._Migrations;
using CT3Application.Web.Data;
using System.Data.Entity;

namespace CT3Application.Web.App_Start
{
    public class EFConfig
    {
        public static void Initialize()
        {

            Database.SetInitializer<ApplicationDbContext>(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            //Database.SetInitializer(
            //      new CreateDatabaseIfNotExists<ApplicationDbContext>());


        }

    }
}