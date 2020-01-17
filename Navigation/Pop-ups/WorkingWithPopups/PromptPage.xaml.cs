using System;
using Xamarin.Forms;

namespace WorkingWithPopups
{
    public partial class PromptPage : ContentPage
    {
        public PromptPage()
        {
            InitializeComponent();
        }

        async void OnQuestion1ButtonClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Question 1", "What's your name?", initialValue:string.Empty);
            if (!string.IsNullOrWhiteSpace(result))
            {
                question1ResultLabel.Text = $"Hello {result}.";
            }
        }

        async void OnQuestion2ButtonClicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue:"10", maxLength: 2, keyboard: Keyboard.Numeric);
            if (!string.IsNullOrWhiteSpace(result))
            {
                int number = Convert.ToInt32(result);
                question2ResultLabel.Text = number == 10 ? "Correct." : "Incorrect.";
            }
        }
    }
}

