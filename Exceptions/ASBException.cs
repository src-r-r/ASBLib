using System;
namespace ASBLib.Exceptions
{
	public class ASBException : Exception
    {
		public ASBException(string reason) : base(reason)
        {
        }
    }
}
