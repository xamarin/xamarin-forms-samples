//
//  Copyright 2012, Xamarin Inc.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory.Android {
    public class PersonAdapter : BaseAdapter {
        List<Item> items;

        public PersonAdapter (PersonViewModel viewModel)
        {
            items = new List<Item> ();

            foreach (var pg in viewModel.PropertyGroups) {
                items.Add (new MainHeaderItem (pg.Title));
                foreach (var p in pg.Properties) {

                    PropertyItem item;

                    if (p.Type == PersonViewModel.PropertyType.Phone) {
                        item = new PhonePropertyItem (p);
                    } else if (p.Type == PersonViewModel.PropertyType.Email) {
                        item = new EmailPropertyItem (p);
                    } else if (p.Type == PersonViewModel.PropertyType.Url) {
                        item = new UrlPropertyItem (p);
                    } else if (p.Type == PersonViewModel.PropertyType.Twitter) {
                        item = new TwitterPropertyItem (p);
                    } else {
                        item = new PropertyItem (p);
                    }

                    items.Add (item);
                }
            }
        }

        public void OnItemClick (int position, View v)
        {
            if (0 <= position && position < items.Count) {
                items [position].OnClick (v);
            }
        }

        public override int ViewTypeCount
        {
            get
            {
                // This is the number of different ViewTypes used in the Items
                return 7;
            }
        }

        public override int GetItemViewType (int position)
        {
            return items [position].ViewType;
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return items [position];
        }

        public override long GetItemId (int position)
        {
            return 0;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            return items [position].GetView (convertView, parent);
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        #region Item types

        abstract class Item : Java.Lang.Object {
            public int ViewType { get; private set; }

            public Item (int viewType)
            {
                ViewType = viewType;
            }

            public abstract View GetView (View convertView, ViewGroup parent);

            public virtual void OnClick (View v)
            {
            }
        }

        class MainHeaderItem : Item {
            string text;

            public MainHeaderItem (string text)
                : base (1)
            {
                this.text = text;
            }

            public override View GetView (View convertView, ViewGroup parent)
            {
                var v = convertView;
                if (v == null) {
                    var inflater = ((Activity)parent.Context).LayoutInflater;
                    v = inflater.Inflate (Resource.Layout.GroupHeaderListItem, null);
                }

                var headerTextView = v.FindViewById<TextView> (Resource.Id.HeaderTextView);
                headerTextView.Text = text;

                return v;
            }
        }

        class PropertyItem : Item {
            public PersonViewModel.Property Property { get; private set; }

            public PropertyItem (PersonViewModel.Property property)
                : this (property, 2)
            {
            }

            protected PropertyItem (PersonViewModel.Property property, int viewType)
                : base (viewType)
            {
                this.Property = property;
            }

            protected virtual int LayoutId { get { return Resource.Layout.PropertyListItem; } }

            public override View GetView (View convertView, ViewGroup parent)
            {
                var v = convertView;
                if (v == null) {
                    var inflater = ((Activity)parent.Context).LayoutInflater;
                    v = inflater.Inflate (LayoutId, null);
                }

                var nameTextView = v.FindViewById<TextView> (Resource.Id.NameTextView);
                var valueTextView = v.FindViewById<TextView> (Resource.Id.ValueTextView);

                nameTextView.Text = Property.Name;
                valueTextView.Text = Property.Value;

                return v;
            }
        }

        class PhonePropertyItem : PropertyItem {
            public PhonePropertyItem (PersonViewModel.Property property)
                : base (property, 3)
            {
            }

            protected override int LayoutId
            {
                get
                {
                    return Resource.Layout.PhonePropertyListItem;
                }
            }

            public override void OnClick (View v)
            {
                var intent = new Intent (Intent.ActionCall, global::Android.Net.Uri.Parse (
                        "tel:" + Uri.EscapeDataString (Property.Value)));
                v.Context.StartActivity (intent);
            }
        }

        class EmailPropertyItem : PropertyItem {
            public EmailPropertyItem (PersonViewModel.Property property)
                : base (property, 4)
            {
            }

            protected override int LayoutId
            {
                get
                {
                    return Resource.Layout.EmailPropertyListItem;
                }
            }

            public override void OnClick (View v)
            {
                var intent = new Intent (Intent.ActionSend);
                intent.SetType ("message/rfc822");
                intent.PutExtra (Intent.ExtraEmail, new [] { Property.Value });
                v.Context.StartActivity (Intent.CreateChooser (intent, "Send email"));
            }
        }

        class UrlPropertyItem : PropertyItem {
            public UrlPropertyItem (PersonViewModel.Property property)
                : this (property, 5)
            {
            }

            protected UrlPropertyItem (PersonViewModel.Property property, int viewType)
                : base (property, viewType)
            {
            }

            protected override int LayoutId
            {
                get
                {
                    return Resource.Layout.UrlPropertyListItem;
                }
            }

            protected virtual Uri Url
            {
                get
                {
                    return new Uri (Property.Value.ToUpperInvariant ().StartsWith ("HTTP") ?
                                    Property.Value :
                                    "http://" + Property.Value);
                }
            }

            public override void OnClick (View v)
            {
                var intent = new Intent (Intent.ActionView, global::Android.Net.Uri.Parse (
                        Url.AbsoluteUri));
                v.Context.StartActivity (intent);
            }
        }

        class TwitterPropertyItem : UrlPropertyItem {
            public TwitterPropertyItem (PersonViewModel.Property property)
                : base (property, 6)
            {
            }

            protected override int LayoutId
            {
                get
                {
                    return Resource.Layout.TwitterPropertyListItem;
                }
            }

            protected override Uri Url
            {
                get
                {
                    var username = Property.Value.Trim ();
                    if (username.StartsWith ("@")) {
                        username = username.Substring (1);
                    }
                    return new Uri ("http://twitter.com/" + username);
                }
            }
        }

        #endregion
    }
}

