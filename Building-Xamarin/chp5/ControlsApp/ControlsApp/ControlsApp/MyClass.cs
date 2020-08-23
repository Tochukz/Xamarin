using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlsApp
{
	class MyClass
	{
		public ICommand MyCommand { protected set; get; }
		public ICommand MyCommandWithArg { protected set; get; }

	    public MyClass()
		{
			/* Creating an action. An action is a delegate that uses methods which no argument and return type of void */
			Action myCommandHandler = MethodHandler;
			MyCommand = new Command(myCommandHandler);

			Action<string> myHandlerWithArg = MethodHandlerWithArg;
			MyCommandWithArg = new Command<string>(myHandlerWithArg);
		}

	    public void MethodHandler()
	    {
			Console.WriteLine("My Command");
	    }

		public void MethodHandlerWithArg(string str)
		{
			Console.WriteLine(str);
		}

	}
}
