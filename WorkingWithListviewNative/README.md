Working with ListView Native
==============

Although the Xamarin.Forms `ListView` control provides a lot of flexibility, for very complex row layouts (or very large data-sets) the performance can sometimes be affected.

This example has three different screens:

* Using the Xamarin.Forms built-in cell types, which are faster than a custom Xamarin.Forms layout.
* Using a custom renderer (UITableView, Android ListView) with native platform built-in cells.
* Using a custom renderer (UITableView, Android ListView) with custom cell layouts built for the native platform (in C# code for iOS, using XML layout for Android). *This is shown in the screenshot below*:

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/WorkingWithListviewNative/Screenshots/all-sml.png "Performance")

*(Xaml examples still-to-come)*


Author
------

Craig Dunn
