using System;
using System.Collections.Generic;
using System.Text;
using AutoAppo_SebasA.Models;

namespace AutoAppo_SebasA
{
    public static class GlobalObjects
    {
        public static string MimeType = "Application/json";
        public static string ContentType = "Content-Type";
        public static UserDTO LocalUser = new UserDTO();
    }
}
