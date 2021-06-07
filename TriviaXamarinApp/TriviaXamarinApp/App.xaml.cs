using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;

namespace TriviaXamarinApp
{
    public partial class App : Application
    {
        public User User { get; set; }

        public App()
        {
            InitializeComponent();


            Page p = new MainPage();

            MainPage = new NavigationPage(p);
           

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
