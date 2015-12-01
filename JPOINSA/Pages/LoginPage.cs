using System;

using Xamarin.Forms;

namespace JPOINSA
{
	public class LoginPage : ContentPage
	{
		private Entry entryLogin;
		private Entry entryPassword;

		public LoginPage ()
		{
			Title = "JPO INSA TOULOUSE";

			Padding = new Thickness(20);

			entryLogin = new Entry {
				Placeholder = "Enter your username"
			};

			entryPassword = new Entry {
				Placeholder = "Enter your password",
				IsPassword = true
			};

			var button = new Button {
				Text = "Login",
				Font = Font.SystemFontOfSize(20),
			};
			button.Clicked += loginButtonClicked;

			Content = new StackLayout {
				Spacing = 10,
				Children = {entryLogin, entryPassword, button}
			};
		}

		void loginButtonClicked(object sender, EventArgs e)
		{
			App.parseManager.login (entryLogin.Text, entryPassword.Text, () => loginSuccess(), () => loginError());
		}

		void loginSuccess()
		{
			Navigation.PushAsync (new HomePage ());
		}

		void loginError()
		{
			entryLogin.Text = "";
			entryPassword.Text = "";
		}
	}
}