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
        public OptionsPage()
        {
            InitializeComponent();
            //BindingContext = viewModel = new UserViewModel();
            //LoadUserRolesList();
        }
    }
}