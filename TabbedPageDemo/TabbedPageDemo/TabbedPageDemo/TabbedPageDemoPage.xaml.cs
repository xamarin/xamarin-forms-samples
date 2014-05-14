using System;
using Xamarin.Forms;

namespace TabbedPageDemo
{
    public partial class TabbedPageDemoPage
    {
        public TabbedPageDemoPage()
        {
            InitializeComponent();

            this.ItemSource = MonkeyDataModel.All;
        }
    }
}
