UITest Demo (Xamarin.Forms)
=============

This sample is a quick demo of combining the [Xamarin Test Cloud Agent component](http://components.xamarin.com/view/calabash) with [Xamarin.Forms](http://xamarin.com/forms) to write UITests that are cross-platform (ie write one test that can run against both iOS and Android versions of your Xamarin.Forms app).

Important points:

* In the **iOS** `AppDelegate` the `ViewInitialized` method is wired up to populate the iOS *AccessibilityIdentifier* from the Xamarin.Forms `StyleId`

* In the **Android** `MainActivity` the `ViewInitialized` method is wired up to populate the Android *ContentDescription* from the Xamarin.Forms `StyleId`

* In the Xamarin.Forms user interface, the `StyleId` is set on controls that need to be referenced in tests.

* In the **UITests** unit test project, there is a set of cross-platform tests in a virtual class (`CrossPlatformTests`). These tests will be run against both platforms. The cross-platform tests reference the `StyleId` used in the UI code, eg. `c.Marked("MyLabel")`

* In the **UITests** unit test project the iOS and Android subclasses of `CrossPlatformTests` do the platform-specific set-up.

The Xamarin Studio test runner can run these tests in the platform simulators. Note that the virtual class containing the core tests is shown but with all tests ignored. The tests only run 'for real' from within the platform-specific sub-classes of `CrossPlatformTests`. 

![screenshot](https://raw.githubusercontent.com/conceptdev/xamarin-forms-samples/master/UITestDemo/Screenshots/Tests.png "Test hierarchy")

![screenshot](https://raw.githubusercontent.com/conceptdev/xamarin-forms-samples/master/UITestDemo/Screenshots/Results.png "Results (ignore the ignored tests)")

