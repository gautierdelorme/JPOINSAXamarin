using System;
using System.Collections.Generic;
using Parse;

namespace JPOINSA.iOS
{
	public class ParseManager : IParseManager
	{
		public ParseManager ()
		{
			ParseClient.Initialize (Settings.applicationId, Settings.dotNetKey);
		}

		public async void signup(String email, String password, Action signupSuccess, Action signupError) {
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
					throw new Exception ("Parse Current User null");
				}
			} 
			catch (Exception e)
			{
				Console.WriteLine("Login did not work : "+e.Message);
				loginError();
			}
		}

		public void getPresentations() {
			ParseCloud.CallFunctionAsync<IList<ParseObject>> ("getPresentations", new Dictionary<string, object> ()).ContinueWith (t => {
				if (t.IsFaulted || t.IsCanceled) {
					Console.WriteLine ("failed");
					foreach (Exception e in t.Exception.InnerExceptions) {
						Console.WriteLine (e.Message);
					}
				} else {
					IList<ParseObject> result = t.Result;
					Console.WriteLine (t.Result);
					foreach (ParseObject obj in result) Console.WriteLine(obj.Get<string>("name"));
				}
			});
		}
	}
}

				/*ParseQuery<ParseObject> query = ParseObject.GetQuery("Presentations");
			ParseObject gameScore = await query.GetAsync("34NjgHaoeM");
			string playerName = gameScore.Get<string>("name");
			Console.WriteLine (playerName);

			var objectReturn = await ParseCloud.CallFunctionAsync<string> ("getPresentations", new Dictionary<String, Object> ());
			Console.WriteLine (objectReturn);

			IDictionary<string, object> args = new Dictionary<string, object>{
				{ "_message", "hello world"}
			};
			ParseCloud.CallFunctionAsync<IDictionary<string, object>>("PrintThis", args).ContinueWith(t => {
				IDictionary<string, object> result = t.Result;
				object code;
				if(result.TryGetValue("reply", out code)){
					Console.WriteLine("Reply : " + result["reply"]);
				}
			});*/

				/*var task = ParseCloud.CallFunctionAsync<IList<ParseObject>>("getPresentations", new Dictionary<string, object>());

				while (!task.IsCompleted)
				{
				}

				if (task.IsFaulted || task.IsCanceled)
				{
					Console.WriteLine("failed");
					foreach(Exception e in task.Exception.InnerExceptions)
					{
						Console.WriteLine("ee : "+e.Message);
					}
				}
				else
				{
					Console.WriteLine("success");
				}*/

				/*Console.WriteLine ("yoo")
				try {
					ParseCloud.CallFunctionAsync<IDictionary<string, object>> ("getPresentations", null).ContinueWith(t =>
						{
							Console.WriteLine("y");
							if (t.IsFaulted) {
								Console.WriteLine("e");
								Console.WriteLine(t);
								using (IEnumerator<System.Exception> enumerator = t.Exception.InnerExceptions.GetEnumerator()) {
									Console.WriteLine("a");
									if (enumerator.MoveNext()) {
										ParseException error = (ParseException) enumerator.Current;
										Console.WriteLine("Message: " + error.Message + ", Code: " + error.Code);
									}
								}
							} else {
								Console.WriteLine("s");
								IDictionary<string, object> result = t.Result;
								// Hack, check for errors
								object code;
								if (result.TryGetValue("code", out code)) {
									Console.WriteLine ("Error Code: " + code);
								} else {
									Console.WriteLine ("Result: " + result["success"]);
								}
							}
							//IDictionary<string, object> result = t.Result;
							//Console.WriteLine(t.Result);
							//foreach (object key in result.Keys) Console.WriteLine(key);
						});
					var objectReturn = await ParseCloud.CallFunctionAsync<IDictionary<string, object>> ("getPresentations", new Dictionary<String, Object> ());
					Console.WriteLine (objectReturn);
				} catch (Exception e) {
					Console.WriteLine ("euh... " + e);
				}*/