TodoRESTService
===============

This sample provides a hostable REST service that can be consumed by the TodoREST sample.

The REST service provides the following operations:

- GET: gets a list of todo items - /api/todoitems/
- POST: creates a new todo item - /api/todoitems/{id}
- PUT: updates a todo item - /api/todoitems/{id}
- DELETE: deletes a todo item - /api/todoitems/{id}

For more information about the sample see [Consuming a RESTful Web Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/rest/) and [Authenticating a RESTful Web Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/authentication/rest/).

Setting up the REST service
---------------------------

The accompanying Xamarin.Forms sample application consumes a Xamarin-hosted REST service that provides read-only access to the web service. Therefore, the operations that create, update, and delete data will not alter the data consumed in the application. However, this version of the REST service provides read-write access to the data and can be hosted as an Azure Web App with the following steps:

1. [Sign up](https://account.windowsazure.com/signup) for an Azure account.
1. In *Visual Studio*, open the *TodoRESTService* solution that is stored in the *TodoRESTService* folder in the accompanying sample application download.
1. In *Solution Explorer*, right-click the *TodoRESTService project* and select *Publish...*.
1. In the *Publish Web* dialog select *Microsoft Azure Web Apps* and the *Select Existing Web App* dialog appears.
1. In the *Select Existing Web App* dialog, click the *Sign In...* button to sign into your Azure account. Enter your credentials when prompted.
1. In the *Select Existing Web App* dialog, click the *New...* button to create a new Azure Web App.
1. In the *Create Web App on Microsoft Azure* dialog, enter a unique *Web App name*. Azure will use this name as the prefix for the application's URL.
1. In the *Create Web App on Microsoft Azure* dialog, in the *App Service plan* drop-down, select *Create new App Service plan* and enter *MyExamplePlan* for the plan name.
1. In the *Create Web App on Microsoft Azure* dialog, in the *Resource group* drop-down, select *Create new resource group* and enter *MyExampleResourceGroup* for the resource group name.
1. In the *Create Web App on Microsoft Azure* dialog, in the *Region* drop-down, select the location that is closest to you.
1. In the *Create Web App on Microsoft Azure* dialog, ensure that the *Database server* drop-down is set to *No database*.
1. In the *Create Web App on Microsoft Azure* dialog, click the *Create* button to create the web app in the specified Azure region.
1. In the *Publish Web* dialog, click the *Publish* button to publish the REST service to the web app created in the previous step.
1. In *Xamarin Studio* or *Visual Studio*, load the *TodoREST solution*, expand the *TodoREST* project and update the `Constants.RestUrl` property to the address of the web app created in the previous steps.

For more information about publishing to an Azure Web App, see [Creating an ASP.NET web app in Azure App Service](https://azure.microsoft.com/en-gb/documentation/articles/web-sites-dotnet-get-started/#create-an-aspnet-web-application).

Author
------

David Britch
