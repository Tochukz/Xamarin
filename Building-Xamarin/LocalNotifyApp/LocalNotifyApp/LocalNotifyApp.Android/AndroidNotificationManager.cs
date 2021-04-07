using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
//using Android.Runtime;
//using Android.Views;
// using Android.Widget;
using Xamarin.Forms;
using AndroidApp = Android.App.Application;

//using System.Collections.Generic;
//using System.Linq;/
//using System.Text;

using LocalNotifyApp;

[assembly: Dependency(typeof(LocalNotifyApp.Droid.AndroidNotificationManager))]
namespace LocalNotifyApp.Droid
{
	class AndroidNotificationManager: INotificationManager
	{
		const string ChannelId = "default";
		const string ChannelName = "Default";
		const string ChannelDescription = "The defaulr channel for notitifactions";

		public const string TitleKey = "title";
		public const string MessageKey = "message";

		bool ChannelInitialized = false;
		int MessageId = 0;
		int PendingIntentId = 0;

		NotificationManager Manager;

		public event EventHandler NotificationReceived;

		public static AndroidNotificationManager Instance { get; private set; }

		public AndroidNotificationManager() => Initialize();

		public void Initialize()
		{
			if (Instance ==  null)
			{
				CreateNotificationChannel();
				Instance = this;
			}
		}

		public void SendNotification(string title, string message, DateTime? notifyTime= null)
		{
			if (!ChannelInitialized)
			{
				CreateNotificationChannel();
			}

			if (notifyTime != null)
			{
				Intent intent = new Intent(AndroidApp.Context, typeof(AlarmHandler));
				intent.PutExtra(TitleKey, title);
				intent.PutExtra(MessageKey, message);

				PendingIntent pendingIntent = PendingIntent.GetBroadcast(AndroidApp.Context, PendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);
				long triggerTime = GetNotifyTime(notifyTime.Value);
				AlarmManager alarmManager = AndroidApp.Context.GetSystemService(Context.AlarmService) as AlarmManager;
				alarmManager.Set(AlarmType.RtcWakeup, triggerTime, pendingIntent);
			}
			else
			{
				Show(title, message);
			}
		}

		public void ReceiveNotification(string title, string message)
		{
			NotificationEventArgs args = new NotificationEventArgs
			{
				Title = title,
				Message = message,
			};
			NotificationReceived?.Invoke(null, args);
		}

		public void Show(string title, string message)
		{
			Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
			intent.PutExtra(TitleKey, title);
			intent.PutExtra(MessageKey, message);

			PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, PendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

			NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, ChannelId)
				.SetContentIntent(pendingIntent)
				.SetContentTitle(title)
				.SetContentText(message)
				.SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Drawable.abc_ab_share_pack_mtrl_alpha))
				.SetSmallIcon(Resource.Drawable.abc_ab_share_pack_mtrl_alpha)
				.SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

			Notification notification = builder.Build();
			Manager.Notify(MessageId++, notification);
		}

		void CreateNotificationChannel()
		{
			Manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.O) {
				var channelNewJava = new Java.Lang.String(ChannelName);
				var channel = new NotificationChannel(ChannelId, channelNewJava, NotificationImportance.Default)
				{
					Description = ChannelDescription
				};
				Manager.CreateNotificationChannel(channel);
			}
			ChannelInitialized = true;
		}

		long GetNotifyTime(DateTime notifyTime)
		{
			DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(notifyTime);
			double epochDiff = (new DateTime(1970, 1, 1) - DateTime.MinValue).TotalSeconds;
			long utcAlarmTime = utcTime.AddSeconds(-epochDiff).Ticks / 10000;
			return utcAlarmTime; // milliseconds
		}
	}
}