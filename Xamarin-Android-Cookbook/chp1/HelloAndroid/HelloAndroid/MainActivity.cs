using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true), Register("xyz.tochukwu.MainActivity")]
    public class MainActivity : AppCompatActivity
    {
		
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //SupportActionBar.Title = "My App";

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button changeLayoutBtn = FindViewById<Button>(Resource.Id.changeLayoutBtn);
            Button changeActivityBtn = FindViewById<Button>(Resource.Id.changeActivityBtn);

            changeActivityBtn.Click += ChangeActivity;
            changeLayoutBtn.Click += ChangeLayout;
        }

        /*
		protected override void OnCreate(Bundle bundle)
		{
            base.OnCreate(bundle);
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            Button button = new Button(this);
            button.Text = "Hello Android";

            layout.AddView(button, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

            // Using Layout written in Code 
            //SetContentView(layout);

            // Using Layout written in XML 
            SetContentView(Resource.Layout.hello);
		}
        */

		public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);            

            return true;           
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
                         
            switch(item.ItemId)
			{
                case Resource.Id.action_settings:
                    Console.WriteLine($"action_settings: {Resource.Id.action_settings}");
                    return true;
				case Resource.Id.action_refresh:
					Console.WriteLine($"action_refresh: {Resource.Id.action_refresh}");
					return true;
				case Resource.Id.action_search:
					Console.WriteLine($"action_search: {Resource.Id.action_search}");
					return true;
			}

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }       

        public void ChangeLayout(object sender, EventArgs args)
		{
            SetContentView(Resource.Layout.hello);
		}

        public void ChangeActivity(object sender, EventArgs args)
        {
            Intent intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }
    }
}
