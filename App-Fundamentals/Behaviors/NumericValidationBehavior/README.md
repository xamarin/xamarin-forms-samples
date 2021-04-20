---
name: Xamarin.Forms - NumericValidation Behavior
description: "Xamarin.Forms behaviors are created in a class that derives from the Behavior, or Behavior<T> class"
page_type: sample
languages:
- csharp
products:
- xamarin
urlFragment: behaviors-numericvalidationbehavior
---
# NumericValidation Behavior

Xamarin.Forms behaviors are created in a class that derives from the Behavior, or Behavior&lt;T&gt; class. This sample demonstrates how to create and consume a Xamarin.Forms behavior.

For more information about this sample, see [Behaviors](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/behaviors/).

```xaml
<Entry Placeholder="Enter a System.Double">
    <Entry.Behaviors>
        <local:NumericValidationBehavior />
    </Entry.Behaviors>
</Entry>
```

![NumericValidation Behavior application screenshot](Screenshots/01All.png "NumericValidation Behavior application screenshot")
