MobileCRM (Xamarin.Forms)
=========

**MobileCRM** is a pre-built [Xamarin.Forms](http://xamarin.com/forms) app for iOS, Android, and Windows Phone. It even has its own [webpage](http://xamarin.com/prebuilt/crm).

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/MobileCRM/Screenshots/MobileCRM-iOS-sml.png "iOS")

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/MobileCRM/Screenshots/MobileCRM-Android-sml.png "Android")

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/MobileCRM/Screenshots/MobileCRM-WinPhone-sml.png "Windows Phone")


Xamarin.Forms
-------------

Visit the [Xamarin.Forms documentation](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/) for more information on the APIs and controls available for building cross-platform apps with 100% shared C# code.

Maps
----

`Xamarin.Forms.Maps` uses the native map APIs on each platform. If you are creating your own Xamarin.Forms app, **Xamarin.Forms.Maps** is a a separate NuGet package that you should download. On Android, this also has a dependency on **GooglePlayServices** (another NuGet) which is downloaded automatically. These have already been added to the MobileCRM solution.

After adding a reference to **Xamarin.Forms.Maps** in a new project, you also need to add 

    Xamarin.Forms.FormsMaps.Init()
    
calls to each application. Refer to the MobileCRM example where this is already implemented.


###iOS

On iOS the map control "just works".


###Android

To use the Google Maps API on Android you must generate an **API key** and add it to your Android project. See the Xamarin doc on [obtaining a Google Maps API key](http://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/). After following those instructions, paste the **API key** in the `Properties/AndroidManifest.xml` file (view source and find/update the following element):

    <meta-data android:name="com.google.android.maps.v2.API_KEY" android:value="AbCdEfGhIjKlMnOpQrStUvWValueGoesHere" />

You need to follow these instructions in order for the map data to display in MobileCRM on Android.

###Windows Phone

The `Map` control in Windows Phone requires the **ID_Cap_Map** capability to be selected. This has already been done in the source code, but should be kept in mind if you add maps to a new Xamarin.Forms app.

To set this value in a new Windows Phone app, click the **Properties** folder and double-click the **WMAppManifest.xml** file. Go to the **Capabilities** tab and tick **ID_Cap_Map**.


Authors
-------

Zach Gramana, James Montemagno, Seth Rosetter, Charles Petzold, Craig Dunn
