using System;
using Xamarin.Forms;

namespace ControlTemplateDemos.Controls
{
    public partial class HeaderFooterPage : ContentPage
    {
        ControlTemplate tealTemplate;
        ControlTemplate aquaTemplate;

        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(HeaderFooterPage), default(string));

        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }

        bool originalTemplate = true;
        public bool OriginalTemplate
        {
            get { return originalTemplate; }
        }

        public HeaderFooterPage()
        {
            InitializeComponent();
            tealTemplate = (ControlTemplate)Resources["TealTemplate"];
            aquaTemplate = (ControlTemplate)Resources["AquaTemplate"];
        }

        void OnChangeThemeLabelTapped(object sender, EventArgs e)
        {
            originalTemplate = !originalTemplate;
            ControlTemplate = (originalTemplate) ? tealTemplate : aquaTemplate;
        }
    }
}
