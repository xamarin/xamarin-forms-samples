using System;
using Xamarin.Forms;

namespace VisualDemos
{
    public partial class ProgressBarPage : ContentPage
    {
        bool _isVisible = false;
        double _percentage = 0.0;

        public double PercentageCounter
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                OnPropertyChanged();
            }
        }

        public double Counter => _percentage * 10;

        public ProgressBarPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _isVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                double progress = PercentageCounter + 0.1;
                if (progress > 1)
                    progress = 0;

                PercentageCounter = progress;
                return _isVisible;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isVisible = false;
        }
    }
}
