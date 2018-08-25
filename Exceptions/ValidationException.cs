using System;
namespace ASBLib.Exceptions
{
	public class ValidationException : ASBException
	{
		public ValidationException(string reason) : base(reason)
		{
		}
	}
}
