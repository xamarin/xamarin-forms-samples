TodoAzureAuth
=============

This sample demonstrates a Todo list application where the data is stored, accessed, and authenticated from an Azure Mobile App instance.

The app functionality is:

- View a list of tasks.
- Add a new item to the list of tasks.
- Set a task's status to 'completed'.

In all cases the tasks are stored in an Azure Mobile App instance.

For more information about this sample see [Consuming an Azure Mobile App](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/azure/) and [Authenticating Users with Azure Mobile Apps](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/authentication/azure/).

Setting up an Azure Mobile App
----------------------------------

In order to run this sample application an Azure Mobile App must first be created. When creating an Azure Mobile App instance please ensure that the service uses a Node.js backend.

For information about how to Create an Azure Mobile App that can be consumed by Xamarin.Forms, see [Create a Xamarin.Forms app](https://azure.microsoft.com/en-gb/documentation/articles/app-service-mobile-xamarin-forms-get-started/) on the Azure website.

For information about how to configure the Azure Mobile App instance to manage the authentication process, see [Add authentication to your Xamarin.Forms app](https://azure.microsoft.com/en-gb/documentation/articles/app-service-mobile-xamarin-forms-get-started-users/) on the Azure website.

Please ensure that the Azure Mobile App authentication options specifies a URL scheme.

Sample Setup
----------------

In order to run this sample application the following steps must be carried out:

1. Update Constants.cs, in the PCL project, to include the URL of the Azure Mobile App, and the URL scheme for the Xamarin.Forms app.
1. In the iOS project, update Info.plist to include the URL scheme.
1. In the Android project, update AndroidManifest.xml to include the URL scheme.
1. In the UWP project, update Package.appxmanifest to include the URL scheme.

Author
------

David Britch
