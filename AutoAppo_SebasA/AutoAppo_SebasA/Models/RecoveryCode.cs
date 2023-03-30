using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AutoAppo_SebasA.Models
{
    public class RecoveryCode
    {
        public RestRequest Request { get; set; }
        public int RecoveryCodeId { get; set; }
        public string Email { get; set; } = null!;
        public string RecoveryCode1 { get; set; } = null!;
        //public DateTime GenerateDate { get; set; }
        //public bool IsUsed { get; set; }

        public async Task<bool> ValidateRecoveryCode()
        {
            try
            {
                string RouteSuffix = string.Format(
                    "RecoveryCode/ValidateCode?pEmail={0}&pRecoveryCode={1}",
                    this.Email, this.RecoveryCode1);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                throw;
            }
        }
        public async Task<bool> AddRecoveryCode()
        {
            try
            {
                string RouteSuffix = string.Format("RecoveryCodes");
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);
                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);
                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                throw;
            }
        }


    }
}
