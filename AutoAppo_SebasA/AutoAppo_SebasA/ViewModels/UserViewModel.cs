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
        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();
                roles = await MyUserRole.GetAllUserRoleList();
                if (roles == null)
                {
                    return null;
                }
                else
                {
                    return roles;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> AddUser(string pEmail, string pName, string pPassword,
            string pIDNumber, string pPhoneNumber, string pAddress, int pUserRole,
            int pUserStatus = 3)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyUser.Email = pEmail;
                MyUser.LoginPassword = pPassword;
                MyUser.Name = pName;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Address = pAddress;
                MyUser.CardId = pIDNumber;
                MyUser.UserRoleId = pUserRole;
                MyUser.UserStatusId = pUserStatus;
                bool R = await MyUser.AddUser();
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
