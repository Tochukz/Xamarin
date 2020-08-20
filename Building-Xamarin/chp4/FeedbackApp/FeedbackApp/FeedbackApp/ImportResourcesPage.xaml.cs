using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedbackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportResourcesPage : ContentPage
	{
		public ImportResourcesPage()
		{
			InitializeComponent();

			Feedback.Text = (string)Resources["FeedbackPlaceholder"];
			Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
			Subject.Text = string.Empty;
			Resources["PageBgColor"] = Resources["PageBgColorNoSubject"];
			Resources["BtSubjectColor"] = Resources["BtInactiveColor"];
		}

		void HandleSubject(object sender, FocusEventArgs e)
		{
			if (Subject.Text == string.Empty)
			{
				Resources["PageBgColor"] = Resources["PageBgColorNoSubject"];
				Resources["BtSubmitColor"] = Resources["BtInactiveColor"];
			}
			else
			{
				Resources["PageBgColor"] = Resources["PageBgColorWithSubject"];
				Resources["BtSubmitColor"] = Resources["BtSubmitActiveColor"];
			}
		}

		// This function is no longer necessary since Editor element now implements Placeholder the property.
		void HandleFeedback(object sender, FocusEventArgs args)
		{
			var placeHolderText = (string)Resources["FeedbackPlaceholder"];
			if (Feedback.Text == placeHolderText)
			{
				Feedback.Text = string.Empty;
				Feedback.TextColor = (Color)Resources["InputTextColor"];
				return;
			}
			if (Feedback.Text == string.Empty)
			{
				Feedback.Text = placeHolderText;
				Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
				return;
			}
		}
	}

}