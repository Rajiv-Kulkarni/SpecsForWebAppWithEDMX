using System.Data.Entity;

namespace CT3Application.Web.App_Start
{
    public class EFCommonConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CommonDbContext, Configuration>());
        }

    }
}