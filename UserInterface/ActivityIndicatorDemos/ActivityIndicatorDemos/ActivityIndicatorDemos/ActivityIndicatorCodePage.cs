using System;

using Xamarin.Forms;

namespace ActivityIndicatorDemos
{
    public class ActivityIndicatorCodePage : ContentPage
    {
        Label runningStatusLabel;
        ActivityIndicator defaultActivityIndicator;
        ActivityIndicator styledActivityIndicator;
        Button activityStatusToggle;
        bool isTaskRunning;

        public ActivityIndicatorCodePage()
        {
            Title = "ActivityIndicator Code Demo";

            runningStatusLabel = new Label
            {
                Text = "All tasks are complete!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            defaultActivityIndicator = new ActivityIndicator
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Fill
            };

            styledActivityIndicator = new ActivityIndicator
            {
                Color = Color.Orange,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Fill
            };

            activityStatusToggle = new Button
            {
                Text = "Toggle task status",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            activityStatusToggle.Clicked += OnButtonClicked;

            Content = new StackLayout
            {
                Children =
                {
                    runningStatusLabel,
                    defaultActivityIndicator,
                    styledActivityIndicator,
                    activityStatusToggle
                }
            };

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