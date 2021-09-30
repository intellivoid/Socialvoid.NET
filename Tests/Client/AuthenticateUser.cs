using System;
using Socialvoid.Errors;
using Socialvoid.Client;
using Socialvoid.Errors.ServerErrors;
using Socialvoid.Errors.NetworkErrors;
using Socialvoid.Errors.ValidationErrors;
using NUnit.Framework;


namespace Tests.Client
{
	[TestFixture]
	public class ClientTest
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

		[TestCase(
			"4c7148caff498d24deee6c8325f1c15773d637ed76c3a4056e00b77b2beb3097", // public hash
			"866d3218b239d39c174fa2b16f54e0fa58f9c69fce8c2d941c12a47a7bc75229", // private hash
			"Linux", // platform
			"Test .NET RCP Client", // the name
			"1.0.0.0" // version
		)]
		public void AuthenticateUserTest(string publicHash, string privateHash, 
			string platform, string name, string version)
		{
			var myClient = 
				SocialvoidClient.GetClient(publicHash, 
					privateHash, platform, name, version);
			myClient.CreateSession();
			myClient.AuthenticateUser("aliwoto", "12345678");
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