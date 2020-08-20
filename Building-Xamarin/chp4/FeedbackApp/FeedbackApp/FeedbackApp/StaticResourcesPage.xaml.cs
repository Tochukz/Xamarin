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
	public partial class StaticResourcesPage : ContentPage
	{

		public StaticResourcesPage()
		{
			InitializeComponent();
			Feedback.Text = (string)Resources["FeedbackPlaceholder"];
			Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
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