using Heroic.Web.IoC;
using StructureMap;
using StructureMap.TypeRules;
using System.Web.Mvc;

namespace CT3Application.Web.Infrastructure
{
    public class AuthorizeAccessFilterRegistry : Registry
    {
        public AuthorizeAccessFilterRegistry()
        {
            For<IFilterProvider>().Use(new StructureMapFilterProvider());

            //Policies.FillAllPropertiesOfType<ApplicationDbContext>()
            //    .Use(() => new ApplicationDbContext(ApplicationDbContext.conStr));
            Policies.SetAllProperties(x =>
                x.Matching(p =>
                (p.DeclaringType.CanBeCastTo(typeof(AuthorizeAttribute))) &&
                p.DeclaringType.Namespace.StartsWith("CT3Application.Web") &&
                !p.PropertyType.IsPrimitive &&
                p.PropertyType != typeof(string)));
        }
    }
}