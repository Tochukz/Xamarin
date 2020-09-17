using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SQLiteApp.Models;

namespace SQLiteApp.Data
{
	public class BookDatabase
	{
		readonly SQLiteAsyncConnection _database;

		public BookDatabase(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Book>().Wait();
		}

		public Task<List<Book>> GetBooksAsync()
		{
			return _database.Table<Book>().ToListAsync();
		}

		public Task<Book> GetBookAsync(int bookId)
		{
			return _database.Table<Book>().Where(book => book.BookId == bookId).FirstOrDefaultAsync();
		}

		public Task<int> SaveBookAsync(Book book)
		{
			if (book.BookId != 0)
			{
				return _database.UpdateAsync(book);
			}
			else
			{
				return _database.InsertAsync(book);
			}
		}

		public Task<int> DeleteBookAsync(Book book)
		{
			return _database.DeleteAsync(book);
		}

	}
}
