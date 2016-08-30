using CT3Application.Web.Data;
using SpecsFor;

namespace IntegrationSpecs.TestHelpers
{
    public interface INeedDatabase : ISpecs
    {
        ApplicationDbContext Database { get; set; }

    }
}
