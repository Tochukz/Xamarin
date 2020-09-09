using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EffectsApp
{
	public class TextValidatorEffect: RoutingEffect
	{
		public int MaxLength { set; get; } = 5;
		public TextValidatorEffect(): base("EffectsApp.TextValidatorEffect")
		{

		}
	}
}
