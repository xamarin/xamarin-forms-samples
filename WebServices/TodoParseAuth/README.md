TodoParseAuth
=============

This sample demonstrates a Todo list application where the data is stored, accessed, and authenticated from a Parse web service.

The app functionality is:

- View a list of tasks.
- Add, edit, and delete tasks.
- Set a task's status to 'done'.
- Speak the task's name and notes fields.

In all cases the tasks are stored and accessed through a Parse web service.

For more information about this sample see [Consuming a Parse Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/parse/) and [Authenticating Users with a Parse Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/authentication/parse/).

Setting up a Parse service
--------------------------

In order to run this sample application a Parse service must first be created. This can be accomplished with the following steps:

1. In a web browser, [Sign up](https://parse.com/signup) for a Parse account.
1. In the [Parse quickstart](https://www.parse.com/apps/quickstart), select the *Data* product, the *Mobile* environment, the *iOS* platform, the *Xamarin (C#)* language, and the *Existing project* type.
1. In the [Parse dashboard](https://www.parse.com/apps), select the app name that was created during signup for a Parse account, and then navigate to *Settings* > *Keys*.
1. In the *Parse dashboard*, copy the *Application ID* value to the clipboard.
1. In *Xamarin Studio* or *Visual Studio*, load the *TodoParseAuth* solution, expand the *TodoParse* project and paste the clipboard value into the `Constants.ApplicationId` property.
1. In the *Parse dashboard*, copy the *.NET Key* value to the clipboard.
1. In *Xamarin Studio* or *Visual Studio*, in the *TodoParse* project, paste the clipboard value into the `Constants.Key` property.

Author
------

David Britch
