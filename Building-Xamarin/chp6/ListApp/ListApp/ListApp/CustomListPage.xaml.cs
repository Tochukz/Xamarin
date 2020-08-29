using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ListApp.Models;

namespace ListApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomListPage : ContentPage
	{
		public CustomListPage()
		{
			InitializeComponent();

			List<Book> Books = new List<Book>
			{
				new Book { Title = "Advanced C#", Description = "Getting Started with Advanced C#", ImgSrc = "Advanced_C.jpg", Price = 99.4},
				new Book { Title = "PHP 7", Description = "PHP 7 Zend Certification Study Guide", ImgSrc = "PHP_7.jpg", Price = 89.9 },
				new Book { Title = "JavaScript Next", Description = "JavaScript Next", ImgSrc = "JavaScript_Next.jpg", Price = 79.5}
			};

			BookList.ItemsSource = Books;
		}

		protected async void BookListItemTapped(object sender, ItemTappedEventArgs e)
		{
			Book book = (Book)e.Item;
			await DisplayAlert("Book Picked", $"{book.Title} was tapped.", "OK");
			((ListView)sender).SelectedItem = null;
		}

		private async void AddCartClicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			Book book = (Book)button.CommandParameter;
			await DisplayAlert("Clicked", $"{book.Title} button was clicked", "OK");
		}

		private async void MoreClicked(object sender, EventArgs e)
		{
			MenuItem menu = (MenuItem)sender;
			Book book = (Book)(menu.CommandParameter);
			await DisplayAlert("Clicked", $"Description: {book.Description}", "OK");
		}

		private async void DeleteClicked(object sender, EventArgs e)
		{
			MenuItem menu = (MenuItem)sender;
			Book book = (Book)menu.CommandParameter;
			await DisplayAlert("Clicked", $"Deleting: {book.Title}", "OK");
		}
	}
}