﻿using System;
using AutoAppo_SebasA.Services;
using AutoAppo_SebasA.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_SebasA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
