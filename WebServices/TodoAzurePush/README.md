TodoAzurePush
=============

This sample demonstrates how to use Azure Notification Hubs to send push notifications from an Azure Mobile Apps instance to a Xamarin.Forms application.

The app functionality is:

- View a list of tasks.
- Add a new item to the list of tasks.
- Set a task's status to 'completed'.

In all cases the tasks are stored in an Azure Mobile Apps instance.

Before you can use this sample, you must download **google-services.json** from the [Firebase Console](https://console.firebase.google.com/) and add it to the Android project, replacing the dummy **google-services.json** file that's provided with this sample.

For more information about this sample see [Sending Push Notifications from Azure Mobile Apps](http://developer.xamarin.com/guides/xamarin-forms/web-services/push-notifications/).

Setting up an Azure Mobile App
------------------------------

In order to run this sample application an Azure Mobile App must first be created. When creating an Azure Mobile Apps instance please ensure that the service uses a Node.js backend.

For information about how to Create an Azure Mobile App that can be consumed by Xamarin.Forms, see [Consuming an Azure Mobile App](http://developer.xamarin.com/guides/xamarin-forms/web-services/consuming/azure/).

Author
------

David Britch
