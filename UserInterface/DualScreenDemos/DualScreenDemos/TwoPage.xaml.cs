using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;

namespace DualScreenDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoPage : ContentPage
    {
        IItemsLayout linearLayout = null;
        IItemsLayout gridLayout = null;
        bool disableUpdates = false;

        public DualScreenInfo DualScreenLayoutInfo { get; }
        bool IsSpanned => DualScreenLayoutInfo.SpanningBounds.Length > 0;

        public TwoPage()
        {
            InitializeComponent();
            DualScreenLayoutInfo = new DualScreenInfo(layout);

            cv.ItemsSource =
                Enumerable.Range(0, 1000)
                    .Select(i => $"Page {i}")
                    .ToList();
        }

        protected override void OnAppearing()
        {
            DualScreenLayoutInfo.PropertyChanged += OnFormsWindowPropertyChanged;
            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
            SetupColletionViewLayout();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DualScreenLayoutInfo.PropertyChanged -= OnFormsWindowPropertyChanged;
            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        void OnFormsWindowPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Content == null || disableUpdates)
                return;

            if(e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
            {                
                SetupColletionViewLayout();
            }
            else if (e.PropertyName == nameof(DualScreenInfo.Current.SpanningBounds))
            {
                OnPropertyChanged(nameof(ContentHeight));
                OnPropertyChanged(nameof(ContentWidth));
            }
            else if (e.PropertyName == nameof(DualScreenInfo.Current.HingeBounds))
            {
                OnPropertyChanged(nameof(HingeWidth));
            }
        }

        public double ContentHeight => (!DualScreenLayoutInfo.IsLandscape) ? Pane1Height : Pane1Height + Pane2Height;

        public double ContentWidth => IsSpanned ? (DualScreenLayoutInfo.SpanningBounds[0].Width) : layout.Width;

        public double Pane1Height => IsSpanned ? (DualScreenLayoutInfo.SpanningBounds[0].Height) : layout.Height;

        public double Pane2Height => IsSpanned ? (DualScreenLayoutInfo.SpanningBounds[1].Height) : 0d;

        public double HingeWidth => DualScreenLayoutInfo?.HingeBounds.Width ?? DualScreenInfo.Current?.HingeBounds.Width ?? 0d;


        void SetupColletionViewLayout()
        {
            disableUpdates = true;
            var resetCV = cv;
            if (linearLayout == null && cv.ItemsLayout is LinearItemsLayout linear)
            {
                linearLayout = cv.ItemsLayout;
                linear.SnapPointsType = SnapPointsType.None;
                linear.SnapPointsAlignment = SnapPointsAlignment.Start;
            }

            if (gridLayout == null && cv.ItemsLayout is GridItemsLayout)
                gridLayout = cv.ItemsLayout;
            
            if (DualScreenLayoutInfo.IsLandscape)
            {
                if (cv.ItemsLayout != linearLayout)
                {
                    resetCV.ItemsSource = null;
                    resetCV.ItemsLayout = linearLayout;
                    Content = null;
                }
            }
            else
            {
                if (cv.ItemsLayout != gridLayout)
                {
                    resetCV.ItemsSource = null;
                    resetCV.ItemsLayout = gridLayout;
                    Content = null;
                }
            }

            if (Content == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Content = resetCV;
                    resetCV.ItemsSource =
                        Enumerable.Range(0, 1000)
                            .Select(i => $"Page {i}")
                            .ToList();

                    disableUpdates = false;
                });
            }
            else
            {
                disableUpdates = false;
            }
        }
    }
}