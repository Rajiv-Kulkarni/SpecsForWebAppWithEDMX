using Heroic.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CT3Application.Web.StructureMapConfig), "Configure")]
namespace CT3Application.Web
{
    public static class StructureMapConfig
    {
        public static void Configure()
        {
            IoC.Container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                });

                cfg.AddRegistry(new ControllerRegistry());
                cfg.AddRegistry(new MvcRegistry());
                cfg.AddRegistry(new ActionFilterRegistry(namespacePrefix: "CT3Application.Web"));
            });

            var resolver = new StructureMapDependencyResolver();
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}