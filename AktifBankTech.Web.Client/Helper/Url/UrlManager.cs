using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace AktifBankTech.Web.Client.Helper.Url
{
    public static class UrlManager
    {
        public static RouteCollection MapApplicationRoutes(RouteCollection routes)
        {
            foreach (UrlItem urlItem in CurrentUrlItemList)
            {
                routes.MapRoute(
                    urlItem.Name + urlItem.Culture,
                    urlItem.Pattern,
                    new
                    {
                        controller = urlItem.Controller,
                        action = urlItem.Action,
                        culture = urlItem.Culture,
                        id = UrlParameter.Optional
                    });
            }
            return routes;
        }

        public static List<UrlItem> CurrentUrlItemList
        {
            get
            {
                if (HttpContext.Current.Application["CurrentUrlItemList"] == null)
                {
                    List<UrlItem> urlItemList = new List<UrlItem>();
                    string configFile = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings.Get("UrlRewritingConfigFile"));

                    XmlReader xmlReader = XmlReader.Create(configFile);
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            string name = xmlReader.GetAttribute("name");
                            string pattern = xmlReader.GetAttribute("pattern");
                            string controller = xmlReader.GetAttribute("controller");
                            string action = xmlReader.GetAttribute("action");
                            string culture = xmlReader.GetAttribute("culture");
                            string title = xmlReader.GetAttribute("title");
                            if (name != null)
                            {
                                UrlItem urlItem = new UrlItem();
                                urlItem.Action = action;
                                urlItem.Controller = controller;
                                urlItem.Name = name;
                                urlItem.Pattern = pattern;
                                urlItem.Culture = culture;
                                urlItem.Title = title;
                                urlItemList.Add(urlItem);
                            }
                        }
                    }

                    xmlReader.Close();

                    HttpContext.Current.Application["CurrentUrlItemList"] = urlItemList;
                }

                return (List<UrlItem>)HttpContext.Current.Application["CurrentUrlItemList"];
            }
        }

        public static string GetFriendlyUrl(string title, bool isUrl)
        {
            const string invalidSeoUrlChars = @"®$%#@!*?;:~'`_+=()[]{}|\’<>,/^&"".é";
            char lastAddedChar = 'a';
            StringBuilder buffer = new StringBuilder();
            // Get all lowercase without spaces
            title = title.ToLower().Trim();
            // Now go through each character.
            foreach (char t in title)
            {
                char currentChar = t;
                // Invalid char ? Go to next one.
                if (invalidSeoUrlChars.Contains(currentChar))
                {
                    continue;
                }
                //replace turkish chars with latin-1
                switch (currentChar)
                {
                    case 'ç':
                        currentChar = 'c';
                        break;
                    case 'ş':
                        currentChar = 's';
                        break;
                    case 'ı':
                        currentChar = 'i';
                        break;
                    case 'ğ':
                        currentChar = 'g';
                        break;
                    case 'ö':
                        currentChar = 'o';
                        break;
                    case 'ü':
                        currentChar = 'u';
                        break;
                }
                if (isUrl)
                {
                    // Handle spaces or dashes.
                    if (currentChar == ' ' || currentChar == '-')
                    {
                        // Only add if the previous char was not a space or dash (’ ‘, ‘-’).
                        // This is to avoid having multiple “-" dashes in the url.
                        if (lastAddedChar != ' ' && lastAddedChar != '-')
                        {
                            buffer.Append('-');
                            lastAddedChar = '-';
                        }
                    }
                    else
                    {
                        buffer.Append(currentChar);
                        lastAddedChar = currentChar;
                    }
                }
                else
                {
                    buffer.Append(currentChar);
                }
                if (isUrl && buffer.Length > 50) break;
            }
            return buffer.ToString();
        }

        public static string GetUrl(string key)
        {
            return GetUrl(key, String.Empty);
        }

        public static string GetUrl(string key, string param)
        {
            var urlItem = CurrentUrlItemList.Where(q => q.Name == key).FirstOrDefault();

            if (urlItem != null)
            {
                if (urlItem.Pattern != null)
                {
                    string pattern = urlItem.Pattern;

                    if (!String.IsNullOrEmpty(param) && pattern.Contains("{id}"))
                    {
                        pattern = pattern.Replace("{id}", param);
                    }

                    return UrlHelper.GetBaseUrl() + pattern;
                }
            }

            return String.Empty;
        }

        public static string GetUrl(string key, object values)
        {
            if (values is string)
            {
                return GetUrl(key, (string)values);
            }
            else
            {
                var urlItem = CurrentUrlItemList.Where(q => q.Name == key).FirstOrDefault();

                if (urlItem != null)
                {
                    string pattern = urlItem.Pattern;

                    Type t = values.GetType();

                    PropertyInfo[] properties = t.GetProperties();
                    foreach (var property in properties)
                    {
                        if (urlItem.Pattern.Contains(property.Name) && property.GetValue(values, null) != null)
                        {
                            pattern = pattern.Replace("{" + property.Name + "}", property.GetValue(values, null).ToString());
                        }
                        else
                        {
                            if (pattern.Contains("?"))
                            {
                                pattern = pattern + "&" + property.Name + "=" + property.GetValue(values, null).ToString();
                            }
                            else
                            {
                                var val = property.GetValue(values, null);
                                if (val != null)
                                {
                                    pattern = pattern + "?" + property.Name + "=" + property.GetValue(values, null).ToString();
                                }
                            }
                        }
                    }

                    return UrlHelper.GetBaseUrl() + pattern;
                }

                return String.Empty;
            }
        }
    }
    public class UrlItem
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Culture { get; set; }
        public string Title { get; set; }
    }
}