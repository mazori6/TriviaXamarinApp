using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using TriviaXamarinApp.Views;
namespace TriviaXamarinApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands
        public ICommand SignUpCommand { get; set; }
        public ICommand LogInCommand { get; set; }

        public event Action<Page> Push;

        public MainPageViewModel()
        {
            LogInCommand = new Command(LogIn);
            SignUpCommand = new Command(SignUp);

        }
        private void LogIn()
        {
            Push?.Invoke(new LogIn());
        }
        private void SignUp()
        {
            Push?.Invoke(new SignUp());
        }
        #endregion
    }
}
