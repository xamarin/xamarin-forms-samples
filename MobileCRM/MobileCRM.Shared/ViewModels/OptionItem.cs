using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MobileCRM.Models
{
    public class OptionItem<T> : OptionItem
	{
        public override string Title { get { return GetType().GetGenericArguments()[0].Name + "s"; } }
        public override int Count { get; set; }
        public override bool Selected { get; set; }
	}

    public class OptionItem
    {
        public virtual string Title { get { return GetType().GetGenericArguments()[0].Name + "s"; } }
        public virtual int Count { get; set; }
        public virtual bool Selected { get; set; }
    }
}

