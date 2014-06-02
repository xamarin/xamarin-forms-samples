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
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using EmployeeDirectory.ViewModels;
using System.Windows.Data;

namespace EmployeeDirectory.WinPhone {
    public partial class SearchPage : PhoneApplicationPage {
        public SearchPage ()
        {
            InitializeComponent ();

            DataContext = new SearchViewModel (App.Current.DirectoryService, App.Current.SavedSearch) {
                SearchProperty = SearchProperty.All,
            };

            Loaded += HandleLoaded;
        }

        SearchViewModel ViewModel { get { return (SearchViewModel)DataContext; } }

        bool IsValidSearchText
        {
            get
            {
                return !string.IsNullOrWhiteSpace (SearchText.Text);
            }
        }

        void HandleLoaded (object sender, RoutedEventArgs e)
        {
            SearchText.Focus ();
            SearchText.Select (SearchText.Text.Length, 0);
        }

        void HandleSearchTextKeyDown (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                HandleSearch (sender, new RoutedEventArgs ());
                SearchResults.Focus ();
            }
        }

        void HandleSearch (object sender, RoutedEventArgs e)
        {
            if (IsValidSearchText) {
                ViewModel.Search ();
            }
        }

        void OnSearchTextChanged (object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Update the binding source
            BindingExpression bindingExpr = textBox.GetBindingExpression (TextBox.TextProperty);
            bindingExpr.UpdateSource ();
        }
    }
}