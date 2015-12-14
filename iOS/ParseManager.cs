using System;
using System.Collections.Generic;
using Parse;
using System.Linq;
using System.Diagnostics;

namespace JPOINSA.iOS
{
	public class ParseManager : IParseManager
	{
		public ParseManager ()
		{
			ParseClient.Initialize (Settings.applicationId, Settings.dotNetKey);
		}

		public async void signup(string email, string password, Action signupSuccess, Action signupError) {
			var user = new ParseUser ()
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
					Console.WriteLine("Connected as : {0}", ParseUser.CurrentUser.Get<string>("username"));
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

		public async void login(string email, string password, Action loginSuccess, Action loginError) {
			try 
			{
				await ParseUser.LogInAsync(email, password);
				if (ParseUser.CurrentUser != null)
				{
					Console.WriteLine("Connected as : {0}", ParseUser.CurrentUser.Get<string>("username"));
					loginSuccess();
				}
				else
				{
					throw new Exception ("Parse Current User null");
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine("Login did not work : "+e.Message);
				loginError();
			}
		}

		public void getPresentations(Action<IList<Presentation>> presentations) {
			ParseCloud.CallFunctionAsync<IList<ParseObject>> ("getPresentations", new Dictionary<string, object> ()).ContinueWith (t => {
				if (t.IsFaulted || t.IsCanceled) {
					Console.WriteLine ("failed");
					foreach (Exception e in t.Exception.InnerExceptions) {
						Console.WriteLine (e.Message);
					}
				} else {
					IList<ParseObject> result = t.Result;
					presentations(parseToPresentations(result));
				}
			});
		}

		private Presentation parseToPresentation (ParseObject obj) {
			ParseGeoPoint geoPoint = obj.Get<ParseGeoPoint> ("location");
			ParseFile image = obj.Get<ParseFile> ("image");
			return new Presentation (
				obj.ObjectId,
				obj.Get<string> ("name"),
				obj.Get<string> ("description"),
				obj.Get<DateTime> ("start"),
				obj.Get<DateTime> ("end"),
				geoPoint.Latitude,
				geoPoint.Longitude,
				image.Url
			);
		}

		private IList<Presentation> parseToPresentations (IList<ParseObject> list) {
			return list.Select (p => parseToPresentation (p)).ToList ();
		}
	}
}