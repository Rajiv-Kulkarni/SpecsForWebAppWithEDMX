using CT3Application.Web.Infrastructure;
using System.Data.Entity;

namespace CT3Application.Web.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class ApplicationDbContext
    {
        public ApplicationDbContext(string connString)
            : base(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs")))
        {
        }

        static ApplicationDbContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
    }
}