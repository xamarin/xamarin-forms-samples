using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToolbarItemDemos
{
    public partial class ToolbarItemXaml : ContentPage
    {
        public ToolbarItemXaml()
        {
            InitializeComponent();
        }

        private void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            messageLabel.Text = $"You clicked the \"{item.Text}\" toolbar item.";
        }
    }
}