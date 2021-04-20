using System;
using Xamarin.Forms;

namespace BugSweeper
{
	public class App : Application
    {
		public App ()
        {
            MainPage = new BugSweeperPage();
        }
    }
}
