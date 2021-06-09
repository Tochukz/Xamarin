using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Xamarin.Forms;

namespace MultiThreadedApp
{
	/* Foreground versus Background threads.  
	 * By default threads are foreground thread
	 * The Main thread will terminate application and not wait for any remaning background thread but would wait for a foreground thread to complete
	 */
	public class ForeAndBackThreadPage : ContentPage
	{

		private Label ForegroundLabel;
		private Label BackgroundLabel;

		public ForeAndBackThreadPage()
		{
			Label headerLabel = new Label { Text = "Forground Vs Background Threads", TextColor = Color.Navy, FontSize = 30 };
			Label footerLabel = new Label { Text = DateTime.Now.ToString(), FontSize = 20 };
			ForegroundLabel = new Label { Text = "Label for foreground thread" };
			BackgroundLabel = new Label { Text = "Label for background thread" };
			Content = new StackLayout
			{
				Children = {
					headerLabel,
					ForegroundLabel,
					BackgroundLabel,
					footerLabel
				}
			};

			Thread foregroundThread = new Thread(ForegroundThread);
			foregroundThread.Start();

			Thread backgroundThread = new Thread(BackgroundThread);
			backgroundThread.IsBackground = true; // Setting the Background property to true makes the thread a background thread, otherwise it wil be a foreground thread by default
			backgroundThread.Start(); // Main thread will not wait for a background thread to finish before it terminates the application.
		}

		private void ForegroundThread()
		{
			for(int i = 0; i < 1000; i++)
			{
				ForegroundLabel.Text = $"Foreground thread has run {i + 1} times";
			}
		}

		private void BackgroundThread()
		{
			for (int i = 0; i < 100000; i++)
			{
				try
				{
					// ForegroundLabel.Text = $"Background thread has run {i + 1} times"; // This will throw an exception taht can not be caught by the catch block because the Main method will terminate the application before the background thread completes.
					Console.WriteLine($"Background thread has run {i + 1} times");
				} 
				catch(Exception ex)
				{
					DisplayAlert("Error", ex.Message, "OK");
					return;
				}
				
			}
		}
	}
}