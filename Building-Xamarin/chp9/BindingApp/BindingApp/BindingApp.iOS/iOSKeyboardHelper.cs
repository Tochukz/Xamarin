using UIKit;
using BindingApp.iOS;
using Xamarin.Forms;

/* This annotation registers this class with the DependencyService. 
 * The dependency service will use this class when ever object that is a type of the IKeyboardHelper is sort on this platform.
 */
[assembly: Dependency(typeof(iOSKeyboardHelper))]
namespace BindingApp.iOS
{
	public class iOSKeyboardHelper: IKeyboardHelper
	{
		public void HideKeyboard()
		{
			UIApplication.SharedApplication.KeyWindow.EndEditing(true);
		}
	}
}