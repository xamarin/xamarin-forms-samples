Employee Directory
==========

This contacts application is Xamarin.Forms port of the [existing pre-build app](http://xamarin.com/prebuilt/employeedirectory). 
With Xamarin.Forms you can use C# or XAML to create layout and this sample app shows how to use both of them. To switch between user interface implementations open  ~/EmployeeDirectory/EmployeeDirectoryUI/App.cs file and change `uiImplementation` variable. 

Switch to XAML:

    public static class App
    {
        //Change the following line to switch between XAML and C# versions
        private UIImplementation uiImplementation = UIImplementation.Xaml;
        ...
    }
    
Switch to C#:

    public static class App
    {
        //Change the following line to switch between XAML and C# versions
        private UIImplementation uiImplementation = UIImplementation.CSharp;
        ...
    }

Nugets used in this solution: [PCLStorage](http://www.nuget.org/packages/PCLStorage/0.9.3), [Xamarin.Forms]("http://xamarin.com/forms"), [Microsoft.Bcl]("https://www.nuget.org/packages/Microsoft.Bcl/1.1.8"), [Microsoft.Bcl.Build]("http://www.nuget.org/packages/Microsoft.Bcl.Build/1.0.14"), [Microsoft.Net.Http]("https://www.nuget.org/packages/Microsoft.Net.Http/2.2.22") 

Components used in this solution: [Xamarin.Social]("http://components.xamarin.com/view/xamarin.social")

Authors
---------
Oleg Demchenko