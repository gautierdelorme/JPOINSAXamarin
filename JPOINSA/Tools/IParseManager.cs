using System;

namespace JPOINSA
{
	public interface IParseManager
	{
		void signup(String email, String password, Action signupSuccess, Action signupError);
		void login(String email, String password, Action loginSuccess, Action loginError);
	}
}

