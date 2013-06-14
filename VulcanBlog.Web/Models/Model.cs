using System.Web.Mvc;

namespace VulcanBlog.Web.Models
{
    public class Model
    {
        [HiddenInput]
        public string Id { get; set; }
    }
}