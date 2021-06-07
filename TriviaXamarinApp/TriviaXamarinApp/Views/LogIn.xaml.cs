using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {

        public LogIn()
        {
            LogInViewModel context = new LogInViewModel();
            this.BindingContext = context;
            context.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();


   

        }
      
    }
}