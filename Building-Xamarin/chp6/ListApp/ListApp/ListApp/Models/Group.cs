using System;
using System.Collections.Generic;
using System.Text;
using ListApp.Models;

namespace ListApp
{
	class Group: List<Book>
	{
		public string Key { set; get; }

		public Group(string key, List<Book> Books)
		{
			Key = key;

			foreach(Book book in Books)
			{
				this.Add(book);
			}
		}

	}
}
