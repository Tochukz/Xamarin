using System;
using System.Collections.Generic;
using System.Text;

namespace StateApp
{
	class Global
	{
		private Global()
		{
		}

		private static Global _instance;

		public static Global GetInstance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Global();
				}
				return _instance;
			}

		}

		public string HDD { set; get; }

		public string RAM { set; get; }

		public string Screen { set; get; }
	}
}
