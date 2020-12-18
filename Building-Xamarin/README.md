# Building Xamarin.Forms Mobile App Using XAML (2019)
__By Dan Hermes__  
[Github Code Examples](https://github.com/danhermes/xamarin-xaml-book-examples)  
[MS Docs Guides](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/)

## Chapter 1: Building Apps Using Xamarin


## Chapter 2:  Building Xamarin.Forms App Using XAML  
If you come across the _namespace could not be found_ error while trying to load a namespace and library to your XAML document like this,
```
<ContentPage ...
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:sys="clr-namespace:System;assembly=mscorlib"
             ...
```  
For example you might get a namespace name `System` was not found error.   You may resolve by doing the following:  
* Go to Tools > Nuget Package Manager > PackageManager Console
* Run `dotnet restore`
* And rebuild your solution.  

__Anatomy of XAML files__  
The names of the events handlers specified in XAML must be instance methods that exist in the code behind. They cannot be static.   
Event handlers need to be used wisely, ideally only to enhance the controls they are serving and not to access services and business layer. Instead consider using other techniques such as behaviors, commands, and triggers or data binding for more reusable code.  


__XAML Compilation__  
For backward compatibility, XAML is interpreted at runtime. This impacts performance and  does not take advantage of compile-time error checking.   
You can turn on compilation at both the assembly and class level to improve performance and take advantage of compile-time error checking by adding the `XamlCompilation` attribute.  
At assembly level:
```
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PhotoApp
{
  ...
}
```
At class level:
```
[XamlCompilation(XamlCompilationOptions.Compile)]
public class MyPage: ContentPage  
{
  ...
}
```

## Chapter 3: UI Design Using Layouts  
__MS Docs__  
[Absolute Layout](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/absolutelayout)   

## Chapter 4: Styles, Themes and CSS
__Todo:__ Comeback later to review the theming section and how to implement dark and light themes.  
Continue the [Article](https://devblogs.microsoft.com/xamarin/app-themes-xamarin-forms/with with the project `ThemingApp`  


## Chapter 5: User Interactions Using Controls      
__MS Docs:__  
[Content View](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/contentview)  
[Control Template](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/templates/control-template)  
[Triggers](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/triggers)  
[Attached Property](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/attached-properties)  
[Bindable Property](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/bindable-properties)  
[Behaviors](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/)  

[Views](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/views)  
__Working With Icons__  
[Use FontAwesome in Xamarin Form](https://medium.com/@tsjdevapps/use-fontawesome-in-a-xamarin-forms-app-2edf25311db4)  
[Fonts](https://fontawesome.com/icons?d=gallery&s=brands,regular,solid&m=free)  

## Chapter 6: Making Scrollable List
__MS DOCS:__  
[Collection View](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/)  

__Customizing List Rows__    
Customizing a list can result in a beautiful, highly functional UI feature. It is also one of the best ways to destroy a list's performance, so customize with caution. Use _TextCell_ and _ImageCell_ as much as you can before deciding to customize.  

## Chapter 7: Navigation   
__Customizing the Navigation Bar__  
We use C# instead of XAML for _NavigationPage_ because _NavigationPage_ does not have a property for the root page and the Xamarin recommended approach is to use C# for _NavigationPage_.  

__State Management__  
The _App.Current.Properties_ dictionary persists when your app is backgrounded an even after your app has restarted! _Properties_ work a bit like cookies for youe app.    

__Using a Static Global Class__  
__Caution__ Overuse of static global classes can tax memory and affect performance. Pass variables directly between pages whenever you can so they go out of scope when no longer needed.  

__Creating a MasterDetails Page__  
A _MasterDetailPage_ is designed to be a root page, and using it as a child page in other page types could result in unexpected and inconsistent behavior. In addition, it's recommended that the master page of a _MasterDetailPage_ should always be a _ContentPage_ instance, and that the detail page should only be populated with _TabbedPage_, _NavigationPage_, and _ContentPage_ instances. This will help to ensure a consistent user experience across all platforms.  
__NB:__ The _MasterDetailPage.Master_ page must have its Title property set, or an exception will occur.  

__MS Docs:__ [Master Details Page](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/master-detail-page)    

__Tabbed Page__  
It's recommended that a _TabbedPage_ should be populated with _NavigationPage_ and _ContentPage_ instances only.
This will help to ensure a consistent user experience across all platforms.  
__Warning:__ In a _TabbedPage_, each Page object is created when the _TabbedPage_ is constructed.
This can lead to a poor user experience, particularly if the _TabbedPage_ is the root page of the application.
However, _Xamarin.Forms Shell_ enables pages accessed through a tab bar to be created on demand, in response to navigation.
For more information, see [Xamarin.Forms Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/).  
__Warning:__ While a _NavigationPage_ can be placed in a _TabbedPage_, it's not recommended to place a `TabbedPage` into a `NavigationPage`. This is because, on iOS, a `UITabBarController` always acts as a wrapper for the `UINavigationController`. For more information, see [Combined View Controller Interfaces](https://developer.apple.com/library/archive/documentation/WindowsViews/Conceptual/ViewControllerCatalog/Chapters/CombiningViewControllers.html) in the iOS Developer Library.  

__MS Docs:__ [Tabbed Page](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/tabbed-page)  
[Tabbed Page Styling](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/android/tabbedpage-toolbar-placement-color)

__Creating Data-Bound Tabs__
Todo: Return back to this later

__Carousel Using Carousel Pages__  
When using _CarouselPage_ as a detail page in _MasterDetailPage_, set `MasterDetailPage.IsGestureEnabled` to `false` to prevent gesture conflicts between
`CarouselPage` and `MasterDetailPage`.  

## Chapter 8: Custom Renderers, Effects, and Native Views  
__Custom Renderer__  
The renderers take a cross-platform element and draw it on the screen using the platform-specific UI library.
All Xamarin screens use renderers.  
If you want to gain access to all of the properties and methods within platform-specific elements
(such as UILabel, TextView, and TextBlock), then you need to create a custom renderer or an Effect.

__When to Use a Custom Renderer__  
Use a custom control when you need direct access to an element's platform-specific properties and methods.  

__Creating and Using a Custom Renderer__    
A custom renderer is created to implement the visual representation of a custom element.

__Which Renderer and View Do You Customize__  
See Table 8-1 on page 318 for details of renderers to use for various Xamarin.Form element for both platform specific views.

__Effects__  
Effects offer a reusable and lightweight approach to extend the capability of a Xamarin.Forms view compared to a custom renderer.  
Use effects if you only need to change a small number of the properties or behaviors of the underlying platform-specific control that Xamarin.Forms uses.  

__Creating and Using Effects__  
The developer needs to ensure that an effect is not accidentally added to a view that the effect does not support.  

__Adding Effects via Attached Properties__  
Attached properties can also be used to attach commands, behaviors, triggers, and other functionality to XAML elements.

__Native Views__  
Using native views requires knowledge of the platform-specific APIs, Xamarin.iOS and Xamarin.Andrios.  

__MS Docs:__ [Custom Renderer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)  
[Renders Base Clases](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/renderers)  

## Chapter 9: Data Access with SQLite and Data Binding  
__What Is SQLite__  
You can use SQLite with Xamarin in one of two ways:  
* Using SQLite.NET ORM
* Using Third-party MVVM libraries e.g _MvvmCross_, _ReactiveUI_ or _MVVM Light Toolkit_
Learn more about [MVVM Cross](https://www.mvvmcross.com/)  
Learn more about [MVVM Light Toolkit](http://www.mvvmlight.net/doc)  
Learn more about [ReactiveUI](https://www.reactiveui.net/docs/getting-started/)    

__Data Storage Options__  
1. File-bases Storage
  * XML
  * JSON
  * HTML
  * CSV
2. Preferences (key/value storage)
3. Local Database  

__Binding to View Models and Data Models__  
Here are the three approaches:  
1. Create a view model that implements _INotifyPropertyChanged_     
  The disadvantage of the approach is that it leads to code duplication with multiple _INotifyPropertyChanges_ implementations of the same property in different view models.  
2. Implement _INotifyPropertyChanged_ in your data model  
  The disadvantage of the approach is that it clutters up the data model and increases the number if notifications sent, which can impact performance for large data objects.  
3. Wrap your data model in an _Observable_ class  
 This approaches avoids the problems found in the first two approaches. Here you wrap your data model in a class that implements _INofityPropertyChanges_ to make it observable (at the code of creating yet another subclass).

__Locking Is Key__  
There are two ways to achieve locking with SQLite:  
1. Synchronous SQLite calls and explicit locking.  
2. Asynchronous SQLite calls with implicit locking. Async calls do the locking for you.

Learn about _SQLite asynchronous API_.
__MS Docs__   
[SQLite Database](https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/database?pivots=windows)


### Working with a REST API  
Install the _NewtonSoft JSON.NET_ Nuget package.
__MS Docs__
[Consume a RESTful Web Service](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest)


### Real Time Application Libraries  
[Pusher Client](https://github.com/pusher/pusher-websocket-dotnet)  
[Socket.io Client](https://github.com/doghappy/socket.io-client-csharp)
