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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using EmployeeDirectory.Data;
using EmployeeDirectory.Utilities;
using EmployeeDirectory.ViewModels;
using Android.Runtime;

namespace EmployeeDirectory.Android {
    public class PeopleGroupsAdapter : BaseAdapter, ISectionIndexer {
        readonly ImageDownloader imageDownloader = new AndroidImageDownloader ();

        ICollection<PeopleGroup> itemsSource = new ObservableCollection<PeopleGroup> ();

        List<Java.Lang.Object> items = new List<Java.Lang.Object> ();
        List<string> sections = new List<string> ();
        Dictionary<int, string> alphaIndexer = new Dictionary<int, string> ();

        public ICollection<PeopleGroup> ItemsSource
        {
            get
            {
                return itemsSource;
            }
            set
            {
                if (itemsSource != value && value != null) {
                    itemsSource = value;
                    int i = 0;
                    items.Clear ();
                    foreach (var g in itemsSource) {
                        items.Add (new GroupHeaderItem (g));
                        sections.Add (g.Title);
                        alphaIndexer [i] = g.Title;
                        var lastPerson = g.People.LastOrDefault ();
                        foreach (var p in g.People) {
                            items.Add (new PersonItem (p, p == lastPerson));
                        }
                        i++;
                    }

                    this.NotifyDataSetChanged ();
                }
            }
        }

        public override int ViewTypeCount
        {
            get
            {
                return 2;
            }
        }

        public override int GetItemViewType (int position)
        {
            return items [position] is GroupHeaderItem ? 0 : 1;
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return items [position];
        }

        public Person GetPerson (int position)
        {
            Person person = null;
            if (0 <= position && position < items.Count) {
                var personItem = items [position] as PersonItem;
                if (personItem != null) {
                    person = personItem.Person;
                }
            }
            return person;
        }

        public override long GetItemId (int position)
        {
            return 0;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            var layoutInflater = ((Activity)parent.Context).LayoutInflater;

            var item = items [position];
            var personItem = item as PersonItem;

            if (personItem != null) {

                var person = personItem.Person;

                var v = convertView;
                if (v == null) {
                    v = layoutInflater.Inflate (Resource.Layout.PersonListItem, null);
                }

                var nameTextView = v.FindViewById<TextView> (Resource.Id.NameTextView);
                var detailsTextView = v.FindViewById<TextView> (Resource.Id.DetailsTextView);
                var imageButton = v.FindViewById<ImageButton> (Resource.Id.ImageButton);
                var divider = v.FindViewById<View> (Resource.Id.Divider);

                nameTextView.Text = person.SafeDisplayName;
                detailsTextView.Text = person.TitleAndDepartment;
                divider.Visibility = personItem.IsLastPersonInGroup ?
                                ViewStates.Invisible :
                                ViewStates.Visible;

                if (images.ContainsKey (person.Id)) {
                    imageButton.SetImageBitmap (images [person.Id]);
                } else {
                    var listView = (PeopleGroupsListView)parent;
                    if (person.HasEmail && listView.ScrollState == ScrollState.Idle) {
                        StartImageDownload (listView, position, person);
                    } else {
                        imageButton.SetImageResource (Resource.Drawable.Placeholder);
                    }
                }

                return v;
            } else {
                var v = convertView;
                if (v == null) {
                    v = layoutInflater.Inflate (Resource.Layout.GroupHeaderListItem, null);
                }
                var headerTextView = v.FindViewById<TextView> (Resource.Id.HeaderTextView);

                headerTextView.Text = ((GroupHeaderItem)item).Group.Title;

                return v;
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public int GetPositionForSection (int section)
        {
            var character = sections [section];
            var position = alphaIndexer.FirstOrDefault (f => f.Value == character);
            return position.Key;
        }

        public int GetSectionForPosition (int position)
        {
            return 1;
        }

		public Java.Lang.Object [] GetSections ()
		{
			var array = sections.Select(s => new Java.Lang.String(s)).ToArray();
			return (Java.Lang.Object [])array;
		}

        #region Image Support

        readonly Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap> ();
        readonly List<string> imageDownloadsInProgress = new List<string> ();

        public void LoadImagesForOnscreenRows (ListView listView)
        {
            for (var position = listView.FirstVisiblePosition; position <= listView.LastVisiblePosition; position++) {
                var personItem = items [position] as PersonItem;
                if (personItem != null) {
                    var person = personItem.Person;
                    if (person.HasEmail && !images.ContainsKey (person.Id)) {
                        StartImageDownload (listView, position, person);
                    }
                }
            }
        }

        void StartImageDownload (ListView listView, int position, Person person)
        {
            if (imageDownloadsInProgress.Contains (person.Id))
                return;

            var url = Gravatar.GetImageUrl (person.Email, 100);

            if (imageDownloader.HasLocallyCachedCopy (url)) {

                var image = imageDownloader.GetImage (url);
                FinishImageDownload (listView, position, person, (Bitmap)image);

            } else {
                imageDownloadsInProgress.Add (person.Id);

                imageDownloader.GetImageAsync (url).ContinueWith (t => {
                    if (!t.IsFaulted) {
                        FinishImageDownload (listView, position, person, (Bitmap)t.Result);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext ());
            }
        }

        void FinishImageDownload (ListView listView, int position, Person person, Bitmap image)
        {
            images [person.Id] = image;
            imageDownloadsInProgress.Remove (person.Id);

            var personItem = (position < items.Count) ?
                            items [position] as PersonItem :
                            null;

            if (personItem != null && personItem.Person == person) {

                var firstPostion = listView.FirstVisiblePosition - listView.HeaderViewsCount;
                var childIndex = position - firstPostion;

                if (0 <= childIndex && childIndex < listView.ChildCount) {
                    var view = listView.GetChildAt (childIndex);
                    var imageButton = view.FindViewById<ImageButton> (Resource.Id.ImageButton);
                    imageButton.SetImageBitmap (image);
                }
            }
        }

        #endregion

        class GroupHeaderItem : Java.Lang.Object {
            public PeopleGroup Group { get; private set; }

            public GroupHeaderItem (PeopleGroup group)
            {
                Group = group;
            }

            public override string ToString ()
            {
                return Group.Title;
            }
        }

        class PersonItem : Java.Lang.Object {
            public Person Person { get; private set; }
            public bool IsLastPersonInGroup { get; private set; }

            public PersonItem (Person person, bool isLastPersonInGroup)
            {
                Person = person;
                IsLastPersonInGroup = isLastPersonInGroup;
            }

            public override string ToString ()
            {
                return Person.SafeDisplayName;
            }
        }
    }
}

