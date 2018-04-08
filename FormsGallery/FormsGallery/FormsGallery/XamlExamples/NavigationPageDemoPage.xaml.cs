using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.XamlExamples
{
    public partial class NavigationPageDemoPage : ContentPage
    {
        public NavigationPageDemoPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.StyleId;

            Assembly assembly = GetType().GetTypeInfo().Assembly;
            Type pageType = assembly.GetType("FormsGallery.XamlExamples." + id);
            Page page = (Page)Activator.CreateInstance(pageType);
            await Navigation.PushAsync(page);
        }
    }
}