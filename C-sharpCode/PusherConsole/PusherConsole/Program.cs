using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PusherClient;

namespace PusherConsole
{
	class Program
	{
		private static Pusher PsClient;

		private static PresenceChannel PresenceChannel;

		static void Main(string[] args)
		{
			Console.WriteLine("Trying out Pusher Client");

			Task connectResult = Task.Run(() => InitPusher());
			
			Console.WriteLine($"Status: {connectResult.Status.ToString()},  ID: {connectResult.Id.ToString()}");
			Task.WaitAll(connectResult);

			Console.ReadLine();
		}

		static async void InitPusher()
		{			
			string appKey = "xxxxxxxxxxxxxxxxxxxxx";			
			string appCluster = "ap2";
			string channel = "my-channel";

			PsClient = new Pusher(appKey, new PusherOptions { Cluster = appCluster, Encrypted = true });

			PsClient.Connected += OnConnected;
			PsClient.Disconnected += OnDisconnected;
			PsClient.ConnectionStateChanged += OnConnectionStateChanged;
			PsClient.Error += OnError;						
			
		    Channel myChannel = await PsClient.SubscribeAsync(channel);
			myChannel.Subscribed += OnSubScribed;

			/* Handling Incoming Messages using various method Overloads */
			myChannel.Bind("my-event", (dynamic listener) =>
			{
				Console.WriteLine($"New Message: {listener.data}");
			});
			myChannel.Bind("my-event", (string data) =>
			{
				Console.WriteLine($"New Data: {data}");
			});
			myChannel.Bind("my-event", (PusherEvent e) => {			
				Console.WriteLine($"Event Name: {e.EventName}, Data {e.Data}");				
			});

			myChannel.BindAll(HandleAllEvents1);
			myChannel.BindAll(HandleAllEvents2);

			await PsClient.ConnectAsync();


		}

		static void OnConnected(object sender) 
		{
			Console.WriteLine("Connected!");
		}

		static void OnDisconnected(object sender)
		{
			Console.WriteLine("Disconnected!");
		}

		static void OnSubScribed(object sender)
		{
			Console.WriteLine("Subscribed!");
		}
		static void HandleAllEvents1(string eventName, dynamic listener)
		{
			Console.WriteLine($"Dynamic: Event Name: {eventName}, Data: {listener.data}");
		}

		static void HandleAllEvents2(string eventName, PusherEvent e)
		{
			Console.WriteLine($"PusherEvent: Event Name: {eventName} Data: {e.Data}");
		}

		

		static void OnConnectionStateChanged(object sender, ConnectionState state)
		{
			Console.WriteLine($"Connection state: {state}");
		}

		static void OnError(object sender, PusherException error)
		{
			Console.WriteLine($"Pusher Error: {error}");
		}

		/* Output **
	
		  Trying out Pusher Client
          Status: WaitingToRun,  ID: 1
          Connection state: Initialized
          Connected!
          Subscribed!
          New Data: {"event":"my-event","data":"{\"message\": \"Hello Tochukwu\"}","channel":"k-lab-staging"}
          Dynamic: Event Name: my-event, Data: {"message": "Hello Tochukwu"}
          New Message: {"message": "Hello Tochukwu"}
          PusherEvent: Event Name: my-event Data: {"message": "Hello Tochukwu"}
          Event Name: my-event, Data {"message": "Hello Tochukwu"}

		 */
	}
}
