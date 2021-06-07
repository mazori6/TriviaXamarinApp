using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;
namespace TriviaXamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            MainPageViewModel viewModel = new MainPageViewModel();
            viewModel.Push += (p) => Navigation.PushAsync(p);
            BindingContext = viewModel;
        }
     
  
      
    }
}
