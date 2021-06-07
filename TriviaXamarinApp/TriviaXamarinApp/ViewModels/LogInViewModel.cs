using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
    

namespace TriviaXamarinApp.ViewModels
{
  
    class LogInViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public event Action<Page> Push;

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        private string error;
        public string Error
        {
            get
            {
                return this.error;
            }
            set
            {
                if (this.error != value)
                {
                    this.error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }
        public ICommand LogInCommand => new Command(ToLogIn);


        public async void ToLogIn()
        {
            if (Email == null || Password == null)
            {
                Error = "You must fill both fileds";
            }
            else
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                User u = await proxy.LoginAsync(Email, Password);
                if (u == null)
                {
                    Error = "Password or Email are incorrect!";
                }
                else
                {

                    ((App)App.Current).User = u;
                    Push.Invoke(new UserPage());

                }
            }
        }
    }
}
