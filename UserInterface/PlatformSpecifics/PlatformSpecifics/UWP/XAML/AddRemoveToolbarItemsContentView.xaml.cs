using System;
using System.Linq;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class AddRemoveToolbarItemsContentView : ContentView
    {
        public static readonly BindableProperty ParentPageProperty = BindableProperty.Create("ParentPage", typeof(Page), typeof(AddRemoveToolbarItemsContentView), null);

        public Page ParentPage
        {
            get { return (Page)GetValue(ParentPageProperty); }
            set { SetValue(ParentPageProperty, value); }
        }

        Action action;

        public AddRemoveToolbarItemsContentView()
        {
            InitializeComponent();
            action = () => ParentPage.DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }

        void OnAddPrimaryButtonClicked(object sender, EventArgs e)
        {
            int index = ParentPage.ToolbarItems.Count(item => item.Order == ToolbarItemOrder.Primary) + 1;
            ParentPage.ToolbarItems.Add(new ToolbarItem(string.Format("Primary {0}", index), "reminders.png", action, ToolbarItemOrder.Primary));
        }

        void OnAddSecondaryButtonClicked(object sender, EventArgs e)
        {
            int index = ParentPage.ToolbarItems.Count(item => item.Order == ToolbarItemOrder.Secondary) + 1;
            ParentPage.ToolbarItems.Add(new ToolbarItem(string.Format("Secondary {0}", index), "reminders.png", action, ToolbarItemOrder.Secondary));
        }

        void OnRemoveButtonClicked(object sender, EventArgs e)
        {
            if (ParentPage.ToolbarItems.Any())
            {
                ParentPage.ToolbarItems.RemoveAt(0);
            }
        }
    }
}
