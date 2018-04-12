AzureADB2CAuth
==============

This sample demonstrates how to use Microsoft Authentication Library and Azure Active Directory B2C to integrate consumer identity management into a mobile application.

For more information about this sample see [Authenticating Users with Azure Active Directory B2C](http://developer.xamarin.com/guides/xamarin-forms/web-services/authentication/azure-ad-b2c/).

Setting up an Azure Active Directory B2C Tenant
-----------------------------------------------

In order to run this sample application an Azure Active Directory B2C tenant must be created and configured, as follows:

1. Create an Azure Active Directory B2C tenant. For more information, see [Create an Azure AD B2C tenant](https://azure.microsoft.com/en-us/documentation/articles/active-directory-b2c-get-started/) on the Azure documentation center.
1. Register your mobile application with the Azure Active Directory B2C tenant. The registration process assigns an **Application ID** that uniquely identifies your application, and a **Redirect URL** that can be used to direct responses back to your application. For more information, see [Register your application](https://azure.microsoft.com/en-us/documentation/articles/active-directory-b2c-app-registration/) on the Azure documentation center.
1. Create a sign-up and sign-in policy. This policy will define the experiences that consumers will go through during sign-up and sign-in, and the contents of tokens the application will receive on successful sign-up or sign-in. For more information, see [Extensible policy framework](https://azure.microsoft.com/en-us/documentation/articles/active-directory-b2c-reference-policies/#how-to-create-a-sign-up-policy) on the Azure documentation center.


Author
------

David Britch
