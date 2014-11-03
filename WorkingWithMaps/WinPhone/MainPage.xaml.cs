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
using Xamarin;


namespace WorkingWithMaps.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            FormsMaps.Init();

            // TODO: when deploying to Windows Store
            // string applicationId = "APP_ID_FROM_PORTAL", authToken = "AUTH_TOKEN_FROM_PORTAL";
            // FormsMaps.Init(applicationId, authToken);
            
            Content = WorkingWithMaps.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
