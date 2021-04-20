using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;

namespace DualScreenDemos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NestedTwoPaneViewSplitAcrossHinge : ContentPage
	{
		public NestedTwoPaneViewSplitAcrossHinge()
		{
			InitializeComponent();
		}
	}
}