TodoLocalized (Xamarin.Forms *Shared Project*)
=============

**WARNING: requires a hack. not recommended unless the consequences are understood.**

A complete application that demonstrates the localization concepts from [this developer portal page](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/localization/),
and its [sample code](https://github.com/xamarin/xamarin-forms-samples/tree/master/UsingResxLocalization).

This sample uses a *Shared Project* (rather than PCL) for the common Xamarin.Forms code.

Making this work is a *hack* - you can no longer rely on the **designer.cs** file being auto-generated for the default resources, which breaks the strongly-typed `AppResources.` mechanism of accessing translated strings.

The differences between this Shared Project sample and the PCL sample are:

* The default namespace in each platform project was changed:

   - before: Todo.iOS, Todo.Android, Todo.WinPhone
   - after: TodoLocalized (all the same)
   
   normalizing the namespaces to a single value helps with the resource loading.
   
* The **Resx** folder with RESX files was manually added to the Shared Project (from the existing PCL sample). If you add a new **Resource File** from the IDE, you'll get an error message "Error: ResXFileCodeGenerator can only be used with .NET projects." For language-specific RESX files, simple click on the added file and in the **Properties** pad remove the "Custom Tool: ResXFileCodeGenerator" setting (leave it blank), and ensure the build action is set to **Embedded Resource**. 

* For the default resources **AppResources.resx** file - which *normally* would have the `AppResources.designer.cs` file auto-generated - you must manually keep the C# properties synchronized with whatever string elements you add to the resources XML. **This is going to be incredibly tedious and error prone, so using RESX localiztion with Shared Projects is not typically recommended unless you understand these limitations!**


**WARNING:** the WinPhone project has not yet been completed.