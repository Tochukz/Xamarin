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
					DisplayAlert("Socket Error", $"Error: {sender2.ToString()}", "OK");
					Debug.WriteLine($"Error: {sender2} {sender2.ToString()}");
				};
				client.OnReconnectFailed += (sender3, evnt) =>
				{
					DisplayAlert("Socket Connection Failed", $"Connection Error: {sender3.ToString()}", "OK");
					Debug.WriteLine($"Connection Failed: {sender3} {sender3.ToString()}");
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
			Debug.WriteLine($"Pong: {message}");
			PongLabel.Text = $"Pong: {message}";
		}

		private async void PingServer(object sender, EventArgs e)
		{
			if (SocketClient == null || SocketClient.Disconnected)
			{
				await DisplayAlert("Socket Error", "SocketClient is not ready", "OK");
				return;
			}
		    await SocketClient.EmitAsync("pingMsg", PingEntry.Text);
			Debug.WriteLine($"Pinged: {PingEntry.Text}");
			PingEntry.Text = "";
		}
	}
}
