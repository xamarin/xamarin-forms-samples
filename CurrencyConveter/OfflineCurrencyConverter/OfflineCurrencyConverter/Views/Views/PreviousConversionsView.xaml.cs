using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfflineCurrencyConverter.Views.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreviousConversionsView : ContentView
	{
		public PreviousConversionsView ()
		{
			InitializeComponent ();
            if(Device.RuntimePlatform == Device.Android)
            {
                ConversionsList.RowHeight = 80;
            }
            else if(Device.RuntimePlatform == Device.iOS)
            {
                ConversionsList.RowHeight = 55;
            }
		}
	}
}