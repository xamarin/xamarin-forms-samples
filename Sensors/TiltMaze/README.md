---
name: Tilt Maze
description: '**Tilt Maze** is a game for Xamarin.Forms that uses the cross-platform [`Accelerometer`](https://docs.microsoft.com/xamarin/essentials/acceleromete...'
topic: sample
languages:
- csharp
products:
- xamarin
technologies:
- xamarin-forms
urlFragment: sensors-tiltmaze
---
Tilt Maze
=========

**Tilt Maze** is a game for Xamarin.Forms that uses the cross-platform [`Accelerometer`](https://docs.microsoft.com/xamarin/essentials/accelerometer?context=xamarin/xamarin-forms) included in Xamarin.Essentials. 

**Tilt Maze** runs on iOS, Android, and the Universal Windows Platform (UWP), but you'll need to run the program on an actual phone or tablet rather than a simulator. The objective is to tilt the device back and forth so that the red ball navigates through the maze and rolls down the black hole. (The ball must be entirely within the hole to fall down into it.) The maze then changes for another game.

Xamarin.Forms no longer runs on Windows Phone or Windows 10 Mobile devices, but **Tilt Maze** _will_ run on a Windows 10 tablet, such as a Surface Pro, and runs best in Tablet Mode. To run in Tablet Mode, all external monitors must be disconnected from the device. Sweep your finger along the right edge of the screen (or press the Notifications icon to the right of the date and time) to display the **Action Center**. Select **Tablet Mode**. Then run the program.

A different version of this program originally appeared in the book _Programming Windows Phone 7_, published in 2010. That version used XNA for the graphics. The Xamarin.Forms version uses `BoxView` elements for the maze and a custom `EllipseView` element for the ball and hole.

Author
------
Charles Petzold 







