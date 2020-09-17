using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;
using BindingApp.Models;
using BindingApp.ViewModels;

namespace BindingApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditableObservableBookListPage : ContentPage
	{
		/* Book can be added or deleted from the Observable book collection 
		 * Also exiting book can be edited and updated.
		 * This is a combination of an Observable collection having Models that impliments the INotifyPropertyChanged inteface.
		 */

		ObservableCollection<ObservableBook> bookList;

		public EditableObservableBookListPage()
		{
			InitializeComponent();

			BookListViewModel bookListViewModel = new BookListViewModel();
			bookList = bookListViewModel.BookList;
			this.BindingContext = bookList;
		}

		private void AddBook(object sender, EventArgs args)
		{
			int bookId = bookList.Count();
			string title = TitleEntry.Text;
			string description = DescriptionEditor.Text;
			
			ObservableBook newBook = new ObservableBook { BookId = bookId, Title = title, Description = description };
			bookList.Add(newBook);
			TitleEntry.Text = "";
			DescriptionEditor.Text = "";
			DependencyService.Get<IKeyboardHelper>().HideKeyboard();
		}

		private void EditBook(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			int bookId = (int)button.CommandParameter;
			ObservableBook book = bookList.First(bk => bk.BookId == bookId);
			UpdateTitleEntry.Text = book.Title;
			UpdateDescriptionEditor.Text = book.Description;
			BookIdLabel.Text = bookId.ToString();			
		}

		private async void UpdateBook(object sender, EventArgs args)
		{
			int bookId;
			if (!int.TryParse(BookIdLabel.Text, out bookId))
			{
				await DisplayAlert("No Book Selected", "Please select a book to edit", "OK");
				return;
			}

			string newTitle = UpdateTitleEntry.Text;
			string newDescription = UpdateDescriptionEditor.Text;
			foreach (ObservableBook book in bookList)
			{
				if (book.BookId == bookId)
				{
					book.Title = newTitle;
					book.Description = newDescription;
					break;
				}
			}

		    BookIdLabel.Text = "";
			UpdateTitleEntry.Text = "";
			UpdateDescriptionEditor.Text = "";

			DependencyService.Get<IKeyboardHelper>().HideKeyboard();
		}

		private void DeleteBook(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			int bookId = (int)button.CommandParameter;
			ObservableBook bookToDelete = bookList.First(book => book.BookId == bookId);
			bookList.Remove(bookToDelete);
		}
	}
}