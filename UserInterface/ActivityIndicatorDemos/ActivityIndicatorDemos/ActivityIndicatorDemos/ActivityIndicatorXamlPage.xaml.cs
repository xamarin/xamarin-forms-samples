using System;

using Xamarin.Forms;

namespace ActivityIndicatorDemos
{
    public partial class ActivityIndicatorXamlPage : ContentPage
    {
        bool isTaskRunning;

        public ActivityIndicatorXamlPage()
        {
            InitializeComponent();
            UpdateUiState();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            isTaskRunning = !isTaskRunning;
            UpdateUiState();
        }

        void UpdateUiState()
        {
            runningStatusLabel.Text = isTaskRunning ? "A task is in progress." : "All tasks complete!";
            defaultActivityIndicator.IsRunning = isTaskRunning;
            styledActivityIndicator.IsRunning = isTaskRunning;
        }
    }
}