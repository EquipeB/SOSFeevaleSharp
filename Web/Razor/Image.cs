using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Razor
{
    public static class ImageExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                url = "http://www.sindgastrho.com.br/img/noticias/feevale%20(1).jpg";
            }
            return MvcHtmlString.Create(string.Format("<img src=\"{0}\" alt=\"Image\" />", url));
        }
    }
}