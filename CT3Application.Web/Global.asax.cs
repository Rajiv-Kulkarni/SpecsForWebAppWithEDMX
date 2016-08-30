using CT3Application.Web.App_Start;
using CT3Application.Web.Infrastructure.Tasks;
using Heroic.Web.IoC;
using StructureMap;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CT3Application.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container => StructureMapContainerPerRequestModule.Container;

        protected void Application_Start()
        {
            StructureMapContainerPerRequestModule.PreDisposeContainer += ExecuteEndTasks;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //EFConfig.Initialize();
            //EFCommonConfig.Initialize();

            ApplicationConfig.Execute();

            using (var container = Container.GetNestedContainer())
            {
                foreach (var task in container.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }

                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
        }

        public void Application_BeginRequest()
        {
            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        private void ExecuteEndTasks(IContainer nestedContainer)
        {
            foreach (var task in nestedContainer.GetAllInstances<IRunAfterEachRequest>())
            {
                task.Execute();
            }
        }

    }
}
