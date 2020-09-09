using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using EffectsApp.iOS;
using System.ComponentModel;

[assembly: ResolutionGroupName("EffectsApp")]
[assembly: ExportEffect(typeof(IOSTextValidatorEffect), "TextValidatorEffect")]
namespace EffectsApp.iOS
{
	class IOSTextValidatorEffect: PlatformEffect
	{
		protected override void OnAttached()
		{
			Validate();
		}

		protected override void OnDetached()
		{
			
		}

		private void Validate()
		{
			Entry entry = Element as Entry;
			UITextField view = Control as UITextField;
			TextValidatorEffect effect = (TextValidatorEffect)Element.Effects.FirstOrDefault(eff => eff is TextValidatorEffect);

			if (entry.Text.Length > effect.MaxLength)
			{
				view.BackgroundColor = Color.Maroon.ToUIColor();
			}
			else
			{
				view.BackgroundColor = Color.Lime.ToUIColor();
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