using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using TriviaXamarinApp.ViewModels;
using System.ComponentModel;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            GameVIewModel context = new GameVIewModel();
            this.BindingContext = context;
            context.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
    }
}