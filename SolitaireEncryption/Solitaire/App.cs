using System;
using Xamarin.Forms;

namespace Solitaire
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new SolitairePage ();
		}
	}
}

