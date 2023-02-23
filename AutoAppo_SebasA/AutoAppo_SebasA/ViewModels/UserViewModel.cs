using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_SebasA.Models;

namespace AutoAppo_SebasA.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        public UserStatus MyUserStatus { get; set; }
        public User MyUser { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyUserRole = new UserRole();
            MyUserStatus = new UserStatus();
        }
        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUser.Email = pEmail;
                MyUser.LoginPassword = pPassword;
                bool R = await MyUser.ValidateLogin();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally 
            { 
                IsBusy = false; 
            }
        }
    }
}
