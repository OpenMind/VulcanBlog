using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VulcanBlog.Web.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (!request.IsAjaxRequest())
                filterContext.Result = new HttpNotFoundResult("Only Ajax calls are permitted.");
        }
    }
}