using System;
using Parse;

namespace JPOINSA.Droid
{
	public class ParseManager : IParseManager
	{
		public ParseManager ()
		{
			ParseClient.Initialize (Settings.applicationId, Settings.dotNetKey);
		}

		public async void signup(String email, String password, Action signupSuccess, Action signupError) {
			var user = new ParseUser()
			{
				Username = email,
				Email = email,
				Password = password
			};
			try 
			{
				await user.SignUpAsync();
				Console.WriteLine("signup done");
				if (ParseUser.CurrentUser != null)
				{
					Console.WriteLine("Connected as : {0}", ParseUser.CurrentUser.Get<String>("username"));
					signupSuccess();
				}
				else
				{
					throw new Exception ("Parse Current User null");
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine("Signup did not work : "+e.Message);
				signupError();
			}
		}

		public async void login(String email, String password, Action loginSuccess, Action loginError) {
			try 
			{
				await ParseUser.LogInAsync(email, password);
				if (ParseUser.CurrentUser != null)
				{
					Console.WriteLine("Connected as : {0}", ParseUser.CurrentUser.Get<String>("username"));
					loginSuccess();
				}
				else
				{
					throw new Exception ();
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine("Login did not work : "+e.Message);
				loginError();
			}
		}
	}
}

