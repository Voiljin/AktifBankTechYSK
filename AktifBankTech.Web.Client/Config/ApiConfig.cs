using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AktifBankTech.Web.Client.Config
{
    public sealed class ApiConfig
    {
        private static readonly ApiConfig instance = new ApiConfig();

        private ApiConfig() { }

        public static ApiConfig Instance
        {
            get
            {
                return instance;
            }
        }

        public string ApiRoot
        {
            get { return ConfigurationManager.AppSettings["ApiRootUrl"]; }
        }
    }
}