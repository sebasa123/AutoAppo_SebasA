﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoAppo_SebasA.ViewModels;
using AutoAppo_SebasA.Models;

namespace AutoAppo_SebasA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        UserViewModel viewModel;
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadUserRolesList();
        }

        private async void LoadUserRolesList()
        {
            //PckrUserRole.ItemsSource = await viewModel.GetUserData();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnApply_Clicked(object sender, EventArgs e)
        {
            UserRole SelectedUserRole = PckrUserRole.SelectedItem as UserRole;
            bool R = await viewModel.AddUser(TxtEmail.Text.Trim(), TxtName.Text.Trim(),
                TxtPassword.Text.Trim(), TxtIDNumber.Text.Trim(), TxtPhone.Text.Trim(),
                TxtAddress.Text.Trim(), SelectedUserRole.UserRoleId);

            if(R)
            {
                await DisplayAlert(": )", "User added succesfully", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(": /", "Something went wrong", "OK");
            }
            

        }
    }
}