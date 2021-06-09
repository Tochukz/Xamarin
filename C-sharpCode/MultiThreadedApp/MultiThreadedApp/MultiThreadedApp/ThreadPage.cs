using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Xamarin.Forms;

namespace MultiThreadedApp
{
	public class ThreadPage : ContentPage
	{
		Label FirstLabel;

		public ThreadPage()
		{
			Label headerLabel = new Label { Text = "Threading Demo", TextColor = Color.Green, FontSize = 30};
			Label footerLabel = new Label { Text = DateTime.Now.ToString(), FontSize = 20 };
			FirstLabel = new Label { Text = "First Thread will run here" };
			Content = new StackLayout
			{
				Children = {
					headerLabel,
					FirstLabel,
					footerLabel
				}
			};
			/** Initialize and start new thread in a method */
			//Thread firstThread = new Thread(new ThreadStart(MyFirstThread));
			Thread firstThread = new Thread(MyFirstThread); // Shorthand syntax for initilizing thread
			firstThread.Start();

			firstThread.Join(); // Makes the main thread to wait for the termination of the firstThread
			FirstLabel.Text = "Main Thread changes"; // This does not affect final text as MyFirstThread overrides it. Except if main thread is made to wait by using the thread.Join() state above.
		}

		private void MyFirstThread()
		{
			for(int i = 0; i < 1000; i++)
			{
				//Thread.Sleep(10); // sleep for xmilliseconds // This will throw an error because the Main thread will not wait for a Sleeping foreground thread and will terminate.
				FirstLabel.Text = $"Thread has run {i + 1} times";
			}
		}
	}
}