TodoAzure
=========

This sample demonstrates a Todo list application where the data is stored and accessed from an Azure Mobile Service instance.

The app functionality is:

- View a list of tasks.
- Add, edit, and delete tasks.
- Set a task's status to 'done'.
- Speak the task's name and notes fields.

In all cases the tasks are stored in an Azure Mobile Services instance.

For more information about the sample see [Consuming an Azure Mobile Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/azure/).

Setting up an Azure Mobile Service
----------------------------------

In order to run this sample application an Azure Mobile Service must first be created. When creating an Azure Mobile Service instance please ensure that the service uses a JavaScript back-end, as shown in the following screenshot:

![](//developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/azure/Images/backend.png)

Creating an Azure Mobile Service can be accomplished with the following steps:

1. In a web browser, [sign up](https://account.windowsazure.com/signup) for an Azure account.
1. In the [Azure Management Portal](https://manage.windowsazure.com), create a new mobile service. For more information about creating a mobile service, see [Create a mobile service](https://azure.microsoft.com/en-gb/documentation/articles/partner-xamarin-mobile-services-ios-get-started/#create-new-service) on the Azure website.
1. In the [Azure Management Portal](https://manage.windowsazure.com), click *Mobile Services*, and then click the mobile service created in the previous step.
1. In the *Quickstart* tab, click *Xamarin.iOS* under *Choose platform* and expand *Connect an existing Xamarin app*.
1. In the *Quickstart* tab, under *Connect your app* copy the first parameter to the `MobileServiceClient` constructor to the clipboard. This parameter represents the address of the mobile service instance.
1. In *Xamarin Studio* or *Visual Studio*, load the *TodoAzure* solution, expand the *TodoAzure* project and paste the clipboard value into the `Constants.ApplicationURL` property.
1. In the *Azure Management Portal*, in the *Quickstart* tab, under *Connect your app* copy the second parameter to the `MobileServiceClient` constructor to the clipboard. This parameter represents the application key for the mobile service.
1. In *Xamarin Studio* or *Visual Studio*, in the *TodoAzure* project, paste the clipboard value into the `Constants.ApplicationKey` property.
1. In the *Azure Management Portal*, click the *Data* tab followed by the *Create* button, name the new table *TodoItem*, and accept the default table creation options. The table will contain an ID column, which is used to uniquely identify a row of data. This column must be present in order to perform query, insert, update, and delete operations.

Author
------

David Britch
