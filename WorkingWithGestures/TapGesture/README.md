Working with Gestures
=====================

These samples relate to the [Working with Gestures in Xamarin.Forms](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/gestures) doc. The code to create a gesture recognizer for tapped events is simple:

    var tapGestureRecognizer = 
		new TapGestureRecognizer();
	//tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
	tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
	frame.GestureRecognizers.Add(tapGestureRecognizer);

![screenshot](https://raw.githubusercontent.com/xamarin/xamarin-forms-samples/master/WorkingWithGestures/Screenshots/Gestures-sml.png "Gestures")


Authors
-------

Charles Petzold, Craig Dunn
