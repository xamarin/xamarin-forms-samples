Todo (Xamarin.Forms)
=======

Xamarin.Forms provides two solution templates for building cross-platform applications: PCL or Shared Project. This **Todo** sample application is provided using both templates. The Xamarin.Forms application code is fundamentally the same, except where the database connection is created (because it requires a file-system reference to the SQLite data file).

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/Todo/Screenshots/Todo-list-sml.png "ListView")

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/Todo/Screenshots/Todo-detail-sml.png "Detail View")

**NOTE:** Windows Phone requires you to download <a href="http://www.sqlite.org/download.html#wp8" target="_blank">Precompiled Binaries for Windows Phone 8 VSIX</a> and install in Visual Studio; this enables the **SQLite for Windows Phone** Extension that you can then add to your app.

PCL (Portable Class Library)
---
This solution uses the [SQLite.NET PCL](https://www.nuget.org/packages/SQLite.Net-PCL/) NuGet to provide a cross-platform implementation of the SQLite database API. The shared PCL project references the NuGet to implement the `TaskDatabase` class. Platform-specific instances of the `SQLiteConnection` are created and injected on each platform (in `AppDelegate`, `MainActivity`, and `MainPage`). 


Shared Project
--------------
This version uses the raw C# source of [SQLite.NET](https://github.com/praeclarum/sqlite-net/) in the **Shared Project**, which is accessed by the `TaskDatabase` class. There is a compiler-directive (`#if __IOS__`) in the `TaskDatabase` class that is used to determine the correct filename for each platform.



Authors
-------

Craig Dunn, Bryan Costanich
