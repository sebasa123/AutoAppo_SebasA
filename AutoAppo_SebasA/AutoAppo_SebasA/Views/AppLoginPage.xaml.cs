﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoAppo_SebasA.ViewModels;

namespace AutoAppo_SebasA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        UserViewModel viewModel;
        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool R = false;
            if (TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Checking user access");
                    await Task.Delay(2000);
                    string email = TxtEmail.Text.Trim();
                    string password = TxtPassword.Text.Trim();
                    R = await viewModel.UserAccessValidation(email, password);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await DisplayAlert("Validation error", "User email and password are required:", "OK");
                return;
            }
            if (R)
            {
                GlobalObjects.LocalUser = await viewModel.GetUserData(TxtEmail.Text.Trim());
                await Navigation.PushAsync(new OptionsPage());
                return;
            }
            else
            {
                await DisplayAlert("Validation failed", "Access denied", "OK");
                return;
            }
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void LblPasswordRecovery_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordRecoveryPage());
        }
    }
}