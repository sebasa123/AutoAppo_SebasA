using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoAppo_SebasA.Models;
using AutoAppo_SebasA.ViewModels;

namespace AutoAppo_SebasA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage : ContentPage
    {
        UserViewModel viewModel;
        public OptionsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            //LoadUserNameList();
            //DesabilitarBotones();
        }
        //private async void LoadUserNameList()
        //{
        //    LblNombreUsuario.ItemsSource = await viewModel.GetUserName();
        //}
        //private async void DesabilitarBotones()
        //{
        //    UserRole SelectedUserRole = UserRole;
        //    if (SelectedUserRole.Equals(2))
        //    {
        //        BtnAppoManagement.IsEnabled = false;
        //        BtnUserManagement.IsEnabled = false;
        //        BtnServicesManagement.IsEnabled = false;
        //        BtnScheduleManagement.IsEnabled = false;
        //    }
        //    else
        //    {
        //        await 
        //    }
        //}
    }
}