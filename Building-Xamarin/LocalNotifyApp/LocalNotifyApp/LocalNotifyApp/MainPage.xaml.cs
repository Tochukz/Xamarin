using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocalNotifyApp
{
	public partial class MainPage : ContentPage
	{
		INotificationManager NotificationManager;

		int NotificationNumber = 0;

		public MainPage()
		{
			InitializeComponent();

			NotificationManager = DependencyService.Get<INotificationManager>();
			NotificationManager.NotificationReceived += (sender, eventArgs) =>
			{
				NotificationEventArgs eventData = (NotificationEventArgs)eventArgs;
				ShowNotification(eventData.Title, eventData.Message);
			};
		}

		private void TrgiggerNotification(object sender, EventArgs args)
		{
			NotificationNumber++;
			string title = $"Local Notification #{NotificationNumber}";
			string message = $"YOu have now receicved {NotificationNumber} notifications";
			NotificationManager.SendNotification(title, message);
		}

		private void scheduleNotification(object sender, EventArgs args)
		{
			NotificationNumber++;
			string title = $"Local Notitifaction #{NotificationNumber}";
			string message = $"You have not received {NotificationNumber} notifications";
			double seconds = timeStepper.Value;		
			NotificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(seconds));
		}

		private void ShowNotification(string title, string message)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				Label label = new Label
				{
					Text = $"Notification - \nTitle: {title } \nMessage: {message}"
				};
				mainStackLayout.Children.Add(label);
			});
		}
	}
}
