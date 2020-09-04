using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StateApp.Models;

namespace StateApp
{
	
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage
	{
		public static readonly BindableProperty UserStateProperty = BindableProperty.Create("UserState", typeof(User), typeof(UserPage));
		
		public User UserState
		{
			set => SetValue(UserStateProperty, value);
			get => (User)GetValue(UserStateProperty);
		}

		public UserPage(User user)
		{
			InitializeComponent();
		    UserState = user;		
		}
	}
}