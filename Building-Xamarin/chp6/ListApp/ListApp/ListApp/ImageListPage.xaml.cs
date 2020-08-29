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
	public partial class ImageListPage : ContentPage
	{
		public ImageListPage()
		{
			InitializeComponent();

			List<Book> Books = new List<Book>
			{
				new Book { Title = "Advanced C#", Description = "Getting Started with Advanced C#", ImgSrc = "img1.jpg"},
				new Book { Title = "PHP 7", Description = "PHP 7 Zend Certification Study Guide", ImgSrc = "img2.jpg"},
				new Book { Title = "JavaScript Next", Description = "JavaScript Next", ImgSrc = "img3.jpg"}
			};

			BookList.ItemsSource = Books;
		}

		protected async void BookListItemTapped(object sender, ItemTappedEventArgs e)
		{
			Book book = (Book)e.Item;
			await DisplayAlert("Book Picked", $"{book.Title} was tapped.", "OK");
			((ListView)sender).SelectedItem = null;
		}
	}
}