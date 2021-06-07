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
using System.Linq;


namespace TriviaXamarinApp.ViewModels
{
    class UserPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
      

        
    
        public event Action<Page> Push;
        #region Properties

     

        private string nickname;
        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                if (nickname != value)
                {
                    nickname = value;
                    OnPropertyChanged(nameof(NickName));
                }
            }
        }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
     

        #endregion

        #region Commands

       

        public ICommand StartGameCommand => new Command(StartGame);
        #endregion
        



       
        private void StartGame()
        {
            Push.Invoke(new GamePage());

        }
        
   


        public UserPageViewModel()
        {
            if (((App)App.Current).User != null)
            {
                Email = ((App)App.Current).User.Email;
                NickName = ((App)App.Current).User.NickName;
                Password = ((App)App.Current).User.Password;
            }

        } // constructor 
    }
}
