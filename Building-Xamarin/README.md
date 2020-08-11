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
