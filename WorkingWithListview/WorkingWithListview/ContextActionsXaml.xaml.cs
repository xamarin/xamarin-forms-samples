using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WorkingWithListview
{
    public partial class ContextActionsXaml
    {
        private class BindItem
        {
            public string Title { get; set; }
            public ICommand ContextItemTapped { get; set; }
        }

        public ContextActionsXaml()
        {
            InitializeComponent();

            var showAlert = new Command<object>((parameter) =>
            {
                DisplayAlert("Context Item", string.Format("on item {0} Tapped", parameter), "Ok");
            });

            var items = new List<BindItem>();
            items.Add(new BindItem { Title = "first", ContextItemTapped = showAlert });
            items.Add(new BindItem { Title = "second", ContextItemTapped = showAlert });
            items.Add(new BindItem { Title = "third", ContextItemTapped = showAlert });
            this.BindingContext = items;

        }


    }
}
