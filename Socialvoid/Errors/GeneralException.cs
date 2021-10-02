using System;
using Socialvoid.Errors.RPCErrors;
using Socialvoid.Errors.ServerErrors;
using Socialvoid.Errors.NetworkErrors;
using Socialvoid.Errors.ValidationErrors;
using Socialvoid.Errors.AuthenticationErrors;

namespace Socialvoid.Errors
{
	/// <summary>
	/// 
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	[Serializable]
	public class GeneralException : Exception 
	{
		//-------------------------------------------------
		#region Constant's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The error code of this exception which is received from
		/// the server.
		/// <devdoc>
		/// This property needs to be overrided in specific exception
		/// classes of this library.
		/// </devdoc>
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		public virtual ErrorCodes ErrorCode { get; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a new instance of <see cref="GeneralException"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		/// <param name="message">
		/// the error message received from the server.
		/// </param>
		
		internal GeneralException(string message) : base(message)
		{
			
		}
		/// <summary>
		/// Creates a new instance of <see cref="GeneralException"/> using
		/// the specified error message and erro code.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		/// <param name="message">
		/// the error message received from the server.
		/// </param>
		/// <param name="code">
		/// the error code received from the server.
		/// </param>
		private GeneralException(string message, ErrorCodes code) : base(message)
		{
			ErrorCode = code;
		}

		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Initialize Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// GetException will return a new exception based on the
		/// error code received from the server with the specified 
		/// error message.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		public static GeneralException GetException(string m, ErrorCodes err)
		{
			return err switch
			{
				// Unknown Error
				ErrorCodes.UnknownError => new(m),
				// Validation Errors
				ErrorCodes.InvalidUsername => 
					new InvalidUsernameException(m),
				ErrorCodes.InvalidPassword => 
					new InvalidPasswordException(m),
				ErrorCodes.InvalidFirstName => 
					new InvalidFirstNameException(m),
				ErrorCodes.InvalidLastName => 
					new InvalidLastNameException(m),
				ErrorCodes.InvalidBiography => 
					new InvalidBiographyException(m),
				ErrorCodes.UsernameAlreadyExists => 
					new UsernameAlreadyExistsException(m),
				ErrorCodes.InvalidPeerInput => 
					new InvalidPeerInputException(m),
				ErrorCodes.InvalidPostText => 
					new InvalidPostTextException(m),
				ErrorCodes.InvalidClientPublicHash => 
					new InvalidClientPublicHashException(m),
				ErrorCodes.InvalidClientPrivateHash => 
					new InvalidClientPrivateHashException(m),
				ErrorCodes.InvalidVersion => 
					new InvalidVersionException(m),
				ErrorCodes.InvalidClientName => 
					new InvalidClientNameException(m),
				ErrorCodes.InvalidSessionIdentification => 
					new InvalidSessionIdentificationException(m),
				ErrorCodes.InvalidPlatform => 
					new InvalidPlatformException(m),
				// Authentication Errors
				ErrorCodes.IncorrectLoginCredentials => 
					new IncorrectLoginCredentialsException(m),
				ErrorCodes.IncorrectTwoFactorAuthenticationCode => 
					new IncorrectTwoFactorAuthenticationCodeException(m),
				ErrorCodes.AuthenticationNotApplicable => 
					new AuthenticationNotApplicableException(m),
				ErrorCodes.SessionNotFound => 
					new SessionNotFoundException(m),
				ErrorCodes.NotAuthenticated => 
					new NotAuthenticatedException(m),
				ErrorCodes.PrivateAccessTokenRequired => 
					new PrivateAccessTokenRequiredException(m),
				ErrorCodes.AuthenticationFailure => 
					new AuthenticationFailureException(m),
				ErrorCodes.BadSessionChallengeAnswer => 
					new BadSessionChallengeAnswerException(m),
				ErrorCodes.TwoFactorAuthenticationRequired => 
					new TwoFactorAuthenticationRequiredException(m),
				ErrorCodes.AlreadyAuthenticated => 
					new AlreadyAuthenticatedException(m),
				ErrorCodes.SessionExpired => 
					new SessionExpiredException(m),
				// Media Errors
				// Network Errors
				ErrorCodes.PeerNotFound => 
					new PeerNotFoundException(m),
				ErrorCodes.PostNotFound => 
					new PostNotFoundException(m),
				ErrorCodes.PostDeleted => 
					new PostDeletedException(m),
				ErrorCodes.AlreadyReposted => 
					new AlreadyRepostedException(m),
				ErrorCodes.FileUploadError => 
					new FileUploadErrorException(m),
				// Server Errors
				ErrorCodes.InternalServerError => 
					new InternalServerErrorException(m),
				// RPC Errors
				ErrorCodes.RequestCanceled =>
					new RequestCanceledException(m),
				ErrorCodes.ParseError =>
					new ParseErrorException(m),
				ErrorCodes.InternalError =>
					new InternalErrorException(m),
				ErrorCodes.InvalidParams =>
					new InvalidParamsException(m),
				ErrorCodes.MethodNotFound =>
					new MethodNotFoundException(m),
				ErrorCodes.InvalidRequest =>
					new InvalidRequestException(m),
				ErrorCodes.InvocationErrorWithException =>
					new InvocationErrorWithExException(m),
				ErrorCodes.ResponseSerializationFailure =>
					new ResponseSerializationFailureException(m),
				ErrorCodes.NoMarshaledObjectFound =>
					new NoMarshaledObjectFound(m),
				ErrorCodes.InvocationError =>
					new InvocationErrorException(m),

				// an unknown error code?
				_ => new(m, err)
			};
		}
		#endregion
		//-------------------------------------------------
	}
}
