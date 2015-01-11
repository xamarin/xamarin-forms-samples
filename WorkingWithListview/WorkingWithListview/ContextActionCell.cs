using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkingWithListview
{
    public class ContextActionCell : TextCell
    {
        public ContextActionCell()
        {

            this.SetBinding(TextCell.TextProperty, new Binding("Title"));

            var mi = new MenuItem { Text = "test" };

            mi.SetBinding(MenuItem.CommandProperty, "ContextItemTapped");
            mi.SetBinding(MenuItem.CommandParameterProperty, "Title");

            this.ContextActions.Add(mi);
        }
    }
}
