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
	public partial class GroupedListPage : ContentPage
	{
		public GroupedListPage()
		{
			InitializeComponent();
			
			List<Book> JsBookList = new List<Book>
			{
				new Book { Title = "Practical Node.js", Description = "Practical Node.js, with Express.js and Koa", Price = 79.99},
				new Book { Title = "Pro MERN Stack", Description = "MongoDB, EXpress.js, React and Node.js", Price = 109.09 },
				new Book { Title = "Pro Vue.JS", Description = "Pro Vue.js, with Vuex", Price = 79.99},
				new Book { Title = "Getting Started with Vue.js", Description = "Vue2, with Testing", Price = 95.09 },
				new Book { Title = "Pro Angular 6", Description = "Angular frombeginner to pro", Price = 89.99},
				new Book { Title = "Leaning React", Description = "Learning React.js", Price = 109.09 },
				new Book { Title = "Pro Express.JS", Description = "Pro Express.js with Koa and Sail", Price = 69.99}
			};
			List<Book> DotNetList = new List<Book>
			{
				new Book { Title = "Applied ASP.NET in Context", Description = "ASP.NET Webform and MVC3", Price = 120.55},
				new Book { Title = "C# Programmer Study Guide", Description = "The C# Programmer studyc guide with C#, Exam: 70-483", Price = 105.65},
				new Book { Title = "Pro ASP.NET Core 2.0", Description = "Pro ASP.NET Core 2.0 with Entity Framework", Price = 120.55},
				new Book { Title = "ASP.NET 4.0", Description = "ASP.NET 4.0, Webforms", Price = 105.65},
				new Book { Title = "Illustrative C#", Description = "Illustrative C#", Price = 120.55}
			};
			List<Book> PHPBookList = new List<Book>
			{
				new Book { Title = "Zend PHP7 Study Guide", Description = "Zend Certification PHP7 Study Guide", Price = 78.10},
				new Book { Title = "Lravel Up and Running", Description = "Laravel UP and Running", Price = 70.65},
				new Book { Title = "Design Pertterns", Description = "Design Patterns in Laravel and PHP", Price = 99.99}
			};

			Group JsGroup = new Group("JavaScript", JsBookList);
			Group dotNetGroup  = new Group("Dot Net", DotNetList);
			Group PHPGroup = new Group("PHP", PHPBookList);

			List<Group> bookList = new List<Group> { JsGroup, dotNetGroup , PHPGroup };

			BookList.ItemsSource = bookList;
		}

		private async void BookListItemTapped(object sender, ItemTappedEventArgs e)
		{			
			Book book = (Book)e.Item;
			await DisplayAlert("Book Tapped", $"", "OK");
			((ListView)sender).SelectedItem = null;
		}
	}
}