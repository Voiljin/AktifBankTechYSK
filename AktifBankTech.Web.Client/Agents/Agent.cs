using AktifBankTech.Business.Commons.Models.CommonModels;
using AktifBankTech.Business.Commons.Models.UserModels;
using AktifBankTech.Web.Client.Config;
using AktifBankTech.Web.Client.Helper.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace AktifBankTech.Web.Client.Agents
{
    public sealed class Agent<T, R> where T : new()
    {
        private static readonly Agent<T, R> instance = new Agent<T, R>();

        private Agent() { }

        public static Agent<T, R> Instance
        {
            get
            {
                return instance;
            }
        }

        public Token<T> CallApi(RequestToken<R> requestModel, string method, string apiPath, bool islogin = false)
        {
            string strParameter = JsonConvert.SerializeObject(requestModel);
            string uri = ApiConfig.Instance.ApiRoot + apiPath;
            var result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            if (islogin)
            {
                var tokenStr = HttpContext.Current.Session["authenticationToken"].ToString();
                httpWebRequest.Headers.Add("Authorization", "Bearer " + tokenStr);
            }

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(strParameter);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    WebException wex = (WebException)e;
                    var errorType = ((System.Net.HttpWebResponse)wex.Response).StatusCode;
                    if (errorType == HttpStatusCode.Unauthorized)
                    {
                        AuthSessionManager authSession = new AuthSessionManager();
                        authSession.DeleteAuthenticatUserModel();
                        //return login page
                        HttpContext.Current.Response.Redirect("~/login");
                        return null;
                    }
                }
                return null;
            }

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            Token<T> responseResult = JsonConvert.DeserializeObject<Token<T>>(result);
            
            return responseResult;
        }
    }
}