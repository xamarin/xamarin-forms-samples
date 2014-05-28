using System;
using Xamarin.Forms;

namespace TabbedPageDemo
{
	public partial class TabbedPageDemoPage : TabbedPage
    {
        public TabbedPageDemoPage()
        {
            InitializeComponent();

            this.ItemsSource = MonkeyDataModel.All;
        }
    }
}
