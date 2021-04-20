using System;
using System.Linq;
using BrushesDemos.Controls;
using Xamarin.Forms;

namespace BrushesDemos.Views
{
    public partial class LinearGradientBrushExplorerPage : ContentPage
    {
        const uint AnimationSpeed = 200;

        GradientStopCollection gradientStops;
        Point startPoint;
        Point endPoint;
        int offsets;
        Layout layout;

        public LinearGradientBrushExplorerPage()
        {
            InitializeComponent();
            BindingContext = this;

            gradientStops = new GradientStopCollection();
            BindableLayout.SetItemsSource(gradientsStackLayout, gradientStops);
        }

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
            gradientColorPicker.ColorSelected += OnGradientColorPickerColorSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            gradientColorPicker.ColorSelected -= OnGradientColorPickerColorSelected;
        }

        #endregion

        #region Event handlers

        void OnGradientColorPickerColorSelected(object sender, ColorSource e)
        {
            gradientColorPicker.FadeTo(0, 0, Easing.SinInOut);
            gradientColorPicker.TranslateTo(0, 1000, 0, Easing.SinInOut);

            ColorSource selectedColor = gradientColorPicker.SelectedColorSource;

            if (selectedColor == null)
            {
                return;
            }

            if (!(layout.Children.FirstOrDefault() is Entry entry))
            {
                return;
            }

            int red = (int)(selectedColor.Color.R * 255);
            int green = (int)(selectedColor.Color.G * 255);
            int blue = (int)(selectedColor.Color.B * 255);

            entry.Text = $"#{red:X2}{green:X2}{blue:X2}";
        }

        void OnColorPickerTapped(object sender, EventArgs e)
        {
            gradientColorPicker.FadeTo(1, AnimationSpeed, Easing.SinInOut);
            gradientColorPicker.TranslateTo(0, 0, AnimationSpeed, Easing.SinInOut);

            if (((Frame)sender).Parent is Layout<View> layout)
            {
                this.layout = layout;
            }
        }

        void OnGradientChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is BindableObject bindable) || !(bindable.BindingContext is GradientStop gradientStop))
            {
                return;
            }

            gradientStop.Color = GetColorFromString(e.NewTextValue);
            UpdateBackground();
        }

        void OnStartPointChanged(object sender, TextChangedEventArgs e)
        {
            startPoint = GetPointFromString(e.NewTextValue);
            UpdateBackground();
        }

        void OnEndPointChanged(object sender, TextChangedEventArgs e)
        {
            endPoint = GetPointFromString(e.NewTextValue);
            UpdateBackground();
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
            offsets++;
            gradientStops.Add(new GradientStop());
            UpdateOffsets();
        }

        void OnRemoveButtonClicked(object sender, EventArgs e)
        {
            if (gradientStops.Count <= 0)
            {
                return;
            }

            offsets--;
            gradientStops.Remove(gradientStops.Last());
            UpdateOffsets();
            UpdateBackground();            
        }

        #endregion

        #region Helpers

        Color GetColorFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Color.Default;
            }

            try
            {
                return Color.FromHex(value[0].Equals('#') ? value : $"#{value}");
            }
            catch (Exception)
            {
                return Color.Default;
            }
        }

        Point GetPointFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new Point();
            }

            try
            {
                string[] values = value.Split(',');
                return new Point(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]));
            }
            catch (Exception)
            {
                return new Point();
            }
        }

        void UpdateBackground()
        {
            if (startPoint == null || endPoint == null || gradientStops == null)
            {
                return;
            }

            LinearGradientBrush brush = new LinearGradientBrush
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                GradientStops = gradientStops
            };

            if (brush.IsEmpty)
            {
                return;
            }

            gradientFrame.Background = brush;
        }

        void UpdateOffsets()
        {
            float offset = 0f;
            float delta = 1f / (offsets - 1);

            foreach (GradientStop gradientStop in gradientStops)
            {
                gradientStop.Offset = offset;
                offset += delta;
            }
        }

        #endregion
    }
}
