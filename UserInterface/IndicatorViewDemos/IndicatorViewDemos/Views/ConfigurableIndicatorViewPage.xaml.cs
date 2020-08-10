using System;
using System.Collections.Generic;
using System.Reflection;
using IndicatorViewDemos.Controls;
using Xamarin.Forms;

namespace IndicatorViewDemos.Views
{
    public partial class ConfigurableIndicatorViewPage : ContentPage
    {
        public ConfigurableIndicatorViewPage()
        {
            InitializeComponent();

            PopulateColorPickers();
        }

        void PopulateColorPickers()
        {
            List<string> colors = new List<string>();
            foreach (var field in typeof(Xamarin.Forms.Color).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (field != null && !String.IsNullOrEmpty(field.Name))
                    colors.Add(field.Name);
            }
            indicatorColorPicker.ItemsSource = colors;
            indicatorColorPicker.SelectedIndex = 1;
            selectedIndicatorColorPicker.ItemsSource = colors;
            selectedIndicatorColorPicker.SelectedIndex = 2;
            maximumVisbilePicker.SelectedIndex = 0;
            indicatorSizePicker.SelectedIndex = 0;
        }

        void OnIndicatorColorChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            
            string colorName = (string)picker.SelectedItem;
            FieldInfo colorField = typeof(Color).GetRuntimeField(colorName);
            Color selectedColor = (Color)colorField.GetValue(null);

            if (picker.StyleId.Equals("indicatorColorPicker"))
            {
                indicatorView.IndicatorColor = selectedColor;
            }
            else
            {
                indicatorView.SelectedIndicatorColor = selectedColor;
            }
        }

        void OnIndicatorShapeChanged(object sender, EventArgs e)
        {
            indicatorView.IndicatorsShape = (IndicatorShape)(sender as EnumPicker).SelectedItem;          
        }

        void OnMaximumVisibleChanged(object sender, EventArgs e)
        {
            indicatorView.MaximumVisible = Convert.ToInt32((sender as Picker).SelectedItem);
        }

        void OnIndicatorSizeChanged(object sender, EventArgs e)
        {
            indicatorView.IndicatorSize = Convert.ToDouble((sender as Picker).SelectedItem);
        }
    }
}
