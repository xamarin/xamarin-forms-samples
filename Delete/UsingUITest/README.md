---
name: Xamarin.Forms - App Center UITest
description: 'Sample code using App Center UITest with Xamarin.Forms.'
page_type: sample
languages:
- csharp
products:
- xamarin
urlFragment: usinguitest
---
# Using UITest (Xamarin.Forms)

Sample code for the [Xamarin.Forms UITest](https://docs.microsoft.com/appcenter/test-cloud/uitest/get-started-xamarin-forms/) doc.


Important points:

* In the **iOS** `AppDelegate` the `ViewInitialized` method is wired up to populate the iOS *AccessibilityIdentifier* from the Xamarin.Forms `AutomationId`

* In the **Android** `MainActivity` the `ViewInitialized` method is wired up to populate the Android *ContentDescription* from the Xamarin.Forms `AutomationId`

* In the Xamarin.Forms user interface, the `AutomationId` is set on controls that need to be referenced in tests.

* In the **UITests** unit test project, there is a set of cross-platform tests in a virtual class (`CrossPlatformTests`). These tests will be run against both platforms. The cross-platform tests reference the `AutomationId` used in the UI code, eg. `c.Marked("MyLabel")`

* In the **UITests** unit test project the iOS and Android subclasses of `CrossPlatformTests` do the platform-specific set-up.

The Visual Studio for Mac test runner can run these tests in the platform simulators. Note that the virtual class containing the core tests is shown but with all tests ignored. The tests only run 'for real' from within the platform-specific sub-classes of `CrossPlatformTests`.

![screenshot](https://raw.githubusercontent.com/conceptdev/xamarin-forms-samples/master/UITestDemo/Screenshots/Tests.png "Test hierarchy")

![screenshot](https://raw.githubusercontent.com/conceptdev/xamarin-forms-samples/master/UITestDemo/Screenshots/Results.png "Results (ignore the ignored tests)")

