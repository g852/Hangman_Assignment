using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Hangman_Assignment
{
	[Activity (Label = "MainActivity", Theme="@android:style/Theme.Holo.Light.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait )]
	public class MainActivity : Activity
	{
		EditText userName;
		ImageView playButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

		
			SetContentView (Resource.Layout.Main);
			userName = FindViewById<EditText> (Resource.Id.editTextInputName);
			playButton = FindViewById<ImageView> (Resource.Id.buttonMainPlay);
			playButton.Click += delegate {
				if (userName.Text != "") {
					Intent i = new Intent(this, typeof(GamePageActivity));
					i.PutExtra("playerName", userName.Text);
					StartActivity(i);
					Finish();
				}
				else if (userName.Text == "") {
					Toast.MakeText(this, "Please Enter Your Name.", ToastLength.Short).Show();
				}

			};
		}
	}
}


