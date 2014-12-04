using System;
using Xamarin.Forms;
using MobileCRM.Shared.Pages;

namespace MobileCRM
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new RootPage();
		}
	}
}

