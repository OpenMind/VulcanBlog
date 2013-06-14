using System.Web.Mvc;

namespace VulcanBlog.Web.ViewModels
{
    public class SectionDetails
    {
        public string Title { get; set; }

        public MvcHtmlString Body { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public bool IsActionSection()
        {
            return MvcHtmlString.IsNullOrEmpty(Body);
        }
    }
}