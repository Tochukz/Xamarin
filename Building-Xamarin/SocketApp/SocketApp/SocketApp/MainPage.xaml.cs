using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SocketIOClient;
using System.Diagnostics;

namespace SocketApp
{
	public partial class MainPage : ContentPage
	{
		SocketIO SocketClient;

		public MainPage()
		{
			InitializeComponent();
			
		}		

		protected async override void OnAppearing()
		{
			SocketClient = await MakeSocketConnection();
			SocketClient.On("FromAPI", OnNewTemperature);
			SocketClient.On("pongMsg", OnPong);
			if (SocketClient.Connected)
			{
				StatusLabel.TextColor = Color.Green;
				StatusLabel.Text = "Socket Connected!";
			}
		}

		private async Task<SocketIO> MakeSocketConnection()
		{
			try
			{				
				SocketIOOptions options = new SocketIOOptions { ConnectionTimeout = new TimeSpan(0, 2, 30) };

				string url = "https://api.ojlinks.tochukwu.xyz";
				SocketIO client = new SocketIO(url, options);
				
				client.OnConnected += (sender1, evt) =>
				{
					Debug.WriteLine("Connected!");										
				};
				client.OnError += (sender2, ev) =>
				{
					Debug.WriteLine($"Error: {sender2} {sender2.ToString()}");
				};

				await client.ConnectAsync();
				return client;
			}
			catch (Exception exception)
			{
				Debug.WriteLine("Error", $"{exception.Message} | {exception.InnerException.Message} |{exception.Source} | {exception.StackTrace}", "OK");
				throw exception;
			}
		}

		private void OnNewTemperature(SocketIOResponse response)
		{
			string temp = response.GetValue<string>();
			string tempAndTime = $"{temp}\u00B0F at {DateTime.Now.ToString("HH:mm:ss")}";
			Debug.WriteLine($"New temperature: {tempAndTime}");
			TempLabel.Text = tempAndTime;
		}

		private void OnPong(SocketIOResponse response)
		{
			string message = response.GetValue<string>();
			Debug.WriteLine($"New Pong: {message}");
			PongLabel.Text = message;
		}

		private async void PingServer(object sender, EventArgs e)
		{
		    await SocketClient.EmitAsync("pingMsg", PingEntry.Text);
			Debug.WriteLine($"Pinged: {PingEntry.Text}");
			PingEntry.Text = "";
		}
	}
}
