using Microsoft.Web.Mvc;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace CT3Application.Web.Infrastructure
{
    public abstract class CT3ApplicationWebController : Controller
    {
        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}