using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MobileCRM.Models
{
    public class OpportunitiesOptionItem : OptionItem
    {
        public override string Title { get { return "Opportunities"; } }
    }

    public class ContactsOptionItem : OptionItem
    {
        public override string Title { get { return "Contacts"; } }
    }

    public class LeadsOptionItem : OptionItem
    {
        public override string Title { get { return "Leads"; } }
    }

    public class AccountsOptionItem : OptionItem
    {
        public override string Title { get { return "Accounts"; } }
    }

    public class OptionItem
    {
        public virtual string Title { get { var n = GetType().Name; return n.Substring(0, n.Length - 10); } }
        public virtual int Count { get; set; }
        public virtual bool Selected { get; set; }
    }
}

