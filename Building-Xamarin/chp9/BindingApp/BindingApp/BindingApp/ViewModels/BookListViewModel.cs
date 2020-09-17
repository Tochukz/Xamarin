using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using BindingApp.Models;

namespace BindingApp.ViewModels
{
	class BookListViewModel
	{
		ObservableCollection<ObservableBook> bookList;

	    public BookListViewModel()
		{
			BookList = new ObservableCollection<ObservableBook>
			{
				new ObservableBook { BookId = 1, Title = "Pro Express.js", Description = "Express.js from Beginner to Pro with MongoDB" },
				new ObservableBook { BookId = 2, Title = "ASP.NET 4 in Context", Description = "ASP.NET Webform 4 and MVC 3"},
				new ObservableBook { BookId = 3, Title = "Beginning C++", Description = "Begining C++"}
			};
		}

		public ObservableCollection<ObservableBook> BookList
		{
			set
			{
				if (value != bookList)
				{
					bookList = value;
				}
			}
			get => bookList;
		}
	}
}
