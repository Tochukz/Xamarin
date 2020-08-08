# Building Xamarin.Forms Mobile App Using XAML (2019)
__By Dan Hermes__  
[Example Code](https://github.com/danhermes/xamarin-xaml-book-examples)

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
* Go to Tools >Nuget Package Manager > PackageManager Console
* Run `dotnet restore`
* And rebuild your solution.  
