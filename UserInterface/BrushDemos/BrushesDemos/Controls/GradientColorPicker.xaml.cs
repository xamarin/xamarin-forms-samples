using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BrushesDemos.Controls
{
    public partial class GradientColorPicker : ContentView
    {
        public event EventHandler<ColorSource> ColorSelected;

        public ColorSource SelectedColorSource { get; set; }

        public GradientColorPicker()
        {
            InitializeComponent();

            List<string> colors = new List<string>
            {
                "#ff0000", "#ff8000", "#ffbf00",
                "#ffff00", "#80ff00", "#00ff40",
                "#00ffff", "#00bfff", "#0080ff",
                "#0000ff", "#4000ff", "#8000ff",
                "#bf00ff", "#ff00ff", "#ff00bf",
                "#ff0080", "#ff0040", "#ff0000"
            };

            BindableLayout.SetItemsSource(colorsLayout, colors.Select(c => new ColorSource(Color.FromHex(c))));
        }

        void InvokeColorSelected(ColorSource color)
        {
            ColorSelected?.Invoke(this, color);
        }

        void OnColorSourceTapped(object sender, EventArgs e)
        {
            if (!(sender is BindableObject bindable) || !(bindable.BindingContext is ColorSource selectedColorSource))
            {
                return;
            }

            if (SelectedColorSource == selectedColorSource)
            {
                return;
            }

            selectedColorSource.IsSelected = true;

            if (SelectedColorSource != null)
            {
                SelectedColorSource.IsSelected = false;
            }

            SelectedColorSource = selectedColorSource;
        }

        void OnOKButtonClicked(object sender, EventArgs e) => Dismiss();

        void OnCancelButtonClicked(object sender, EventArgs e) => Close();

        void Close()
        {
            SelectedColorSource = null;
            Dismiss();
        }

        void Dismiss()
        {
            InvokeColorSelected(SelectedColorSource);
        }
    }
}
