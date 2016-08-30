using CT3Application.Web.Data;
using CT3Application.Web.Infrastructure;
using CT3Application.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace CT3Application.Web.Controllers
{
    public class HomeController : CT3ApplicationWebController
    {
        private readonly ApplicationDbContext _context;
        //private readonly CommonDbContext _commonContext;
        private readonly ICurrentUser _currentUser;

        public HomeController(ICurrentUser currentUser, ApplicationDbContext context)
        {
            //_commonContext = commonContext;
            _context = context;
            _currentUser = currentUser;
            ViewBag.Title = "Home";
        }

        public ActionResult Index()
        {
            var models = _context.tasks.Select(x => new TaskSummaryViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToArray();

            return View(models);

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}