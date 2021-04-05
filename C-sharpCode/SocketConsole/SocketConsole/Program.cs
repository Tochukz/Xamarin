using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;

namespace SocketConsole
{
	class Program
	{
		static SocketIO Client;

		static void Main(string[] args)
		{
			Console.WriteLine("Trying out Socket Client \nType your message any time to ping.");

			SocketIOOptions options = new SocketIOOptions { ConnectionTimeout = new TimeSpan(0, 2, 30) };
			string url = "http://127.0.0.1:8084";
			Client = new SocketIO(url, options);

			SetupListeners();

			string input = Console.ReadLine();
			while (input != "exit")
			{
				PingServer(input);
				input = Console.ReadLine();				
			}

			Console.Write("Program Ends! \n Good Bye!");
		}

		private static async void PingServer(string message)
		{
			await Client.EmitAsync("pingMsg", message);
		}

		private static async void SetupListeners()
		{
			try
			{
				
				Client.On("FromAPI", response =>
				{
					string temp = response.GetValue<string>();
					Console.WriteLine($"Temperature: {temp} \u00B0C");					
				});
				Client.OnConnected += (sender1, evt) =>
				{
					Console.WriteLine("Connected!");				
				};
				Client.OnError += (sender2, ev) =>
				{
					Console.WriteLine($"Error: {sender2} {sender2.ToString()}");
				};
				Client.On("pongMsg", response =>
				{
					string msg = response.GetValue<string>();
					Console.WriteLine($"Pong ${msg}");
				});
				await Client.ConnectAsync();
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Error {exception.Message} | {exception.InnerException.Message} |{exception.Source} | {exception.StackTrace}");
			}
		}
	}
}
