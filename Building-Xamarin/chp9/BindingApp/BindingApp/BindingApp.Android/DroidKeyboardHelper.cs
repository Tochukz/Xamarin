using Android.App;
using Android.Content;
using Android.Views.InputMethods;
using Xamarin.Forms;

using BindingApp.Droid;

/* This annotation registers this class with the DependencyService. 
 * The dependency service will use this class when ever object that is a type of the IKeyboardHelper is sort on this platform.
 */
[assembly: Dependency(typeof(DroidKeyboardHelper))]
namespace BindingApp.Droid
{
	class DroidKeyboardHelper: IKeyboardHelper
	{
		public void HideKeyboard()
		{
			var context = Android.App.Application.Context;
			InputMethodManager inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;

			if (inputMethodManager != null & context is Activity)
			{
				Activity activity = context as Activity;
				var token = activity.CurrentFocus?.WindowToken;
				inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

				activity.Window.DecorView.ClearFocus();
			}
		}
	}
}