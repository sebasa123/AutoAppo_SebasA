using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public UserDTO MyUserDTO { get; set; }
        public Appointment MyAppointment { get; set; }
        public Email MyEmail { get; set; }
        public RecoveryCode MyRecoveryCode { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyUserRole = new UserRole();
            MyUserStatus = new UserStatus();
            MyUserDTO = new UserDTO();
            MyEmail = new Email();
            MyRecoveryCode = new RecoveryCode();
            MyAppointment = new Appointment();
        }

        public async Task<UserDTO> GetUserData(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                UserDTO user = new UserDTO();
                user = await MyUserDTO.GetUserData(pEmail);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<ObservableCollection<Appointment>> GetAppoList(int pUserID)
        {

            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Appointment> list = 
                    new ObservableCollection<Appointment>();
                MyAppointment.UserId = pUserID;
                list = await MyAppointment.GetAppointmentListByUser();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
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
        public async Task<List<User>> GetUserName(string Name)
        {
            try
            {
                List<User> name = new List<User>();
                name = await MyUser.GetAllUserNameList(Name);
                if (name == null)
                {
                    return null;
                }
                else
                {
                    return name;
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

        public async Task<bool> AddRecoveryCode(string pEmail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyRecoveryCode.Email = pEmail;
                //string RecoveryCode = "ABC123";
                //Tarea: generar codigo aleatorio de 6 digitos
                //entre letras mayusculas y numeros de 1-9
                var rand = new Random();
                var Let = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var Num = ("123456789");
                string randLet = "";
                for (int i = 0; i < 3; i++)
                {
                    int o = rand.Next(26);
                    randLet += Let[o];
                }
                string randNum = "";
                for (int i = 0; i < 3; i++)
                {
                    int o = rand.Next(9);
                    randNum += Num[o];
                }
                string RecoveryCode = randLet + randNum;
                MyRecoveryCode.RecoveryCode1 = RecoveryCode;
                MyRecoveryCode.RecoveryCodeId = 0;
                bool R = await MyRecoveryCode.AddRecoveryCode();
                if (R)
                {
                    MyEmail.SendTo = pEmail;
                    MyEmail.Subject = "AutoAppo password recovery code";
                    MyEmail.Message = string.Format(
                        "Your recovery code is: {0}", RecoveryCode);
                    R = MyEmail.SendEmail();
                }
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

        public async Task<bool> RecoveryCodeValidation(string pEmail, string pRecoveryCode)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyRecoveryCode.Email = pEmail;
                MyRecoveryCode.RecoveryCode1 = pRecoveryCode;
                bool R = await MyRecoveryCode.ValidateRecoveryCode();
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

        public async Task<bool> UpdateUser(UserDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
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
