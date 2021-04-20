using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeViewDemos
{
    public partial class SwipeViewCustomItemPage : ContentPage
    {
        public ICommand CheckAnswerCommand { get; private set; }

        public SwipeViewCustomItemPage()
        {
            InitializeComponent();
            CheckAnswerCommand = new Command<string>(CheckAnswer);
            BindingContext = this;
        }

        async void OnIncorrectAnswerInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("Incorrect!", "Try again.", "OK");
        }

        async void OnCorrectAnswerInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("Correct!", "The answer is 4.", "OK");
        }

        void CheckAnswer(string result)
        {
            if (!string.IsNullOrWhiteSpace(result))
            {
                int number = Convert.ToInt32(resultEntry.Text);
                if (number.Equals(4))
                    OnCorrectAnswerInvoked(swipeView2, EventArgs.Empty);
                else
                    OnIncorrectAnswerInvoked(swipeView2, EventArgs.Empty);
            }
        }
    }
}
