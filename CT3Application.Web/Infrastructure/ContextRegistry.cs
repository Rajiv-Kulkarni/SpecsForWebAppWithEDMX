using CT3Application.Web.Data;
//using CT3Application.Web.Data.Common;
using StructureMap;
using System.DirectoryServices.AccountManagement;


namespace CT3Application.Web.Infrastructure
{
    public class ContextRegistry : Registry
    {
        public ContextRegistry()
        {
            For<ApplicationDbContext>().Use(() => new ApplicationDbContext(CommonHelper.GetConnectionString(System.AppDomain.CurrentDomain.GetData("isUsedForSpecs") != null && (bool)System.AppDomain.CurrentDomain.GetData("isUsedForSpecs"))));
            //For<CommonDbContext>().Use(() => new CommonDbContext(CommonHelper.GetCommonDbConnectionString(false)));
            For<PrincipalContext>().Use(() => new PrincipalContext(ContextType.Domain));
        }
    }
}