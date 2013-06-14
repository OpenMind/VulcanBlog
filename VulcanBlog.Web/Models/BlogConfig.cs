﻿using System.ComponentModel.DataAnnotations;

namespace VulcanBlog.Web.Models
{
    public class BlogConfig : Model
    {
        [Required]
        [Display(Name = "Blog title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Owner Email")]
        public string OwnerEmail { get; set; }

        [Display(Name = "Slogan")]
        public string Subtitle { get; set; }

        [Required]
        [Display(Name = "Custom CSS")]
        public string CustomCss { get; set; }

        [Display(Name = "Copyright string")]
        public string Copyright { get; set; }

        [Display(Name = "Akismet Key")]
        public string AkismetKey { get; set; }

        [Display(Name = "Google-Analytics Key")]
        public string GoogleAnalyticsKey { get; set; }

        [Display(Name = "FuturePostsEncryptionIV")]
        public string FuturePostsEncryptionIV { get; set; }

        [Display(Name = "FuturePostsEncryptionKey")]
        public string FuturePostsEncryptionKey { get; set; }

        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }

        [Display(Name = "MinNumberOfPostForSignificantTag")]
        public int MinNumberOfPostForSignificantTag { get; set; }

        [Display(Name = "NumberOfDayToCloseComments")]
        public int NumberOfDayToCloseComments { get; set; }

        public static BlogConfig New()
        {
            return new BlogConfig
                {
                    Id = "Blog/Config",
                    CustomCss = "hibernatingrhinos"
                };
        }

        public static BlogConfig NewDummy()
        {
            return new BlogConfig
                {
                    Id = "Blog/Config/Dummy",
                };
        }
    }
}