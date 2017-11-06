TodoAzureAuthADB2CClientFlow
============================

This sample demonstrates how to use Azure Active Directory B2C to provide a client-side authentication and authorization flow to an Azure Mobile Apps instance with Xamarin.Forms.

For more information about this sample see [Integrating Azure Active Directory B2C with Azure Mobile Apps](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/authentication/azure-ad-b2c-mobile-app/).

Setup
-----

In order to run this sample application an Azure Mobile Apps instance must be created and configured, along with a Azure Active Directory B2C tenant, as follows:

1. Create an Azure Mobile App instance. For more information, see [Consuming an Azure Mobile App](https://developer.xamarin.com/guides/xamarin-forms/web-services/consuming/azure/).
1. Enable authentication in the Azure Mobile App instance and the Xamarin.Forms application. For more information, see [Authenticating Users with Azure Mobile Apps](https://developer.xamarin.com/guides/xamarin-forms/web-services/authentication/azure/).
1. Create an Azure Active Directory B2C tenant. For more information, see [Authenticating Users with Azure Active Directory B2C](https://developer.xamarin.com/guides/xamarin-forms/web-services/authentication/azure-ad-b2c/).

Sample Setup
----------------

In order to run this sample application the following steps must be carried out:

1. Update Constants.cs, in the PCL project.
1. In the iOS project, update Info.plist to include the URL scheme.
1. In the Android project, update AndroidManifest.xml to include the URL scheme.

Author
------

David Britch
