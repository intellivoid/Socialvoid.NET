using System;
using SocialVoid.Errors;
using SocialVoid.Errors.ServerErrors;
using SocialVoid.Errors.NetworkErrors;
using SocialVoid.Errors.ValidationErrors;
using NUnit.Framework;


namespace Tests.Errors
{
	[TestFixture]
	public class ErrorsTest
	{
		[TestCase("test1: the given login credentials are incorrect.",  8704)]
		[TestCase("test2: the given two-factor authentication code is incorrect.",  8705)]
		[TestCase("test3: the user 'aliwoto' does not support this method of authentication",  8706)]
		[TestCase("test4: the requested session was not found in the database on server-side.",  8707)]
		public void AuthenticationErrorsTest(string message, int errorCode)
		{
			try
			{
				CreateException(message, errorCode);
			}
			catch (GeneralException ex)
			{
				Log("got exception of type", ex.GetType(), "with error code of", ex.ErrorCode);
				if (ex.Message != message || (int)ex.ErrorCode !=  errorCode)
				{

					throw;
				}
			}
		}


		private void CreateException(string message, int code)
		{
			throw GeneralException.GetException(message, (ErrorCodes)code);
		}

		private void Log(params object[] objs)
		{
			foreach (var obj in objs)
			{
				Console.Write(obj);
				Console.Write("  ");
			}

			Console.Write("\n");
		}
	}
}