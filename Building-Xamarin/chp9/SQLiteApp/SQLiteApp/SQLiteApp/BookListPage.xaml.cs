using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLiteApp.Models;
using System.Collections.ObjectModel;

namespace SQLiteApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookListPage : ContentPage
	{
		public BookListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			BookListView.ItemsSource = await App.Database.GetBooksAsync();
		}

		async void DeleteBook(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			int bookId = (int)button.CommandParameter;
			Book book = await App.Database.GetBookAsync(bookId);			
			await App.Database.DeleteBookAsync(book);
			BookListView.ItemsSource = await App.Database.GetBooksAsync();
			
		}

		async void ToNewBookPage(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new NewBookPage());
		}
	}
}