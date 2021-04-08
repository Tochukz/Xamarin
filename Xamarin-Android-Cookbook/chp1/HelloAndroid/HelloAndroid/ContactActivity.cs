using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;

namespace HelloAndroid
{
	[Activity(Label = "Contact", ParentActivity = typeof(MainActivity)), ] // MetaData("android.support.PARENT_ACTIVITY", Value ="xyz.tochukwu.MainActivity")
	public class ContactActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			//SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			TextView textView = new TextView(this) { Text = "Contact us at 099 247 3483" };
			LinearLayout layout = new LinearLayout(this);
			layout.AddView(textView, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

			SetContentView(layout);
		}
	}
}