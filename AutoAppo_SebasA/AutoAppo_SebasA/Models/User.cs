﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AutoAppo_SebasA.Models
{
    public class User
    {
        public RestRequest Request { get; set; }
        
        public User()
        {
            
        }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string LoginPassword { get; set; } = null!;
        public string CardId { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }
        public virtual UserRole? UserRole { get; set; } = null!;
        public virtual UserStatus? UserStatus { get; set; } = null!;
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

        public async Task<bool> AddUser()
        {
            try
            {
                string RouteSuffix = string.Format("Users");
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
        public async Task<List<User>> GetAllUserNameList(string pName)
        {
            try
            {
                string RouteSuffix = string.Format("User");
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
                    var list = JsonConvert.DeserializeObject<List<User>>(pName);
                    return list;
                }
                else
                {
                    return null;
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
