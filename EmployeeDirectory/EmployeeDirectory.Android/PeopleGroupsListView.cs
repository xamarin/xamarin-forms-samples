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

using Android.Content;
using Android.Util;
using Android.Widget;

namespace EmployeeDirectory.Android {
    public class PeopleGroupsListView : ListView {
        public ScrollState ScrollState { get; private set; }

        public PeopleGroupsListView (Context context, IAttributeSet attrs) :
            base (context, attrs)
        {
            Initialize ();
        }

        public PeopleGroupsListView (Context context, IAttributeSet attrs, int defStyle) :
            base (context, attrs, defStyle)
        {
            Initialize ();
        }

        void Initialize ()
        {
            ScrollState = ScrollState.Idle;
            ScrollStateChanged += HandleScrollStateChanged;
            FastScrollEnabled = true;
        }

        void HandleScrollStateChanged (object sender, ScrollStateChangedEventArgs e)
        {
            ScrollState = e.ScrollState;

            if (e.ScrollState == ScrollState.Idle) {
                ((PeopleGroupsAdapter)Adapter).LoadImagesForOnscreenRows (this);
            }
        }
    }
}

