using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_SebasA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoAppo_SebasA.Models;

namespace AutoAppo_SebasA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAppointmentListPage : ContentPage
    {
        UserViewModel vm;
        public MyAppointmentListPage()
        {
            InitializeComponent();
            BindingContext = vm = new UserViewModel();
            LoadAppos(GlobalObjects.LocalUser.IDUsuario);
        }

        private async void LoadAppos(int pUserID)
        {
            LstApppoList.ItemsSource = await vm.GetAppoList(pUserID);
        }


    }
}