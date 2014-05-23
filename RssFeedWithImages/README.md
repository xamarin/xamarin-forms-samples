RssFeedWithImages
=================

RssFeedWithImages access a NASA RSS feed that contains thumbnail images, and displays
the collection of items in a ListView. Selecting an item navigates to a new page 
displaying a web page for that item.

**If you open the solution in Xamarin Studio, it will not be able to load the Windows Phone project;
and if you open the solution in Xamarin Studio under Windows, it will not be able to load the iOS project either.**

The solution contains four projects: the iOS, Android, and Windows Phone projects are small and standard
Xamarin.Forms stub applications. All the common application code is in the RssFeedWithImages portable class library.
Most of the RSS-specific code is in two data models named RssFeed and RssItem. Properties in these classes
are bound to properties of items in the RssFeedPage and RssItemPage XAML files.

**As of 5/23/14 and Build 1.0.6186, the Windows Phone version does not work
due to the binding on ImageSource in ImageCell in RssFeedPage.xaml.** 

Author
------

Charles Petzold
