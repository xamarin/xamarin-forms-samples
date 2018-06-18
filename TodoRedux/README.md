# TodoRedux

This is a sample Xamarin app demonstrating how to use Redux.NET Middleware with a LiteDb database to store and restore state.

This is the supporting code for the blog series on Advanced Xamarin in Redux, available here:

* [Advanced Redux in Xamarin Part 1: Action Creators](http://phdesign.com.au/programming/advanced-redux-in-xamarin-part1-action-creators/)
* [Advanced Redux in Xamarin Part 2: Persistent Actions Middleware](http://phdesign.com.au/programming/advanced-redux-in-xamarin-part2-persistent-actions-middleware/)
* [Advanced Redux in Xamarin Part 3: Database Middleware](http://phdesign.com.au/programming/advanced-redux-in-xamarin-part3-database-middleware/)

This sample was written in Visual Studio for Mac, it seems to work in Visual Studio 2017 for PC, but there's still some differences in the tooling support for .NET Standard and csproj-based NuGet dependencies.

## ActionCreators

The ActionCreators in this project are very basic, they just create and return a single Action, but they lay the foundations for doing async (e.g. API) calls as discussed in the [first blog post](Advanced Redux in Xamarin Part 1: Action Creators).

## Middleware

The `DatabaseMiddleware` class demonstrates how to intercept Actions to store the current application state in a local database, then reload that state on application startup. See the [third blog post](http://phdesign.com.au/programming/advanced-redux-in-xamarin-part3-database-middleware/) for more on this.

## MVVM

This sample uses a very vanilla implementation of the MVVM pattern, simply newing up the ViewModel in the Page constructor and using Fody.PropertyChanged to automatically wire up the INotifyPropertyChanged events.