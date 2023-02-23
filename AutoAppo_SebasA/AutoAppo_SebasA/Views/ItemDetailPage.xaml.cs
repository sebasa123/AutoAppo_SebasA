using System.ComponentModel;
using AutoAppo_SebasA.ViewModels;
using Xamarin.Forms;

namespace AutoAppo_SebasA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}