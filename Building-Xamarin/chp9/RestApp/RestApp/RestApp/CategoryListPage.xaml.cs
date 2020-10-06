using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
using RestApp.Models;
using Newtonsoft.Json;

namespace RestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryListPage : ContentPage
	{
		HttpClient httpClient;

		List<Category> categoryList;

		public CategoryListPage()
		{
			InitializeComponent();
						
			httpClient = new HttpClient();
			SetCategories();			
		}

		public async void SetCategories()
		{

			HttpResponseMessage response = await httpClient.GetAsync("https://api.ojlinks.tochukwu.xyz/api/categories");
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();				
				categoryList = JsonConvert.DeserializeObject<List<Category>>(content);
				this.BindingContext = categoryList;

			}
		}
	}
}