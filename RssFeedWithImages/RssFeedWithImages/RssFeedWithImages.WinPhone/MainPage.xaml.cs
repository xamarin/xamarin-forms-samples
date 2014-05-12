using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;


namespace RssFeedWithImages.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();
            Content = RssFeedWithImages.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
