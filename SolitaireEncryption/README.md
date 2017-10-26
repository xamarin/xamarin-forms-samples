Solitaire Encryption (Xamarin.Forms)
==============

A C# port of the [Solitaire encryption algorithm](https://www.schneier.com/solitaire.html) featured in Neal Stephenson's novel [Cryptonomicon](http://en.wikipedia.org/wiki/Cryptonomicon). The algorithm has been implemented in a Xamarin.Forms mobile app for iOS, Android, and the Universal Windows Platform (along with an NUnit test project containing the [tests from the author's website](https://www.schneier.com/code/sol-test.txt)). The algorithm itself is based on a deck of cards, however you don't see this when using the app; for more info check the source code^ or the [details of how it works](https://www.schneier.com/solitaire.html).

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/SolitaireEncryption/Screenshots/all-sml.png "Colors")

This sample illustrates the inclusion of a Unit Test project in a Xamarin.Forms solution and also a custom `Button` [renderer](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/custom-renderer/).

Author
------

Craig Dunn

*^ The original port of this algorithm was done (by me) in 2002, and I've used that 2002-era code *unchanged* in this mobile app. It's kinda cool that 12-year-old C# code can just be dropped into an app that runs on iOS, Android, and the Universal Windows Platform.*