using System;
using Xamarin.QuickUI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Meetum.Views
{
    public class TabItem : INotifyPropertyChanged
    {
        private string title;
        private string icon;

        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title == value)
                    return;

                this.title = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get { return this.icon; }
            set
            {
                if (this.icon == value)
                    return;

                this.icon = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler (this, new PropertyChangedEventArgs (propertyName));
        }
    }
    
}
