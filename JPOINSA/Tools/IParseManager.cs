using System;
using System.Collections.Generic;

namespace JPOINSA
{
	public interface IParseManager
	{
		void signup(string email, string password, Action signupSuccess, Action signupError);
		void login(string email, string password, Action loginSuccess, Action loginError);
		void getPresentations(Action<IList<Presentation>> presentations);
	}
}

