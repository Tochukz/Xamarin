using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace TemplateApp.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardView : ContentView
	{
		public CardView()
		{
			InitializeComponent();
		}

		public static readonly BindableProperty CardTitleProp = BindableProperty.Create("CardTitle", typeof(string), typeof(CardView), "Default Title");
		public static readonly BindableProperty CardDescriptionProp = BindableProperty.Create("CardDescription", typeof(string), typeof(CardView), "Default Description");
		public static readonly BindableProperty IconImageSourceProp = BindableProperty.Create("IconImageSource", typeof(ImageSource), typeof(CardView));
		public static readonly BindableProperty IconBackgroundColorProp = BindableProperty.Create("IconBackgroundColor", typeof(Color), typeof(CardView), Color.Green);
		public static readonly BindableProperty BorderColorProp = BindableProperty.Create("BorderColor", typeof(Color), typeof(CardView), Color.Blue);
		public static readonly BindableProperty CardColorProp = BindableProperty.Create("CardColor", typeof(Color), typeof(CardView), Color.Yellow);



		public string CardTitle
		{
			get => (string)GetValue(CardView.CardTitleProp);
			set => SetValue(CardView.CardTitleProp, value);
		}

		public string CardDescription
		{
			get => (string)GetValue(CardView.CardDescriptionProp);
			set => SetValue(CardView.CardDescriptionProp, value);
		}

		public ImageSource IconImageSource
		{
			get => (ImageSource)GetValue(CardView.IconImageSourceProp);
			set => SetValue(CardView.IconImageSourceProp, value);
		}

		public Color IconBackgroundColor
		{
			get => (Color)GetValue(CardView.IconBackgroundColorProp);
			set => SetValue(CardView.IconBackgroundColorProp, value);
		}

		public Color BorderColor
		{
			get => (Color)GetValue(CardView.BorderColorProp);
			set => SetValue(CardView.BorderColorProp, value);
		}
			
		public Color CardColor
		{
			get => (Color)GetValue(CardView.CardColorProp);
			set => SetValue(CardView.CardColorProp, value);
		}
	}

}