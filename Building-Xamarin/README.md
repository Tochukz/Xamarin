# Building Xamarin.Forms Mobile App Using XAML (2019)
__By Dan Hermes__  
[Github Code Examples](https://github.com/danhermes/xamarin-xaml-book-examples)  
[MS Docs Guides](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/)

## Chapter 1: Building Apps Using Xamarin


## Chapter 2:  Building Xamarin.Form App Using XAML  
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
The _Properties_ dictionary persists when your app is backgrounded an even after your app has restarted!  

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
