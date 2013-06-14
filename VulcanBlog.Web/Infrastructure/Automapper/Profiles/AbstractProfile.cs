using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace VulcanBlog.Web.Infrastructure.Automapper.Profiles
{
    public abstract class AbstractProfile : Profile
    {
        protected UrlHelper UrlHelper
        {
            get { return new UrlHelper(HttpContext.Current.Request.RequestContext); }
        }
    }
}