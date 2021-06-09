# Xamarin Mobile Development for Android Cookbook (2015)  
__By Matthew Leibowits__  

## Chapter 1: Working with Xamarin.Android
_Xamarin.Android_ does not abstract or emulate any Android features. Rather, it is an alternative programming language available for the development of Android apps.  
If we are using _Android Studio_ or _Eclipse_, we will have to make changes in _AndroidManifest.xml._ If we are using _Xamarin.Android_, we can do much of this work by using the familiar attributes.  Various attributes can be used to provide the same functionality that modifying the _AndroidManifest.xml_ file would bring.  

__Providing alternative resources__  
You may include alternative resources to support specific device configurations. [Learn more](https://developer.android.com/guide/topics/resources/providing-resources.html#AlternativeResources)  
__Tip__  
* Strive to keep your layout hierarchy as shallow as possible. The layout will be drawn faster if it has fewer nested layouts.  
