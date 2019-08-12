---
name: Xamarin.Forms - Calling Factory Methods
description: "Demonstrates using XAML to call a factory method that can be used to initialize an object (UI)"
page_type: sample
languages:
- csharp
products:
- xamarin
extensions:
    tags:
    - ui
urlFragment: xaml-callingfactorymethods
---
# Calling factory methods in Xamarin.Forms XAML

This sample demonstrates using XAML to call a factory method that can be used to initialize an object.

For more information about this sample, see [Passing Arguments in XAML](https://docs.microsoft.com/xamarin/xamarin-forms/xaml/passing-arguments).

![Calling Factory Methods application screenshot](Screenshots/01All.png "Calling Factory Methods application screenshot")

```csharp
<BoxView HeightRequest="150" WidthRequest="150" HorizontalOptions="Center">
    <BoxView.Color>
        <Color x:FactoryMethod="FromRgba">
            <x:Arguments>
                <x:Int32>192</x:Int32>
                <x:Int32>75</x:Int32>
                <x:Int32>150</x:Int32>
                <x:Int32>128</x:Int32>
            </x:Arguments>
        </Color>
    </BoxView.Color>
</BoxView>
```
