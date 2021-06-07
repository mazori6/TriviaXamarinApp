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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            UserPageViewModel context = new UserPageViewModel();
            this.BindingContext = context;
            context.Push += (p) => Navigation.PushAsync(p);
            InitializeComponent();
        }
       
    }
  
}