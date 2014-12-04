Working with ListView Performance
==============

This sample relate to the [Working with ListView Performance in Xamarin.Forms](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview-performance) doc.

Although the Xamarin.Forms `ListView` control provides a lot of flexibility, for very complex row layouts (or very large data-sets) the performance sometimes does not live up to expectations.

This example has three different screens:

* Using the Xamarin.Forms built-in cell types, which are faster than a custom Xamarin.Forms layout.
* Using a custom renderer (UITableView, Android ListView) with native platform built-in cells.
* Using a custom renderer (UITableView, Android ListView) with custom cell layouts built for the native platform (in C# code for iOS, using XML layout for Android). This is shown in the screenshot below:

(Xaml examples still-to-come)


![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/WorkingWithListviewPerf/Screenshots/all-sml.png "Performance")


Author
------

Craig Dunn
