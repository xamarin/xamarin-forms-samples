Xamarin.Forms Samples
=====================

Sample apps built using the Xamarin.Forms framework.

License
-------

The Apache License 2.0 applies to all samples in this repository.

   Copyright 2011 Xamarin Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

Contributing
------------

Before adding a sample to the repository, please run either install-hook.bat
or install-hook.sh depending on whether you're on Windows or a Posix system.
This will install a Git hook that runs the Xamarin code sample validator before
a commit, to ensure that all samples are good to go.
                                                                                                                  
                                             
Samples Submission Guidelines
=============================

## Galleries

We love samples! Application samples show off our platform and provide a great way for people to learn our stuff. And we even promote them as a first-class feature of the docs site. You can find our two sample galleries here:

* [Xamarin Forms Samples](http://developer.xamarin.com/samples/xamarin-forms/all/)

* [iOS Samples](http://developer.xamarin.com/samples/ios/all/)

* [Mac Samples](http://developer.xamarin.com/samples/mac/all/)

* [Android Samples](http://developer.xamarin.com/samples/android/all/)

## Sample GitHub Repositories

These sample galleries are populated by samples in our six sample GitHub repos:

* [https://github.com/xamarin/xamarin-forms-samples](https://github.com/xamarin/xamarin-forms-samples)

* [https://github.com/xamarin/mobile-samples](https://github.com/xamarin/mobile-samples)

* [https://github.com/xamarin/monotouch-samples](https://github.com/xamarin/monotouch-samples)

* [https://github.com/xamarin/mac-samples](https://github.com/xamarin/mac-samples)

* [https://github.com/xamarin/monodroid-samples](https://github.com/xamarin/monodroid-samples)

* [https://github.com/xamarin/mac-ios-samples](https://github.com/xamarin/mac-ios-samples)

The [mobile-samples](https://github.com/xamarin/mobile-samples) repository is for samples that are cross-platform.
The [mac-ios-samples](https://github.com/xamarin/mac-ios-samples) repository is for samples that are Mac/iOS only.

## Sample Requirements

We welcome sample submissions.

However, because the sample galleries are powered by the github sample repos, each sample needs to have the following things:

* **Screenshots** - a folder called Screenshots that has at least one screen shot of the sample (preferably a screen shot for every page or every major functionality piece, people really key off these things). for the xplat samples, the folder should be split into platform folders, e.g. iOS, Android, Windows. see[ https://github.com/xamarin/mobile-samples/tree/master/Tasky/Screenshots](https://github.com/xamarin/mobile-samples/tree/master/Tasky/Screenshots) for an example of this.

* **Readme** - a[ README.md](http://readme.md/) file that has the name of the sample, a description, and author attribution. sample here:[ https://github.com/xamarin/mobile-samples/blob/master/Tasky/README.md](https://github.com/xamarin/mobile-samples/blob/master/Tasky/README.md)

* **Metadata** - Finally, it needs a Metadata.xml file ([https://github.com/xamarin/mobile-samples/blob/master/Tasky/Metadata.xml](https://github.com/xamarin/mobile-samples/blob/master/Tasky/Metadata.xml)) that has some information:

    * **ID** - A GUID for the sample. You can generate this in MD under Tools menu : Insert GUID. we need this to key between articles and their associated samples

    * **IsFullApplication** - Boolean flag (true or false): whether or not this is a full application such as the MWC App, Tasky, etc., or it's just a feature sample, such as, how to use 'x' feature. the basic test here is, if you would submit this to the app store because it's useful, then it's a full app, otherwise it's just a feature sample.

    * **Brief** - Short description or what your sample does. This allows us to display a nice and clean vignette on the sample page.

    * **Level** - Beginner, Intermediate, or Advanced: this is the intended audience level for the sample. only the getting started samples are Beginner, as they are intended for people who are _just_ starting with the platform. most samples are Intermediate, and a few, that dive deep into difficult APIs, should be Advanced.

    * **Minimum License Requirement** - Starter, Indie, Business, or Enterprise: denotes the license that a user has to have in order to build/run the sample.

    * **Tags**: a list of relevant tags for the app. These are:
    * **Data**
    * **Games**
    * **Graphics** (CoreDrawing, Animation, OpenGL...)
    * **Media** (Video, Sound, recording, photos)
    * **Platform Features** (Photo Library, Contacts, Calendars, etc.)
    * **Device Features** (NFC, Accelerometer, Compass, Magnemometer, Bluetooth, RFID)
    * **Cloud** (Web Services, Networking, etc.)
    * **Backgrounding**
    * **Maps + Location**
    * **Binding + Interop** (Projections)
    * **Notifications**
    * **Touch**
    * **Getting Started**
    * **Async**
    * **FSharp**

    * **SupportedPlatforms**: this is only for cross plat samples. It's a comma-separated list, and the valid values are iOS, Android, and Windows.

    * **Gallery**: This tag must contain a value of true if you want the sample to show up in the samples gallery on the developer portal.

* **Buildable Sln and CSProj file** - the project _must_ build and have the appropriate project scaffolding (solution + proj).

A good example of this stuff is here in the drawing sample:[ https://github.com/xamarin/monotouch-samples/tree/master/Drawing](https://github.com/xamarin/monotouch-samples/tree/master/Drawing)

For a x-platform sample, please see: https://github.com/xamarin/mobile-samples/tree/master/Tasky

## GitHub Integration

We integrate tightly with Git to make sure we always provide working samples to our customers. This is achieved through a pre-commit hook that runs before your commit goes through, as well as a post-receive hook on GitHub's end that notifies our samples gallery server when changes go through.

To you, as a sample committer, this means that before you push to the repos, you should run the "install-hook.bat" or "install-hook.sh" (depending on whether you're on Windows or OS X/Linux, respectively). These will install the Git pre-commit hook. Now, whenever you try to make a Git commit, all samples in the repo will be validated. If any sample fails to validate, the commit is aborted; otherwise, your commit goes through and you can go ahead and push.

This strict approach is put in place to ensure that the samples we present to our customers are always in a good state, and to ensure that all samples integrate correctly with the sample gallery (README.md, Metadata.xml, etc). Note that the master branch of each sample repo is what we present to our customers for our stable releases, so they must *always* Just Work.

Should you wish to invoke validation of samples manually, simply run "validate.windows" or "validate.posix" (again, Windows vs OS X/Linux, respectively). These must be run from a Bash shell (i.e. a terminal on OS X/Linux or the Git Bash terminal on Windows).

If you have any questions, don't hesitate to ask!

