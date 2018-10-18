# ViewModel First Navigation Sample

In this sample we can register our Views with our ViewModels in a seperate service. That means, View and ViewModel are agnostic to each other. This gives us the ability to create a ViewModel First Navigation. The default implementation of navigation in Xamarin.Forms is a Page First Navigation. In short: you pass the View to the navigation service. In this sample, you pass a ViewModel to the navigation service! 

## Features

- Advanced MVVM
- Autowireing for Pages and ViewModels
- ViewModel First Navigationservice