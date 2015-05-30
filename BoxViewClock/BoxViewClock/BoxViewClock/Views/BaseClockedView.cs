using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public abstract class BaseClockedView:BoxView, IUpdateLayoutable{
        public BaseClockedView()
        {
        }
        public abstract void UpdateLayout(Page page);
    }
}
