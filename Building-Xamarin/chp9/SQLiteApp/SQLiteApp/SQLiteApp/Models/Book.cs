using System;
using SQLite;

namespace SQLiteApp.Models
{
	public class Book
	{
		[PrimaryKey, AutoIncrement]
		public int BookId { set; get; }

		public string Title { set; get; }

		public string Description { set; get; }

		public DateTime CreatedAt { set; get; }

	}
}
