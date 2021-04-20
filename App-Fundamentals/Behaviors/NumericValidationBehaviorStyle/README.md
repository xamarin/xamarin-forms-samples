---
name: Xamarin.Forms - Numeric validation behavior with style
description: Xamarin.Forms behaviors can be consumed by an explicit or implicit style. This sample shows how to consume a behavior with an explicit style
page_type: sample
languages:
- csharp
products:
- xamarin
urlFragment: behaviors-numericvalidationbehaviorstyle
---
# Numeric Validation Behavior with Style

Xamarin.Forms behaviors can be consumed by an explicit or implicit style. This sample demonstrates how to consume a Xamarin.Forms behavior with an explicit style.

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <Style x:Key="NumericValidationStyle" TargetType="Entry">
            <Style.Setters>
                <Setter Property="local:NumericValidationBehavior.AttachBehavior" Value="true" />
            </Style.Setters>
        </Style>
    </ResourceDictionary>
</ContentPage.Resources>
<StackLayout Padding="10,50,10,0">
    <Label Text="Red when the number isn't valid" FontSize="Small" />
    <Entry Placeholder="Enter a System.Double" Style="{StaticResource NumericValidationStyle}" />
</StackLayout>
```

![NumericValidation Behavior with Style application screenshot](Screenshots/01All.png "NumericValidation Behavior with Style application screenshot")

For more information about this sample, see [Behaviors](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/behaviors/).
