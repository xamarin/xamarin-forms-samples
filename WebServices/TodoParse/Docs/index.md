id:fb87d389-aed1-4156-ad28-83e4c84a2f86
title:Consuming a Parse Service
subtitle:Using the Parse .NET SDK in a Xamarin.Forms application
brief:Parse provides backend solutions for mobile applications, eliminating the need for writing server code and maintaining servers. This article demonstrates how to consume a Parse web service from a Xamarin.Forms application.
samplecode:[TodoParse](/samples/xamarin-forms/WebServices/TodoParse/)
article:[Parse .NET and Xamarin Guide](https://parse.com/docs/dotnet/guide)
api:[Parse .NET SDK API Reference](http://parse.com/docs/dotnet/api/Index.html)
sdk:[Parse .NET SDK](https://www.nuget.org/packages/parse)
dateupdated:2016-09-20

<div class="note"><p>The Parse hosted service will be retired in early 2017. For information about migrating an app, see <a href="http://parse.com/migration">Parse Migration Guide</a> on the Parse website. For information about deploying a Parse Server to Azure, see <a href="https://azure.microsoft.com/en-us/marketplace/partners/microsoft/parseserver/">Parse Server on Managed Azure Services</a> on the Azure website.</p></div>

Access to a Parse service is through the [Parse .NET SDK](https://www.nuget.org/packages/parse), and all connections to Parse are made over HTTPS with Parse rejecting non-HTTPS connections.

Instructions on setting up a Parse service can be found in the readme file that accompanies the sample application. When the sample application is run it will connect to a Parse service, as shown in the following screenshot:

![](Images/portal.png "Sample Application")

<div class="note"><p>In iOS 9 and greater, App Transport Security (ATS) enforces secure connections between internet resources (such as the app's back-end server) and the app, thereby preventing accidental disclosure of sensitive information. Since ATS is enabled by default in apps built for iOS 9, all connections will be subject to ATS security requirements. If connections do not meet these requirements, they will fail with an exception.</p>
<p>ATS can be opted out of if it is not possible to use the <code>HTTPS</code> protocol and secure communication for internet resources. This can be achieved by updating the app's <b>Info.plist</b> file. For more information see <a href="/guides/ios/platform_features/introduction_to_ios9/ats/">App Transport Security</a>.</p></div>

# Consuming a Parse Service

Xamarin.Forms applications identify themselves to Parse with an application ID and a .NET key, which are created when a new Parse backend application is created. The following code example shows how the sample application creates a connection to Parse:

```
protected ParseStorage ()
{
  ...
  ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
}
```

The `ParseClient.Initialize` method is used to authenticate the sample application with the Parse backend application, and must be called before the sample application can use any Parse services.

## Creating ParseObjects

The `ParseObject` class is used to store data on Parse. Each `ParseObject` contains key-value pairs of JSON-compatible data. The data does not use a schema, so it is not necessary to specify in advance the keys that exist on each `ParseObject`.

The sample application uses the `TodoItem` class to model data. In order to store a `TodoItem` instance on Parse, it must first be converted to a `ParseObject` instance. This is accomplished by the `ToParseObject` method, as shown in the following code example:

```
ParseObject ToParseObject (TodoItem todo)
{
  var po = new ParseObject ("TodoItem");
  if (todo.ID != string.Empty) {
    po.ObjectId = todo.ID;
  }
  po ["Title"] = todo.Name;
  po ["Description"] = todo.Notes;
  po ["IsDone"] = todo.Done;

  return po;
}
```

This method creates a new `ParseObject`, giving it a class name of "TodoItem." It then sets the `ObjectID` property of the `ParseObject` instance. The combination of a class name and an `ObjectID` uniquely identifies a `ParseObject`. Finally, the `ParseObject` instance is set with the rest of the data from the `TodoItem` instance.

Similarly, when data is retrieved from Parse, it must be converted from a `ParseObject` instance to a `TodoItem` instance. This is accomplished with the `FromParseObject` method, as shown in the following code example:

```
static TodoItem FromParseObject (ParseObject po)
{
  var t = new TodoItem ();
  t.ID = po.ObjectId;
  t.Name = Convert.ToString (po ["Title"]);
  t.Notes = Convert.ToString (po ["Description"]);
  t.Done = Convert.ToBoolean (po ["IsDone"]);
  return t;
}
```

This method simply retrieves the data from the `ParseObject` instance and sets it in the newly created `TodoItem` instance.

For more information about the `ParseObject` class, see [The Parse Object](https://parse.com/docs/dotnet/guide#objects-the-parseobject) on Parse's website.

## Retrieving Data

The `ParseQuery.FindAsync` method is used to retrieve data from Parse, as shown in the following code example:

```
async public Task<List<TodoItem>> RefreshDataAsync ()
{
  var query = ParseObject.GetQuery("TodoItem");
  var results = await query.FindAsync ();

  var Items = new List<TodoItem> ();
  foreach (var item in results) {
    Items.Add (FromParseObject (item));
  }

  return Items;
}
```

A `ParseQuery` instance is created that will retrieve any `ParseObject` instances that have a class name of "TodoItem". An `IEnumerable` collection of matching `ParseObject` instances is then retrieved from Parse using the `FindAsync` method. The `ParseObject` collection is then converted to a `List` of `TodoItem` instances for display.

For more information about Parse queries, see [Queries](https://parse.com/docs/dotnet/guide#queries) on Parse's website.

## Creating and Updating Data

The `ParseObject.SaveAsync` method is used to save data to Parse, as shown in the following code example:

```
public async Task SaveTodoItemAsync (TodoItem todoItem)
{
  ...
  await ToParseObject (todoItem).SaveAsync ();
  ...
}
```

When using the `SaveAsync` method to update existing data stored on Parse, the Parse .NET SDK will automatically work out which data in the `ParseObject` has changed, so that only changed data is sent to Parse.

For more information about creating and updating data on Parse, see [Saving Objects](https://parse.com/docs/dotnet/guide#objects-saving-objects) and [Updating Objects](https://parse.com/docs/dotnet/guide#objects-updating-objects) on Parse's website.

## Deleting Data

The `ParseObject.DeleteAsync` method is used to delete data on Parse, as shown in the following code example:

```
public async Task DeleteTodoItemAsync (TodoItem item)
{
  ...
  await ToParseObject (item).DeleteAsync ();
  ...
}
```

For more information about deleting data on Parse, see [Deleting Objects](https://parse.com/docs/dotnet/guide#objects-deleting-objects) on Parse's website.

# Summary

This article examined how to consume a Parse web service from a Xamarin.Forms application, using the Parse .NET SDK. Parse provides backend solutions for mobile applications, eliminating the need for writing server code and maintaining servers.
