using System;
namespace ASBLib.Exceptions
{
	public class AuthorizationException : ASBException
	{
		public AuthorizationException(string reason) : base(reason)
		{
		}
	}
}
