using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace AutoAppo_SebasA.Models
{
    public class User
    {
        public RestRequest Request { get; set; }
        const string MimeType = "Application/json";
        const string ContentType = "Content-Type";
        public User()
        {
            
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginPassword { get; set; }
        public string CardId { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        //public virtual ICollection<Appointment> Appointments { get; set; }

        public async Task<bool> ValidateLogin()
        {
            try
            {
                string RouteSuffix = string.Format(
                    "Users/ValidateUserLogin?pUserName={0}&pPassword={1}",
                    this.Email, this.LoginPassword);
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSuffix;
                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,
                    Services.APIConnection.ApiKeyValue);
                Request.AddHeader(ContentType, MimeType);
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
    }
}
