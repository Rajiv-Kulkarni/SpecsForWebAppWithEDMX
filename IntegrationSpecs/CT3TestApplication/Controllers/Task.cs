using CT3Application.Web.Data;

namespace IntegrationSpecs.CT3TestApplication.Controllers
{
    public class Task : task
    {
        public string Description { get; set; }
        public object Id { get; set; }
        public string Title { get; set; }
    }
}