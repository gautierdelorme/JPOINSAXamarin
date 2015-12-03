using System;

using Xamarin.Forms;

namespace JPOINSA
{
	public class App : Application
	{
		private static IParseManager instance;
		public static IParseManager parseManager {
			get {
				return instance;
			}
			set {
				if (instance == null) {
					instance = value;
				}
			}
		}

		public App ()
		{
			MainPage = new NavigationPage(new LoginPage ()) {
				BarBackgroundColor = Settings.lightColor,
				BarTextColor = Color.White
			};

			App.parseManager.getPresentations ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

