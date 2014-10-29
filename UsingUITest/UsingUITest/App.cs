using System;
using Xamarin.Forms;

namespace UsingUITest
{
	/// <summary>
	/// Demo of setting control identifiers to use with Calabash for testing
	/// http://forums.xamarin.com/discussion/21148/calabash-and-xamarin-forms-what-am-i-missing
	/// </summary>
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MyPage ();
		}
	}
}

