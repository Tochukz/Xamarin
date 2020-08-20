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
	public partial class FeedbackPage : ContentPage
	{
		const string placeHolderText = "Type your message here";

		public FeedbackPage()
		{
			InitializeComponent();
			Feedback.Text = placeHolderText;
		}		

		// This function is no longer necessary since Editor element now implements Placeholder the property.
		void HandleFeedback(object sender, FocusEventArgs args)
		{
			if (Feedback.Text == placeHolderText)
			{
				Feedback.Text = string.Empty;
				return;
			}
			if (Feedback.Text == string.Empty)
			{
				Feedback.Text = placeHolderText;
				return;
			}
		}

	}
}