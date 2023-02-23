using System;
using System.Collections.Generic;
using System.ComponentModel;
using AutoAppo_SebasA.Models;
using AutoAppo_SebasA.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_SebasA.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}