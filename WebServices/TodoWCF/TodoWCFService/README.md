TodoWCFService
==============

This sample provides a hostable WCF service that can be consumed by the TodoWCF sample.

The WCF service, available at ~/TodoService.svc provides the following operations:

- GetTodoItems - gets a list of todo items
- CreateTodoItem - creates a new todo item
- EditTodoItem - updates a todo item
- DeleteTodoItem - deletes a todo item

For more information about the sample see [Consuming a Windows Communication Foundation (WCF) Web Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/wcf/).

Setting up the WCF service
---------------------------

The accompanying Xamarin.Forms sample application consumes a Xamarin-hosted WCF service that provides read-only access to the web service. Therefore, the operations that create, update, and delete data will not alter the data consumed in the application. However, this version of the WCF service provides read-write access to the data and can be hosted as an Azure Web App with the following steps:

1. [Sign up](https://account.windowsazure.com/signup) for an Azure account.
1. In *Visual Studio*, open the *TodoWCFService* solution that is stored in the *TodoWCFService* folder in the accompanying sample application download.
1. In *Solution Explorer*, right-click the *TodoWCFService project* and select *Publish...*.
1. In the *Publish Web* dialog select *Microsoft Azure Web Apps* and the *Select Existing Web App* dialog appears.
1. In the *Select Existing Web App* dialog, click the *Sign In...* button to sign into your Azure account. Enter your credentials when prompted.
1. In the *Select Existing Web App* dialog, click the *New...* button to create a new Azure Web App.
1. In the *Create Web App on Microsoft Azure* dialog, enter a unique *Web App name*. Azure will use this name as the prefix for the application's URL.
1. In the *Create Web App on Microsoft Azure* dialog, in the *App Service plan* drop-down, select *Create new App Service plan* and enter *MyExamplePlan* for the plan name.
1. In the *Create Web App on Microsoft Azure* dialog, in the *Resource group* drop-down, select *Create new resource group* and enter *MyExampleResourceGroup* for the resource group name.
1. In the *Create Web App on Microsoft Azure* dialog, in the *Region* drop-down, select the location that is closest to you.
1. In the *Create Web App on Microsoft Azure* dialog, ensure that the *Database server* drop-down is set to *No database*.
1. In the *Create Web App on Microsoft Azure* dialog, click the *Create* button to create the web app in the specified Azure region.
1. In the *Publish Web* dialog, click the *Publish* button to publish the WCF service to the web app created in the previous step.
1. In *Xamarin Studio* or *Visual Studio*, load the *TodoWCF solution*, expand the *TodoWCF* project and update the `Constants.SoapUrl` property to the address of the web app created in the previous steps.

For more information about publishing to an Azure Web App, see [Creating an ASP.NET web app in Azure App Service](https://azure.microsoft.com/en-gb/documentation/articles/web-sites-dotnet-get-started/#create-an-aspnet-web-application).

Author
------

David Britch
