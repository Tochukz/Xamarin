using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TriggersApp
{
	/**
	 * This class demonstrates the implementation of an attached property
	 * An attached proprty is a binable proprty that can be appiled to object of a different class from the class that defined the property.
	 */
	class MyAttachable: BindableObject
	{
		public static readonly BindableProperty HasShadowProperty = BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(MyAttachable), false);
		
		public static bool GetHasShadow(BindableObject view)
		{
			return (bool)view.GetValue(HasShadowProperty);
		}

		public static void SetHasShadow(BindableObject view, bool value)
		{
			view.SetValue(HasShadowProperty, value);
		}	
	}
}
