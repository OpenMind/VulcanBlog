using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VulcanBlog.Web.Helpers.Validation;

namespace VulcanBlog.Web.Models
{
    /*Section can contains:
         * 1. Body = "Any html text"
         * 2. Can point to any internal action.
         */
    public class Section : Model
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Position")]
        public int Position { get; set; }

        [AllowHtml]
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [RequiredIf("Body", "")]
        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [RequiredIf("Body", "")]
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }

        public bool IsNewSection()
        {
            return string.IsNullOrEmpty(Id);
        }
    }
}