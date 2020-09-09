using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EffectsApp
{
	class TextValidationEffect2
	{
		public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(TextValidationEffect2), 5, propertyChanged: MaxLengthPropertyChanged);

		public static int GetMaxLength(BindableObject view)
		{
			return (int)view.GetValue(MaxLengthProperty);
		}

		public static void SetMaxLength(BindableObject view, int value)
		{
			view.SetValue(MaxLengthProperty, value);
		}

		private static void MaxLengthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
		   /*	
		  	View view = bindable as View; 
			if (view == null)
			{
				return;
			}
		  */
			// using pattern matching instead of the syntax above
			if (!(bindable is View view))
			{
				return;
			}

			TextValidatorEffect effect = (TextValidatorEffect)view.Effects.FirstOrDefault(eff => eff is TextValidatorEffect);
			if (effect != null)
			{
				view.Effects.Remove(effect);
			}
			else
			{
				effect = new TextValidatorEffect
				{
					MaxLength = GetMaxLength(view)
				};
			    view.Effects.Add(effect);
			}

		}
	}
}
