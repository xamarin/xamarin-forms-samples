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
public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage // superclass new in 1.3
{
    public MainPage()
    {
        InitializeComponent();
        SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

        global::Xamarin.Forms.Forms.Init();
		global::Xamarin.FormsMaps.Init ();

        LoadApplication(new WorkingWithMaps.App()); // new in 1.3
    }
 }
}
