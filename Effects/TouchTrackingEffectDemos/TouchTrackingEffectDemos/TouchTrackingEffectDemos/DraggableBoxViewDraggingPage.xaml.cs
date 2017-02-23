using System;
using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{
    public partial class DraggableBoxViewDraggingPage : ContentPage
    {
        Random random = new Random();

        public DraggableBoxViewDraggingPage()
        {
            InitializeComponent();
            AddBoxViewToLayout();
        }

        void OnNewBoxViewClicked(object sender, EventArgs args)
        {
            AddBoxViewToLayout();
        }

        void OnClearClicked(object sender, EventArgs args)
        {
            absoluteLayout.Children.Clear();
        }

        void AddBoxViewToLayout()
        {
            DraggableBoxView boxView = new DraggableBoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Color = new Color(random.NextDouble(),
                                  random.NextDouble(),
                                  random.NextDouble())
            };
            absoluteLayout.Children.Add(boxView);
        }
    }
}
