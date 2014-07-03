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
using System.IO;
using Android.App;
using Android.Runtime;
using EmployeeDirectory.Data;

namespace EmployeeDirectory.Android {
    [Application (Label = "Employees", Theme = "@style/CustomHoloTheme", Icon="@drawable/Icon")]
    public class Application : global::Android.App.Application {
        private static IFavoritesRepository repo;

        public Application (IntPtr javaReference, JniHandleOwnership transfer)
            :base(javaReference, transfer)
        {

        }

        public override void OnCreate ()
        {
            base.OnCreate ();

            using (var reader = new System.IO.StreamReader (Assets.Open ("XamarinDirectory.csv"))) {
                Service = new MemoryDirectoryService (new CsvReader<Person> (reader).ReadAll ());
            }

            var filePath = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), "XamarinFavorites.xml");
            using (var stream = Assets.Open ("XamarinFavorites.xml")) {
                using (var filestream = File.Open (filePath, FileMode.Create)) {
                    stream.CopyTo (filestream);
                }
            }
            repo = XmlFavoritesRepository.OpenFile (filePath);
        }

        public static IDirectoryService Service
        {
            get;
            set;
        }
        
        /// <summary>
        /// last time the device was used.
        /// </summary>
        public static DateTime LastUseTime { get; set; }

        public static IFavoritesRepository SharedFavoritesRepository
        {
            get { return repo; }
        }
    }
}