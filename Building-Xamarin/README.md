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

#### Working With Icons
__To Use FontAwesome in Xamarin Forms__  
1. __Get the fonts__
  * Go to [fontawesome.com](https://fontawesome.com/)
  * Click on the _Start_ Menu  
  * Scroll down to where it says: __Desktop__ _Install locally and use in desktop app_, click on it
  * On the next page click on the _Download Font Awesome Free for Desktop_ link
  * Unzip the downloaded file and you should find `.otf` files in the `otf` directory.
  * You may rename the files to simpler names and make sure to remove spaces from the names
2. __Add otf files to your Projects__  
  * Copy your `.otf` files to the `Assets` directory of your Android project. The __Build Action__ property for the files should be set to _AndriodAsset_
  * Copy your `.otf` files to the `Resources` directory of your iOS project. The __Build Action__ property for the files should be set to _BundleResource_
  * Copy your `.otf` files to the `Assets` folder of your `UWP` project. The __Build Action__ property for the files should be set to _Content_.   
3. __Update the Info.plist file for iOS Project__  
  * Write Click on the `Info.plist` file of your iOS project and click on  _Open with_
  * On the popup dialog select the _XML (Text) Editor_ option
  * Append the following to the `dict` element
  ```
  <key>UIAppFonts</key>
  <array>
    <string>FontAwesome5BrandsRegular.otf</string>
    <string>FontAwesome5Regular.otf</string>
    <string>FontAwesome5Solid.otf</string>
  </array>
  ```

  * Make sure the text node in the string element marches the names of your `.otf` files
  * Save the `Info.plist` file and close it.  
4. __Create App Resources__   
  * Create three resources in your `App.xaml` file to make the fonts available everywhere in your app
  ```
  <Application.Resources>
    <ResourceDictionary>
      <OnPlatform x:TypeArguments="x:String"
                  x:Key="FontAwesomeBrands">
        <On Platform="Android"
            Value="FontAwesome5Brands.otf#Regular" />
        <On Platform="iOS"
            Value="FontAwesome5Brands-Regular" />
        <On Platform="UWP"
            Value="/Assets/FontAwesome5Brands.otf#Font Awesome 5 Brands" />
      </OnPlatform>

      <OnPlatform x:TypeArguments="x:String"
                  x:Key="FontAwesomeSolid">
        <On Platform="Android"
            Value="FontAwesome5Solid.otf#Regular" />
        <On Platform="iOS"
            Value="FontAwesome5Free-Solid" />
        <On Platform="UWP"
            Value="/Assets/FontAwesome5Solid.otf#Font Awesome 5 Free" />
      </OnPlatform>

      <OnPlatform x:TypeArguments="x:String"
                  x:Key="FontAwesomeRegular">
        <On Platform="Android"
            Value="FontAwesome5Regular.otf#Regular" />
        <On Platform="iOS"
            Value="FontAwesome5Free-Regular" />
        <On Platform="UWP"
            Value="/Assets/FontAwesome5Regular.otf#Font Awesome 5 Free" />
      </OnPlatform>
    </ResourceDictionary>
  </Application.Resources>
  ```  
* The value of the Value attribute for iOS in  

 ```
 <On Platform="iOS"
     Value="FontAwesome5Brands-Regular" />
 ```

 S=should be the post script name of the Font File not the normal file name.  

 __To Get the Postscript name (on MacOS)__    
 * Right click on the `.otf` file > open with > Font book
 * Click Install font
 * On the Font Book window, click on the font name to drop down
 * Select the font subname
 * On the right hand side Copy the PostScript name from the font info.

5. __Get an Icon Code__   
     * Go to [fontawsome gallery](https://fontawesome.com/v5.15/icons?d=gallery&p=2&m=free)
     * Select free icons and either _Solid_, _Regular_ or _Brands_ from the navigation to filter
     * Click on an icon to go to it's  details page
     * Copy its Unicode e.g `f26e`

6. __Use the Icon Code__  
    * In your View you can use the Icon code as follows
    ```
    <Label Text="&#xf26e;"
        FontFamily="{StaticResource FontAwesomeBrands}" />
    ```
    * Take note of the additional characters added to the Unicode to serve as escape code.
    * Also the `FontAwesomeBrands` is used because the icon in our case is of the _Brands_ group.  

7. __Name your Icon Codes__  
  When we look at the Icon Code in the `Text` attribute value you may not be able to tell what icon it is. To solve this problem we can name out icon Unicode accordingly
  * Create a Class file
  ```
    using System;

    namespace FontAwesome
    {
        public static partial class FontAwesomeIcons
        {

            public const string FiveHundredPX = "\uf26e";

            public const string Abacus = "\uf640";
        }
    }
  ```
  * Add the namespace to your page
  ```
    xmlns:fontawesome="clr-namespace:FontAwesome"
  ```
  * Use your Unicode icon name instead of the raw escaped Unicode
  ```
  <Label Text="{x:Static fontawesome:FontAwesomeIcons.FiveHundredPX}" FontFamily="{StaticResource FontAwesomeBrands}" />
  ```

__Learn More__  
[Use FontAwesome in Xamarin Form](https://medium.com/@tsjdevapps/use-fontawesome-in-a-xamarin-forms-app-2edf25311db4)  
[FontAwesome in Xamarin Forms. Everything you need to know!!](https://medium.com/xamarinlife/fontawesome-in-xamarin-forms-everything-you-need-to-know-b187af338e30)
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
The _App.Current.Properties_ dictionary persists when your app is backgrounded and even after your app has restarted! _Properties_ work a bit like cookies for youe app.    

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

__MS Docs:__  
[Custom Renderer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)  
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

__Data Binding__  
Xamarin apps can use third-party data-binding libraries such as _MvvmCross_ or _MVVM Light_.

__Binding to View Models and Data Models__  
Here are the three approaches:  
1. Create a view model that implements _INotifyPropertyChanged_     
  The disadvantage of this approach is that it leads to code duplication with multiple _INotifyPropertyChanges_ implementations of the same property in different view models.  
2. Implement _INotifyPropertyChanged_ in your data model  
  The disadvantage of this approach is that it clutters up the data model and increases the number of notifications sent, which can impact performance for large data objects.  
3. Wrap your data model in an _Observable_ class  
 This approaches avoids the problems found in the first and second approaches. Here you wrap your data model in a class that implements _INofityPropertyChanges_ to make it observable (at the code by creating yet another subclass).

__Locking Is Key__  
There are two ways to achieve locking with SQLite:  
1. Synchronous SQLite calls and explicit locking.  
2. Asynchronous SQLite calls with implicit locking. Async calls do the locking for you.

Learn about _SQLite asynchronous API_  
__MS Docs__   
[SQLite Database](https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/database?pivots=windows)


### Working with a REST API  
Install the _NewtonSoft JSON.NET_ Nuget package.  
__MS Docs__  
[Consume a RESTful Web Service](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest)


### Real Time Application Libraries  
[Pusher Client](https://github.com/pusher/pusher-websocket-dotnet)  
[Socket.io Client](https://github.com/doghappy/socket.io-client-csharp)

### Local Notification
[Xamarin Docs](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/local-notifications)

### Custom Template with Content View
[Creating page templates for Xamarin Forms](https://medium.com/@HoussemDellai/creating-page-templates-for-xamarin-forms-ec8cbc336d25)

### Build for Release  
__Prepare for Release__  
1. Android Manifest Setup
Right Click Android Project > Properties > Android Manifest  
_Application icon:_ @minimap/icon   
Replace all `icon.png` and `laucnher_foreground.png` images with your own.  
_Version number_: 1
 Increase the Version number by 1 for every build. Version number is used internally by Android.  
In manifest xml file: `android:versionCode.`
_Version name_ 0.0.1
You can be shared the Version name with the user.  Version name is not used internal  
In Manifest xml file: `android:versionName`
Click Save

2. Android Options  
_Code Shrinker_: r8
_Disable Debugger_:

In the Manifest file `android:debuggable`: `false` or in `AssemblyInfo.cs`
```

```

Click Save
3. Publishing
Right click Android Project > Archive  
After the Archive is complete click on Distribute.
Select `Ad Hoc` for side loading or `Google Play` for Google play store distribution  
Sign the apk by clicking on the green plus icon to add a signature for the App
Fill in the `Create Android Keystore` form with the relevant information and click on _Create_ button
Click on your newly created Signature and click on the _Save as_ button to save the APK
Enter an name for you APK file and click the _Save_ button.  
You will be prompted to enter the password you entered when you were filling the Signing form
Click on the `Open Distribution` button to see the APK that was saved

__MS Docs__  
[Preparing an Application for Release](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows)

### Publish TO Google Play Store
1. Create a Google Play developer account at [https://play.google.com/console/u/0/signup](https://play.google.com/console/u/0/signup)
2. Add a Marchant Account if you went to sell paid apps or in-app purchases
3. Prepare End User License Agreement (EULA) and Privacy Policy document  


__Useful Links__ 
[A Step-by-Step Guide](https://orangesoft.co/blog/how-to-publish-an-android-app-on-google-play-store)
[Terms of Service](https://play.google.com/about/console/terms-of-service/)
[Developer Distribution Agreement](https://play.google.com/about/developer-distribution-agreement.html)
