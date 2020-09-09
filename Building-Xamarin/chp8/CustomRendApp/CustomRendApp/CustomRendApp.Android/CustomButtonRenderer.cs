//using Android.App;

//using Android.OS;
//using Android.Runtime;
//using Android.Views;

using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CustomRendApp.Controls;
using CustomRendApp.Droid;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomRendApp.Droid
{
	class CustomButtonRenderer: ButtonRenderer
	{
		public CustomButtonRenderer(Context context): base(context)
		{
			AutoPackage = false;
		}		

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			// Set the initial control properties values here

			// You can also replace the entire control with your own customized platform-specific control here

			// You can replace the entire element by calling the SetNativeControl() method as shown below
			// SetNativeControl(new MyCustomControl());  

			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.LimeGreen);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			// This is where you can do data binding 
			// You assign Control properties from their corresponding Element properties.
		}
		
		/**
		 * Useful properties:
		 *  - Control: A reference to the platform specific view. In this case, it references an andrio Button control
		 *  - Element: A refernece to the Xamarin.Forms subclassed element.
		 */ 
	}
}