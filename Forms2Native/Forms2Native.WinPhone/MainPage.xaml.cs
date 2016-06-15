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
using Forms2Native;

namespace Forms2Native.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage ()
        {
            InitializeComponent ();

            Forms.Init ();

            LoadApplication (new Forms2Native.App ());

            MessagingCenter.Subscribe<MyFirstPage, NativeNavigationArgs> (
	            this,
	            App.NativeNavigationMessage,
	            HandleNativeNavigationMessage);
        }

        private void HandleNativeNavigationMessage (MyFirstPage sender, NativeNavigationArgs args)
        {
            sender.Navigation.PushAsync (args.Page);
        }
    }
}
