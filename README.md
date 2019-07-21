Xamarin.Forms Samples
=====================

The samples in this repository demonstrate how to use different aspects of Xamarin.Forms to build cross-platform apps for iOS, Android, and the Universal Windows Platform (UWP). Please visit the Xamarin.Forms [sample gallery](https://developer.xamarin.com/samples/xamarin-forms/) to download individual samples.

For additional platform support, visit the following forks:

  * Tizen: https://github.com/Samsung/xamarin-forms-samples 
  * GTK#: https://github.com/jsuarezruiz/xamarin-forms-samples/tree/gtk

License
-------

See the [license file](LICENSE) and any additional license information attached to each sample.

Samples Submission Guidelines
=============================

This repository welcomes contributions and suggestions. If you want to create a new sample, you need to work with an employee to help bring the new sample into the repository. Start by raising a [GitHub issue](https://github.com/xamarin/xamarin-forms-samples/issues/new) in this repository that outlines your proposed sample. Please note that samples in the MASTER branch of this repository shouldn't rely on preview or pre-release NuGet packages.

The Xamarin.Forms [sample gallery](https://developer.xamarin.com/samples/xamarin-forms/) is powered by this repository, and therefore each sample needs to comply with the following requirements:

* **Screenshots** - a folder called Screenshots that has at least one screen shot of the sample on each platform (preferably a screen shot for every page or every major piece of functionality). For an example of this, see [TodoREST](https://github.com/xamarin/xamarin-forms-samples/tree/master/WebServices/TodoREST/Screenshots).

* **Readme** - a `README.md` file that has the name of the sample, a description, and author attribution. For an example of this, see [TodoREST](https://github.com/xamarin/xamarin-forms-samples/blob/master/WebServices/TodoREST/README.md).

* **Metadata** - a `Metadata.xml` file that has the following information:

    * **ID** - a GUID for the sample.    

    * **IsFullApplication** - a boolean value that indicates whether the sample is a full app, which could be submitted to an app store, or a feature sample.

    * **Brief** - a short description of what the sample does.

    * **Level** - the intended audience level for the sample: Beginner, Intermediate, or Advanced. Only the getting started samples are Beginner, as they are intended for people who are _just_ starting with the platform. Most samples are Intermediate, and a few, that dive deep into difficult APIs, should be Advanced.

    * **Minimum License Requirement** - Starter, Indie, Business, or Enterprise: denotes the license that a user has to have in order to build and run the sample.

    * **Tags**: a list of relevant tags for the app. These are:

      * **Advanced**
      * **Animation**
      * **Behaviors**
      * **Custom Renderers**
      * **Data**
      * **Dependency Service**
      * **Effects**
      * **Games**
      * **Getting Started**
      * **Graphics**
      * **Navigation**
      * **Styles**
      * **Templates**
      * **Text**
      * **Touch**
      * **User Interface**
      * **Web Services**
      * **Xamarin Live Player**
      * **Xamarin.Forms**
      * **XAML**

    * **SupportedPlatforms**: a comma-separated list of the supported platforms. Valid values are currently iOS, Android, and Windows.

    * **Gallery**: a boolean value that indicates whether the sample should appear in the Xamarin.Forms [sample gallery](https://developer.xamarin.com/samples/xamarin-forms/).

    For an example of a `Metadata.xml` file, see [TodoREST](https://github.com/xamarin/xamarin-forms-samples/blob/master/WebServices/TodoREST/Metadata.xml).

* **Buildable solution and .csproj file** - the project _must_ build and have the appropriate project scaffolding (solution + .csproj).

This approach ensures that all samples integrate with the Xamarin.Forms [sample gallery](https://developer.xamarin.com/samples/xamarin-forms/).

If you have any questions, don't hesitate to ask on the [Xamarin Forums](https://forums.xamarin.com/).
