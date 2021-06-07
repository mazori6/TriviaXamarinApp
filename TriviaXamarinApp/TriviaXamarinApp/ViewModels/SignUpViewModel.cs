using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;

namespace TriviaXamarinApp.ViewModels
{
    class SignUpViewModel : INotifyPropertyChanged
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

        private string nickname;
        public string NickName
        {
            get
            {
                return this.nickname;
            }
            set
            {
                if (this.nickname != value)
                {
                    this.nickname = value;
                    OnPropertyChanged(nameof(NickName));
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


        public ICommand RegisterCommand => new Command(Register);

        private async void Register()
        {
            if (Email != "" && Password != "" && NickName != "")
            {
                TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
                User u = new User()
                {

                    Email = Email,
                    Password = Password,
                    NickName = NickName,
                };
                bool b = await proxy.RegisterUser(u);

                if (b)
                {
                    ((App)App.Current).User = u;
                    Push.Invoke(new UserPage());

                }
                else
                {
                    Error = "Password or Email are already Exist";
                }
            }
            else
            {
                Error = "NickName or Password or Email cannot be blank";
            }
           
        }
        public SignUpViewModel()
        {

        }
    }
}
