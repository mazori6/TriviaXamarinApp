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
using System.Linq;
using System.Threading.Tasks;
namespace TriviaXamarinApp.ViewModels
{
    class GameVIewModel : INotifyPropertyChanged
    {



        public event Action<Page> Push;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public delegate Task<bool> PopupDelegate();
        public event PopupDelegate Popup;

        private string correctanswer;
        public string CorrectAnswer
        {
            get
            {
                return correctanswer;
            }
            set
            {
                if (correctanswer != value)
                {
                    correctanswer = value;
                    OnPropertyChanged(nameof(CorrectAnswer));
                }
            }
        }

        private string qtext;
        public string QText
        {
            get
            {
                return qtext;
            }
            set
            {
                if (qtext != value)
                {
                    qtext = value;
                    OnPropertyChanged(nameof(QText));
                }
            }
        }
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
        private string[] answers;
        public string[] Answers
        {
            get
            {
                return answers;
            }
            set
            {
                if (answers != value)
                {
                    answers = value;
                    OnPropertyChanged(nameof(Answers));
                }
            }
        }

        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
        }




        private async void Play()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();

            AmericanQuestion q = await proxy.GetRandomQuestion();

            this.CorrectAnswer = q.CorrectAnswer;
            this.NickName = q.CreatorNickName;
            this.QText = q.QText;
            this.Answers = new string[4];
            for (int i = 0; i < answers.Length - 1; i++)
            {
                Answers[i] = q.OtherAnswers[i];
            }
            Answers[answers.Length - 1] = CorrectAnswer;
            Random r = new Random();

            Answers = Answers.OrderBy(x => r.Next()).ToArray();

        }


        public ICommand AnswerCommand => new Command<string>(Answer);
        private async void Answer(string answer)
        {
            await Task.Delay(1000);
            int selectedAnswer = int.Parse(answer);
            int correctAnswerIndex = Array.FindIndex(Answers, a => a == CorrectAnswer);

           
            if (selectedAnswer == correctAnswerIndex)
            {
                Score++;

            }
            else
            {
                Score = 0; // ברצף
            }
            
            Play();
        }
        public GameVIewModel()
        {
            Score = 0;
            Play();

        }
    }
}
