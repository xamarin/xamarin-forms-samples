TodoREST
========

This sample demonstrates a Todo list application where the data is stored and accessed from a RESTful web service. The web service is hosted by Xamarin and provides read-only access to the data. Therefore, the operations that create, update, and delete data will not alter the data consumed in the application. However, a hostable version of the REST service that provides read-write access to the data is stored in the *TodoRESTService* folder.

The app functionality is:

- View a list of tasks.
- Add, edit, and delete tasks.
- Set a task's status to 'done'.
- Speak the task's name and notes fields.

In all cases the tasks are stored in an in-memory collection that's accessed through a RESTful web service.

For more information about the sample see [Consuming a RESTful Web Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/rest/) and [Authenticating a RESTful Web Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/authentication/rest/).

Author
------

David Britch
