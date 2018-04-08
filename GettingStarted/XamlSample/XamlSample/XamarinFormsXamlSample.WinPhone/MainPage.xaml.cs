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


namespace XamarinFormsXamlSample.WinPhone
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
           
			LoadApplication(new XamarinFormsXamlSample.App());
        }
    }
}
