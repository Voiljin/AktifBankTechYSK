using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Helper.Url
{
    public static class UrlHelper
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;
            if (!appUrl.EndsWith("/"))
                if (!string.IsNullOrWhiteSpace(appUrl)) appUrl += "/";
            
            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}