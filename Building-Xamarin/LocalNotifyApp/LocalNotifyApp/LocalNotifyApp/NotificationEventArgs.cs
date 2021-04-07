using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNotifyApp
{
	public class NotificationEventArgs: EventArgs
	{
		public string Title { set; get; }

		public string Message { set; get; }
	}
}
