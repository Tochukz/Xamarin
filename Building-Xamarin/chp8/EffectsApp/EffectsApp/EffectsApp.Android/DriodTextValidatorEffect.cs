using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using EffectsApp;
using EffectsApp.Droid;

[assembly: ResolutionGroupName("EffectsApp")]
[assembly: ExportEffect(typeof(DriodTextValidatorEffect), "TextValidatorEffect")]
namespace EffectsApp.Droid
{
	public class DriodTextValidatorEffect: PlatformEffect
	{
		protected override void OnAttached()
		{
			Validate();
		}

		protected override void OnDetached()
		{
			// throw new NotImplementedException();
		}

		private void Validate()
		{
			Entry entry = Element as Entry;
			EditText view = Control as EditText;
			TextValidatorEffect effect = (TextValidatorEffect)Element.Effects.FirstOrDefault(eff => eff is TextValidatorEffect);

			int x = 10;

			if (entry.Text.Length > effect.MaxLength)
			{
				view.SetBackgroundColor(Color.Maroon.ToAndroid());
			}
			else
			{
				view.SetBackgroundColor(Color.Lime.ToAndroid());
			}
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);
			if (args.PropertyName == "Text")
			{
				Validate();
			}
		}
	}
}