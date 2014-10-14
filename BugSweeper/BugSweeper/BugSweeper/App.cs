using System;
using Xamarin.Forms;

namespace BugSweeper
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new BugSweeperPage();
        }
    }
}
