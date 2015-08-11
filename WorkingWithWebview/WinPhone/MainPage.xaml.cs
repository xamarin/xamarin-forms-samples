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
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;


namespace WorkingWithWebview.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage 
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();

            //SaveFilesToIsoStore();

            LoadApplication(new WorkingWithWebview.App()); // new in 1.3
        }
    }
}
