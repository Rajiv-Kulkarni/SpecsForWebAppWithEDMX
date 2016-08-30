using Heroic.AutoMapper;
using System.Reflection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CT3Application.Web.AutoMapperConfig), "Configure")]
namespace CT3Application.Web
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            HeroicAutoMapperConfigurator.LoadMapsFromAssemblies(Assembly.GetExecutingAssembly());
        }
    }
}