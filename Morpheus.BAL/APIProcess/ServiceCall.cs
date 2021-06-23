using Morpheus.Common.Constant;
using MorpheusCommon.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Morpheus.BAL.APIProcess
{
    /// <summary>
    /// Class for rest API call
    /// </summary>
    public class ServiceCall
    {
        #region Zoho API Calls

        /// <summary>
        /// Method to invoke zoho invoice get calls
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="methodType">methodType</param>
        /// <param name="content">content</param>
        /// <returns>HttpWebResponse</returns>
        public static HttpWebResponse Rest_InvokeZohoInvoiceService(string url, string methodType, string content = "")
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebResponse getResponse = null;
            string aouthToken = string.Empty;
            try
            {
                #region  Code to generate the auth tocken by refresh token                
                AouthToken aouthObj = Rest_InvokeZohoInvoiceAuthToken();
                if (aouthObj != null)
                    aouthToken = aouthObj.access_token;
                #endregion
                if (!string.IsNullOrEmpty(aouthToken))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Headers.Add(HeaderConstant.Zoho_OrganizationId, ConfigurationManager.AppSettings["orgId"].ToString());
                    request.Headers.Add(HeaderConstant.Zoho_Authorization, "Zoho-oauthtoken " + aouthToken);
                    request.Method = methodType;
                    //request.UseDefaultCredentials = true;
                    //request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ZohoEmail"].ToString(), ConfigurationManager.AppSettings["ZohoPassword"].ToString());
                    //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                    if ((methodType.Equals(MethodTypeConstant.POST) || methodType.Equals(MethodTypeConstant.PATCH)) && !string.IsNullOrEmpty(content))
                    {
                        request.ContentType = ContentType.json;
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(content);
                        }
                    }
                    getResponse = (HttpWebResponse)request.GetResponse();
                }
            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall URL: " + url, "Rest_InvokeGetService Type:" + methodType + "Content: " + content, ex);
            }
            return getResponse;
        }

        public static async Task<string> Rest_InvokeZohoInvoiceServiceForFormDataGet(string url)
        {
            string strResponse = string.Empty;
            string aouthToken = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol =
           SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                #region  Code to generate the auth tocken by refresh token                
                AouthToken aouthObj = Rest_InvokeZohoInvoiceAuthToken();
                if (aouthObj != null)
                    aouthToken = aouthObj.access_token;
                #endregion
                if (!string.IsNullOrEmpty(aouthToken))
                {
                    HttpClient httpClient = new HttpClient();

                    httpClient.DefaultRequestHeaders.Add(HeaderConstant.Zoho_OrganizationId, ConfigurationManager.AppSettings["orgId"].ToString());
                    httpClient.DefaultRequestHeaders.Add(HeaderConstant.Zoho_Authorization, "Zoho-oauthtoken " + aouthToken);




                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    response.EnsureSuccessStatusCode();
                    httpClient.Dispose();
                    strResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall", "Rest_InvokeZohoInvoiceServiceForFormDataGet", ex);
            }
            return strResponse;
        }

        /// <summary>
        /// Method to post zoho invoice using form data post call
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">content</param>
        /// <returns>Task<string> </returns>
        public static async Task<string> Rest_InvokeZohoInvoiceServiceForFormData(string url, string content = "")
        {
            string strResponse = string.Empty;
            string aouthToken = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol =
           SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                #region  Code to generate the auth tocken by refresh token                
                AouthToken aouthObj = Rest_InvokeZohoInvoiceAuthToken();
                if (aouthObj != null)
                    aouthToken = aouthObj.access_token;
                #endregion
                if (!string.IsNullOrEmpty(aouthToken))
                {
                    HttpClient httpClient = new HttpClient();

                    httpClient.DefaultRequestHeaders.Add(HeaderConstant.Zoho_OrganizationId, ConfigurationManager.AppSettings["orgId"].ToString());
                    httpClient.DefaultRequestHeaders.Add(HeaderConstant.Zoho_Authorization, "Zoho-oauthtoken " + aouthToken);


                    MultipartFormDataContent form = new MultipartFormDataContent();
                    form.Add(new StringContent(content), "JSONString");

                    HttpResponseMessage response = await httpClient.PostAsync(url, form);

                    response.EnsureSuccessStatusCode();
                    httpClient.Dispose();
                    strResponse = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall", "Rest_InvokeZohoInvoiceServiceForFormData", ex);
            }
            return strResponse;
        }



        /// <summary>
        /// Method to invoike rest API
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="methodType">methodType</param>
        /// <param name="content">content</param>
        /// <returns>HttpWebResponse</returns>
        public static HttpWebResponse Rest_InvokeGetService(string url, string methodType, string content = "")
        {
            HttpWebResponse getResponse = null;
            string aouthToken = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol =
           SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                #region  Code to generate the auth tocken by refresh token                
                AouthToken aouthObj = Rest_InvokeZohoInvoiceAuthToken();
                if (aouthObj != null)
                    aouthToken = aouthObj.access_token;
                #endregion

                if (!string.IsNullOrEmpty(aouthToken))
                {

                    request.Headers.Add(HeaderConstant.OrganizationId, ConfigurationManager.AppSettings["orgId"].ToString());
                    request.Headers.Add(HeaderConstant.Authorization, "Zoho-oauthtoken " + aouthToken);
                    request.Method = methodType;


                    if ((methodType.Equals(MethodTypeConstant.POST) || methodType.Equals(MethodTypeConstant.PATCH)) && !string.IsNullOrEmpty(content))
                    {
                        request.ContentType = ContentType.json;
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(content);
                        }
                    }
                    getResponse = (HttpWebResponse)request.GetResponse();
                }

            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall URL: " + url, "Rest_InvokeGetService Type:" + methodType + "Content: " + content, ex);
            }

            return getResponse;

        }

        /// <summary>
        /// Method to generate access token using refresh token
        /// </summary>
        /// <returns>AouthToken</returns>
        public static AouthToken Rest_InvokeZohoInvoiceAuthToken()
        {
            HttpWebResponse httpWebResp = null;
            AouthToken aouthObj = null;
            CurrentAuthtokenRepository tokenRepo = new CurrentAuthtokenRepository();
            try
            {
                ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.SecurityProtocol =
           SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                tblCurrentAuthtoken currentToken = tokenRepo.GetSingle(x => x.CurrentAuthToken != null);
                if (currentToken != null)
                {
                    if (CheckTokenValid(currentToken))
                    {
                        aouthObj = new AouthToken();
                        aouthObj.access_token = currentToken.CurrentAuthToken;
                    }
                    else
                    {
                        string url = @"https://accounts.zoho.com/oauth/v2/token?refresh_token=[referesh-token]&client_id=[client-id]&client_secret=[client-secret]&redirect_uri=[redirect-uri]&grant_type=refresh_token";
                        url = url.Replace("[referesh-token]", ConfigurationManager.AppSettings["referesh-token"].ToString());
                        url = url.Replace("[client-id]", ConfigurationManager.AppSettings["client-id"].ToString());
                        url = url.Replace("[client-secret]", ConfigurationManager.AppSettings["client-secret"].ToString());
                        url = url.Replace("[redirect-uri]", ConfigurationManager.AppSettings["redirect-uri"].ToString());
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = MethodTypeConstant.POST;

                        httpWebResp = (HttpWebResponse)request.GetResponse();

                        if (httpWebResp != null)
                        {
                            Stream stream = httpWebResp.GetResponseStream();
                            if (stream != null)
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string result = reader.ReadToEnd();
                                    aouthObj = JsonConvert.DeserializeObject<AouthToken>(result);
                                }
                            }
                        }

                        #region Code to update the token in DB
                        currentToken.CurrentAuthToken = aouthObj.access_token;
                        currentToken.CreatedDate = DateTime.Now;
                        tokenRepo.Update(currentToken);
                        tokenRepo.SaveChanges();
                        #endregion
                    }
                }
                else
                {
                    //Code to add auth token
                    string url = @"https://accounts.zoho.com/oauth/v2/token?refresh_token=[referesh-token]&client_id=[client-id]&client_secret=[client-secret]&redirect_uri=[redirect-uri]&grant_type=refresh_token";
                    url = url.Replace("[referesh-token]", ConfigurationManager.AppSettings["referesh-token"].ToString());
                    url = url.Replace("[client-id]", ConfigurationManager.AppSettings["client-id"].ToString());
                    url = url.Replace("[client-secret]", ConfigurationManager.AppSettings["client-secret"].ToString());
                    url = url.Replace("[redirect-uri]", ConfigurationManager.AppSettings["redirect-uri"].ToString());
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = MethodTypeConstant.POST;

                    httpWebResp = (HttpWebResponse)request.GetResponse();

                    if (httpWebResp != null)
                    {
                        Stream stream = httpWebResp.GetResponseStream();
                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string result = reader.ReadToEnd();
                                aouthObj = JsonConvert.DeserializeObject<AouthToken>(result);
                            }
                        }
                    }

                    #region Code to update the token in DB
                    currentToken = new tblCurrentAuthtoken();
                    currentToken.CurrentAuthTokenName = "ZohoDesk";
                    currentToken.CurrentAuthToken = aouthObj.access_token;
                    currentToken.CreatedDate = DateTime.Now;
                    tokenRepo.Add(currentToken);
                    tokenRepo.SaveChanges();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall", "Rest_InvokeAuthToken", ex);
            }
            return aouthObj;
        }

        /// <summary>
        /// Check access token validity
        /// </summary>
        /// <param name="currentToken"></param>
        /// <returns>bool</returns>
        public static bool CheckTokenValid(tblCurrentAuthtoken currentToken)
        {

            bool flag = false;
            try
            {

                if (currentToken != null && currentToken.CreatedDate != null)
                {
                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(currentToken.CreatedDate);
                    if (ts.TotalMinutes > 30)
                        flag = false;
                    else
                        flag = true;
                }
                else
                {
                    //generate new 
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                LibLogging.WriteErrorToDB("ServiceCall", "CheckTokenValid", ex);
                flag = false;
            }
            return flag;
        }

        public class AouthToken
        {
            public string access_token { get; set; }
            public string api_domain { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; }
        }

        #endregion

        #region Shopiphy Rest API call

        #endregion

    }
}
