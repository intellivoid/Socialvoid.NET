using System;

namespace SocialVoid.Errors {
	public class GeneralException : Exception 
	{
		
		public GeneralException(string message) : base(message)
		{

		}
	}
}