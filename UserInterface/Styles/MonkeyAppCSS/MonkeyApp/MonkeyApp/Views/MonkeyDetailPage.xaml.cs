using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonkeyDetailPage : ContentPage
	{
		public MonkeyDetailPage ()
		{
			InitializeComponent ();
		}
	}
}