using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ThemesDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			MainPage = new BasicPage ();
		}
	}
}

