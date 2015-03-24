using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkingWithListview
{
	class Monkey {
		public string Name {get;set;}
		public string Description {get;set;}
	}

	public partial class HeaderFooterXaml : ContentPage
	{
		public HeaderFooterXaml ()
		{
			InitializeComponent ();

			listView.ItemsSource = new Monkey[] {
				new Monkey {Name="a", Description="aaa"},
				new Monkey {Name="b", Description="bbb"},
				new Monkey {Name="c", Description="ccc"},
				new Monkey {Name="d", Description="ddd"},
				new Monkey {Name="e", Description="eee"},
				new Monkey {Name="f", Description="fff"},
//				new Monkey {Name="g", Description="ggg"},
//				new Monkey {Name="i", Description="iii"},
//				new Monkey {Name="j", Description="jjj"},
//				new Monkey {Name="k", Description="kkk"},
//				new Monkey {Name="l", Description="lll"},
//				new Monkey {Name="m", Description="mmm"},
//				new Monkey {Name="n", Description="nnn"},
//				new Monkey {Name="o", Description="ooo"},
			};
		}
	}
}

