using System;

using Xamarin.Forms;

namespace WorkingWithListview
{
	public class HeaderFooterPage : ContentPage
	{
		public HeaderFooterPage ()
		{
			Padding = new Thickness (0, 20, 0, 0);

			var listView = new ListView ();

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

			listView.ItemTemplate = new DataTemplate(typeof(TextCell)); // has context actions defined
			listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");

			listView.Header = new StackLayout { 
				Padding = new Thickness(5,10,5,0),
				BackgroundColor = Color.FromHex("#cccccc"),
				Children={
					new Label {Text="Header"},
					new Label {Text="Subhead", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }
				}
			};

			listView.Footer = new Label { Text = "Footer" };

			// currently doesn't work
//			listView.Footer = new StackLayout { 
//				Children={
//					new Label {Text="Footer"},
//					new Label {Text="foot"},
//					new Label {Text="!!"},
//				}
//			};

			Content = new StackLayout { 
				Children = {
					listView
				},
			};
		}
	}
}


