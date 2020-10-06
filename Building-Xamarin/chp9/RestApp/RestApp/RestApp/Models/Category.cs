using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Models
{
	class Category
	{
		public int categoryId { set; get; }

		public string category { set; get; }

		public string createdAt { set; get; }

		public string updatedAt { set; get; }

		public string deletedAt { set; get; }
	}
}
