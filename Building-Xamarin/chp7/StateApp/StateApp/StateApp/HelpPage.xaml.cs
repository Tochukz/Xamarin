using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StateApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpPage : ContentPage
	{
		public static readonly BindableProperty AppDetailsProperty = BindableProperty.Create("AppDetails", typeof(Dictionary<string, string>), typeof(HelpPage));

		public static readonly BindableProperty AppNameProperty = BindableProperty.Create("AppName", typeof(string), typeof(HelpPage), "No Name");

		public static readonly BindableProperty AppVersionProperty = BindableProperty.Create("AppVersion", typeof(string), typeof(HelpPage), "x.x.x");

		public static readonly BindableProperty AppCreatorProperty = BindableProperty.Create("AppCreator", typeof(string), typeof(HelpPage), "Developer Guy");

		public Dictionary<string, string> AppDetails
		{
			get => (Dictionary<string, string>) GetValue(AppDetailsProperty);
			set => SetValue(AppDetailsProperty, value);
		}

		public string AppName
		{
			get => (string) GetValue(AppNameProperty);
			set => SetValue(AppNameProperty, value);
		}

		public string AppVersion
		{
			get { return (string) GetValue(AppVersionProperty); }
			set { SetValue(AppVersionProperty, value);  }
		}

		public string AppCreator
		{
			get { return (string)GetValue(AppCreatorProperty); }
			set { SetValue(AppCreatorProperty, value); }
		}

		public HelpPage()
		{
			InitializeComponent();
			Dictionary<string, object>  AppProperties = (Dictionary<string, object>)  Application.Current.Properties;
			Dictionary<string, string> Properties = new Dictionary<string, string>();
			foreach(KeyValuePair<string, object> item in AppProperties)
			{
				Properties[item.Key] = (string)item.Value;
			}
			AppDetails = Properties;

			AppName = (string) AppDetails["AppName"];
			AppVersion = (string) AppDetails["AppVersion"];
			AppCreator = (string) AppDetails["AppCreator"];
		}
	}
}