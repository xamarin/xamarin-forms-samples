Working with ListView Native Layouts
==============

The Xamarin.Forms layout engine is very powerful, enabling developers to express their screens in a way that can be rendered across all supported platforms.

Very complex layouts can take time to compute, on Xamarin.Forms or even on native platforms. This is exacerbated in a scrolling view like the `ListView` where the layouts need to be recalculated as you scroll.

Many Xamarin.Forms apps won't ever encounter issues with scrolling, but if you do one optimization you can try is using a custom renderer to build native cell layouts.

This example has four different screens:

* The first two demonstrate the absolute simplest case of a ListView built with Xamarin.Forms versus one demonstrating the custom render concept.

* The third screen uses a custom renderer for the CELL (UITableViewCell) only. This removes the Xamarin.Forms layout calculations from being repeatedly called during scrolling.

* The fourth screens uses a custom renderer for the LIST AND CELL (UITableView, Android ListView) with native platform built-in cells - they're ugly (my design skills are lacking) but demonstrate how you can build your cells in the platform projects. This is additional work, and typically only makes sense if you are porting an existing native app where you want to re-use both your LIST AND CELL native code.

The custom renderer native cells are shown in this screenshot:

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/WorkingWithListviewNative/Screenshots/all-sml.png "Performance")

*(Xaml examples still-to-come)*


Author
------

Craig Dunn
