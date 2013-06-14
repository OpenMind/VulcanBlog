using System;
using System.Web.Mvc;

namespace VulcanBlog.Web.Controllers
{
    public abstract class AggresivelyCachingVulcanController : VulcanController
    {
        IDisposable aggressivelyCacheFor;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            aggressivelyCacheFor = RavenSession.Advanced.DocumentStore.AggressivelyCacheFor(CacheDuration);
        }

        protected abstract TimeSpan CacheDuration { get; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (aggressivelyCacheFor == null) return;
            aggressivelyCacheFor.Dispose();
            aggressivelyCacheFor = null;
        }
    }
}