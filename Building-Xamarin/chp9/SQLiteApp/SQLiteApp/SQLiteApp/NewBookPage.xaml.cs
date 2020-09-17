using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLiteApp.Models;

namespace SQLiteApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookPage : ContentPage
	{
		public NewBookPage()
		{
			InitializeComponent();
			this.BindingContext = new Book();
		}

		async void CreateBook(object sender, EventArgs args)
		{
			Book book = (Book)BindingContext;
			book.CreatedAt = DateTime.UtcNow;
			await App.Database.SaveBookAsync(book);
			await Navigation.PopAsync();
		}
	}
}