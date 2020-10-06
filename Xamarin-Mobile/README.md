#  Xamarin Mobile Application Development (2015)
#### Cross-Platform C# and Xamarin.Forms Fundamentals
__By Dan Hermes__  

[Example Code](https://github.com/danhermes/xamarin-book-examples)  

[Build Xamarin.iOS in Cloud](https://birdsbits.blog/2015/12/05/developing-ios-apps-in-visual-studio-with-macincloud/)

__NB:__   
The book only provide a small treatment of _Xamarin.Andriod_ and _Xamarin.iOS_ introductory topics.     
For mastery of Android and _Xamarin.Android_ fundamentals, consult _Xamarin.Android_ primer.  
For mastery of iOS and _Xamarin.iOS_ fundamentals, consult a _Xamarin.iOS_ primer.    

__Application Monitoring and Analysis__
Use (Microsoft App Center)[https://appcenter.ms/] for monitoring and analytics of your mobile application.
## Chapter 1: Mobile Development Using Xamarin__    
__Data Access Layer__   
Mobile data access layer resembles those found in desktop apps.  Data-bounds pages typically feed into a local database on the device, which syncs with a remote data server using web services.
Mobile web services more closely resemble those found in desktop application, differing from web app services primarily in the importance of data synchronization and offline use.  
Offline use requires a basic data set to be kept on hand in the local database and synced when a connection is available. Not all apps support offline use.   

__Data Binding__  
A growing number of third party vendors are providing Xamarin.Forms control suites which include data-bound charts and grid, such as [Telerik](https://www.telerik.com/), [Infragistics](https://www.infragistics.com/), [Syncfusion](https://www.syncfusion.com/), and [DevExpress](https://www.devexpress.com/)  
Data-Binding is not built into Xamarin.Andriod and Xamain.iOS.Platform-specific implementations of data binding are typically achieved using open-source third party libraries such as [MVVM Cross](https://www.mvvmcross.com/)  and [MVVM Light Toolkit](http://www.mvvmlight.net/doc).  

## Chapter 2: Building Mobile User Interfaces    
__Xamarin.iOS__   
Dynamic data-binding, data flow between pages, and visual effects and complexity are often best accomplished with hand coded C#.  

__Use Both Approaches with Custom Renderers__  
Use Custom Renderers sparingly, or risk a fragmented UI code base that probably should have been written entirely as a platform-specific UI.  

__Creating a Xamarin.Forms Solution__  
The Core Library project is not added by solution templates and must be created manually, either as a shared projects or PCL. If you are just getting started with Xamarin.Forms you can skip the core library for now and put all your shared files in the Xamarin.Forms project.    

__Page__  
The _Page_ class is the primary container of each main screen. Derived from _Xamarin.Forms.VisualElment_.  Here are the primary pages:  
1. ContentPage  
2. MasterDetailsPage  
3. NavigationPage  
4. TabbedPage  
5. CarouselPage  
6. Template Page  

__Layout__  
_Xamarin.Form_ layouts are derived from the _View_ class.  So everything contained by a page is actually some form of view.  

__Xamarin.Forms Shared Code__  
__Tip:__ A static _Application.Current_ property references the current application object anywhere in your app.  

__Core Library__  
The core library is a project in a _Xamarin.Forms_ solution for the business and/or data layer of an app which should be largely platform independent. Create one yourself and ass it to your solution. This is the place for platform-independent middle-tier or back-end non-UI cod.  

__Making an Image Clickable with a GestureRecognizer__  
A gesture recognizer is a class that can be added to many views to respond to user interaction.
Often when a button or image is pressed, the result should be backgrounded using _async/await_ for an optimal user experience.  

## Chapter 3: UI Design Using Layouts  
__MS Docs__  
[Absolute Layout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/absolutelayout)  

__Using Android Layouts__  
Skipped this for now.

__Using iOS Layouts__  
Skipped this for now.  

## Chapter 4: User Interaction Using Controls  
