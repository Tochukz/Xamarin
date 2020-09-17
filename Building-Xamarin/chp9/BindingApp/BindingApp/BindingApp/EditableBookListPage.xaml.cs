using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BindingApp.Models;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditableBookListPage : ContentPage
	{
		/* Each properties of each Book object in the ObservableBook collection can be edited and updated */

		List<ObservableBook> bookList;

		public EditableBookListPage()
		{
			InitializeComponent();

			bookList = new List<ObservableBook>
			{
				new ObservableBook { BookId = 1, Title = "Pro Express.js", Description = "Express.js from Beginner to Pro with MongoDB" },
				new ObservableBook { BookId = 2, Title = "ASP.NET 4 in Context", Description = "ASP.NET Webform 4 and MVC 3"},
				new ObservableBook { BookId = 3, Title = "Beginning C++", Description = "Begining C++"}
			};

			this.BindingContext = bookList;
		}

		private void EditBook(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			int bookId = (int) button.CommandParameter;
			ObservableBook book = bookList.First(bk => bk.BookId == bookId);
			TitleEntry.Text = book.Title;
			DescriptionEditor.Text = book.Description;
			BookIdLabel.Text = bookId.ToString();
		}

		private void UpdateBook(object sender, EventArgs args)
		{
			int bookId = int.Parse(BookIdLabel.Text);
			ObservableBook book = bookList.First(bk => bk.BookId == bookId);
			
			string newTitle = TitleEntry.Text;
			string newDescription = DescriptionEditor.Text;
			book.Title = newTitle;
			book.Description = newDescription;

			TitleEntry.Text = "";
			DescriptionEditor.Text = "";
		}
	}
}