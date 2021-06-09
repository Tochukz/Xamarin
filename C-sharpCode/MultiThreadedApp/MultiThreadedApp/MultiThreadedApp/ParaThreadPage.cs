using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Xamarin.Forms;

namespace MultiThreadedApp
{
	/**
	 * Working with Parameterized thread 
	 * Parameterized threads uses ParameterizedThreadStart delegate to pass argument to the method that handles the thread
	 */
	public class ParaThreadPage : ContentPage
	{
		private Label ParameterizedLabel;

		public ParaThreadPage()
		{
			Label headerLabel = new Label { Text = "Parameterized Threads", TextColor = Color.Navy, FontSize = 30 };
			Label footerLabel = new Label { Text = DateTime.Now.ToString(), FontSize = 20 };
			ParameterizedLabel = new Label { Text = "Label for parameterized thread" };
			Content = new StackLayout
			{
				Children = {
					headerLabel,
					ParameterizedLabel,
					footerLabel,
				}
			};
			Thread parameterizedThread = new Thread(new ParameterizedThreadStart(ParameterThread));
			parameterizedThread.Start(2500);
		}

		private void ParameterThread(object maximum)
		{
			int max = (int)maximum;
			for (int i = 0; i < max; i ++)
			{
				ParameterizedLabel.Text = $"Parametherized thread has run {i + 1} times ";
			}
		}
	}
}