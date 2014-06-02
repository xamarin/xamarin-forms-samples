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
using System.ComponentModel;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory.Android {
    [Activity (Label = "Person")]
    public class PersonActivity : BaseListActivity {
        PersonViewModel viewModel;

        IMenuItem favoriteItem;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            //
            // Get the person object from the intent
            //
            Person person;
            if (Intent.HasExtra ("Person")) {
                var serializer = new System.Xml.Serialization.XmlSerializer (typeof (Person));
                var personBytes = Intent.GetByteArrayExtra ("Person");
                person = (Person)serializer.Deserialize (new MemoryStream (personBytes));
            } else {
                person = new Person ();
            }

            //
            // Load the View Model
            //
            viewModel = new PersonViewModel (person, Android.Application.SharedFavoritesRepository);
            viewModel.PropertyChanged += HandleViewModelPropertyChanged;

            //
            // Setup the UI
            //
            ListView.Divider = null;
            ListAdapter = new PersonAdapter (viewModel);

            Title = person.SafeDisplayName;
        }

        /// <summary>
        /// Creates the intent that can be used to present this activity given
        /// a specific Person object.
        /// </summary>
        /// <returns>
        /// The intent.
        /// </returns>
        /// <param name='person'>
        /// The Person to show in this activity.
        /// </param>
        public static Intent CreateIntent (Context context, Person person)
        {
            var intent = new Intent (context, typeof (PersonActivity));
            var serializer = new System.Xml.Serialization.XmlSerializer (typeof (Person));
            var personStream = new MemoryStream ();
            serializer.Serialize (personStream, person);
            intent.PutExtra ("Person", personStream.ToArray ());
            return intent;
        }

        void HandleViewModelPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFavorite") {
                UpdateFavoriteIcon ();
            }
        }

        void UpdateFavoriteIcon ()
        {
            if (favoriteItem != null) {
                favoriteItem.SetIcon (
                        viewModel.IsFavorite ?
                        Resource.Drawable.btn_rating_star_on_normal_holo_light :
                        Resource.Drawable.btn_rating_star_off_normal_holo_light);
            }
        }

        protected override void OnListItemClick (ListView l, View v, int position, long id)
        {
            ((PersonAdapter)ListAdapter).OnItemClick (position, v);
        }

        public override bool OnCreateOptionsMenu (IMenu menu)
        {
            MenuInflater.Inflate (Resource.Menu.PersonActivityOptionsMenu, menu);
            favoriteItem = menu.FindItem (Resource.Id.MenuFavorite);
            UpdateFavoriteIcon ();
            return true;
        }

        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            if (item.ItemId == Resource.Id.MenuFavorite) {
                viewModel.ToggleFavorite ();
                return true;
            } else {
                return base.OnOptionsItemSelected (item);
            }
        }
    }
}

