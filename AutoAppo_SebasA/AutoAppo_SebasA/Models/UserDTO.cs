using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AutoAppo_SebasA.Models
{
    public class UserDTO
    {
        public RestRequest Request { get; set;}
        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public string Contrasenna { get; set; } = null!;
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public int IDRol { get; set; }
        public int IDEstado { get; set; }
        public string EstadoDescripcion { get; set; } = null!;
        public string RolDescripcion { get; set; } = null!;

        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                string RouteSuffix = string.Format(
                    "Users/GetUserData?email={0}", email);
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
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    var item = list[0];
                    return item;
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
