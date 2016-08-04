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
using Xamarin.Forms.Platform.WinPhone;
using System.IO;
using Windows.Storage;


namespace TodoLocalized.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            LoadApplication(new TodoLocalized.App());

            // Make appbar transparent or hidden... MUST be placed *after* setting the Content, otherwise ApplicationBar appears to be 'null'
            // http://forums.xamarin.com/discussion/comment/84173/#Comment_84173
            // 1) hides app bar
            //ApplicationBar.Mode = ApplicationBarMode.Minimized;
            // 2) sets transparency
            ApplicationBar.Opacity = 0.5;
        }
    }
}
