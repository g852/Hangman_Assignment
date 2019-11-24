
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Timers;

namespace Hangman_Assignment
{
	[Activity (Label = "Hangman2", Icon = "@drawable/iconimage",  MainLauncher = true, Theme="@android:style/Theme.Black.NoTitleBar.Fullscreen")]			
	public class SplashScreen : Activity
	{
		ImageView splashScreen;
		int timerCount = 0;
		private static System.Timers.Timer alphaTimer;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.SplashScreenLayout);

			splashScreen = FindViewById<ImageView>(Resource.Id.imageViewSplash);
			splashScreen.Alpha = 0;
			alphaTimer = new System.Timers.Timer(100);
			alphaTimer.Elapsed += OnTimedEvent;
			alphaTimer.Enabled = true;
		}

		private void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			RunOnUiThread(() => timerSplash());
		}

		private void timerSplash()
		{
			timerCount++;
			if (timerCount <= 10)
			{
				splashScreen.Alpha += 0.1f;
			}
			else if (timerCount >= 20 && timerCount < 30)
			{
				splashScreen.Alpha -= 0.1f;
			}
			else  if (timerCount >= 40 && timerCount < 50)
			{
				splashScreen.SetImageResource(Resource.Drawable.Nvidia_Splash);
				splashScreen.Alpha += 0.1f;

			}
			else  if (timerCount >=60 && timerCount < 70)
			{
				splashScreen.Alpha -= 0.1f;
			}
			else if (timerCount == 80)
			{
				StartActivity (typeof(MainActivity));
				Finish();
			}
		}
	}
}

