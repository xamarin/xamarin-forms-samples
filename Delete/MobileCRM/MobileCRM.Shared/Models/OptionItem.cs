using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;

namespace MobileCRM.Models
{
    public class OptionItem<T> : OptionItem
	{
	}

    public class OptionItem
    {
        public string Title { get { return GetType().Name; } }
        public int Count { get; set; }
        public bool Selected { get; set; }
    }
}

