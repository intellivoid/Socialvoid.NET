/*
 * This file is part of Socialvoid.NET Project (https://github.com/Intellivoid/Socialvoid.NET).
 * Copyright (c) 2021 Socialvoid.NET Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Text;
using System.Net.Http;
using System.IO;
using Socialvoid.Security;
using Socialvoid.Security.Otp;
using Socialvoid.JObjects;
using Socialvoid.Errors.ServerErrors;
using Socialvoid.Errors.AuthenticationErrors;
using Socialvoid.Errors.ValidationErrors;
using MType = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Socialvoid.Client
{
	/// <summary>
	/// Socialvoid client.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public abstract class SocialvoidClient
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// the content type of all of our http requests.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal const string ContentType = "application/json-rpc";
		/// <summary>
		/// the username key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string UsernameKey = "username";
		/// <summary>
		/// the password key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string PasswordKey = "password";
		/// <summary>
		/// the otp key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string OtpKey = "otp";
		/// <summary>
		/// the public hash key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string PublicHashKey = "public_hash";
		/// <summary>
		/// the private hash key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string PrivateHashKey = "private_hash";
		/// <summary>
		/// the platform key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string PlatformKey = "platform";
		/// <summary>
		/// the name key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string NameKey = "name";
		/// <summary>
		/// the version key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string VersionKey = "version";
		/// <summary>
		/// <c>authenticate_user</c> method value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string AuthenticateUserMethod = "session.authenticate_user";
		/// <summary>
		/// <c>authenticate_user</c> method value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string CreateSessionMethod = "session.create";
		/// <summary>
		/// <c>authenticate_user</c> method value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string SessionIDKey = "session_identification";
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The public hash of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string PublicHash { get; protected set; }
		/// <summary>
		/// The private hash of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string PrivateHash { get; protected set; }
		/// <summary>
		/// The platform of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string Platform { get; protected set; }
		/// <summary>
		/// The name of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string ClientName { get; protected set; }
		/// <summary>
		/// The version of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string Version { get; protected set; }
		/// <summary>
		///
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public HttpClient HttpClient { get; protected set; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the endpoint url of socialvoid servers.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal string _endpoint = "http://socialvoid.qlg1.com:5601/";
		/// <summary>
		/// Session object of this client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal SessionEstablished _session;
		/// <summary>
		/// if the client should send an otp answer in the next request,
		/// this field should be set to <c>true</c>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected bool _should_otp;
		/// <summary>
		/// the last otp value of the client which should be sent in the
		/// next jsonrpc request.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected string _otp_answer;
		/// <summary>
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected readonly MType _contentTypeValue = MType.Parse(ContentType);
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
		/// Creates a new instance of the <see cref="SocialvoidClient"/> class.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="publicHash">
		/// the public hash of the client.
		/// </param>
		/// <param name="privateHash">
		/// the private hash of the client.
		/// </param>
		/// <param name="platform">
		/// the platform of the client.
		/// </param>
		/// <param name="name">
		/// the client name.
		/// </param>
		/// <param name="version">
		/// the version of the client.
		/// </param>
		protected SocialvoidClient(string publicHash, string privateHash, 
			string platform, string name, string version)
		{
			PublicHash	= publicHash;
			PrivateHash	= privateHash;
			Platform	= platform;
			ClientName	= name;
			Version		= version;
			HttpClient	= new();
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

		/// <summary>
		/// CreateSession method (session.create), establishes a new session
		/// to the network.
		/// Please do notice that new and unauthenticated sessions
		/// expires after 10 minutes of inactivity, authenticating to the session
		/// will increase the expiration time to 72 hours of inactivity. This timer
		/// is reset whenever the session is used in one way or another.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <exception cref="InternalServerErrorException">
		///	Thrown if the server encounters an internal error.
		/// </exception>
		/// <exception cref="InvalidClientNameException">
		///	Thrown if the parameter passed as client name is not valid.
		/// </exception>
		/// <exception cref="InvalidClientPublicHashException">
		///	Thrown if the parameter passed as public hash is not valid.
		/// </exception>
		/// <exception cref="InvalidClientPrivateHashException">
		///	Thrown if the parameter passed as private hash is not valid.
		/// </exception>
		/// <exception cref="InvalidPlatformException">
		///	Thrown if the parameter passed as platform is not valid.
		/// </exception>
		/// <exception cref="InvalidVersionException">
		///	Thrown if the parameter passed as version is not valid.
		/// </exception>
		public virtual SessionEstablished CreateSession()
		{
			JArgs args = new(){
				{PublicHashKey, PublicHash},
				{PrivateHashKey, PrivateHash},
				{PlatformKey, Platform},
				{NameKey, ClientName},
				{VersionKey, Version},
			};


			var request = GetRpcRequest(CreateSessionMethod, args);
			
			var message = new HttpRequestMessage(HttpMethod.Post, _endpoint);
			message.Content = SerializeContent(request);
			message.Content.Headers.ContentType = _contentTypeValue;
			var jresp = ParseContent<SessionEstablished>(message);
			
			if (!string.IsNullOrEmpty(jresp.Result.ChallengeSecret))
			{
				_should_otp = true;
				_otp_answer = GetChallengeAnswer(jresp.Result.ChallengeSecret);
				// set challenege secret to null to avoid sending it again.
				// this will avoid future conflicts in using old challenge secret.
				jresp.Result.ChallengeSecret = null;
			}
			_session = jresp.Result;

			return _session;
		}
		/// <summary>
		/// AuthenticateUser method (session.authenticate_user),
		/// Authenticates a user via a Username and Password combination. 
		/// Optionally two-factor authentication if the account has enabled it.
		/// Once authenticated, the session will be able to access methods that
		/// requires authentication and preform operations as the authenticated
		/// user.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="sessionID">
		/// The Session Identification object.
		/// </param>
		/// <param name="username">
		/// The username of the user to authenticate to.
		/// </param>
		/// <param name="password">
		/// The password used to authenticate to this account.
		/// </param>
		/// <param name="otp">
		/// The optional one-time password used to authenticate to this account.
		/// It will be ignored by server if empty or larger than 64 characters.
		/// </param>
		/// <exception cref="InternalServerErrorException">
		///	Thrown if the server encounters an internal error.
		/// </exception>
		/// <exception cref="AuthenticationFailureException"> 
		/// Thrown if the authentication fails.
		/// </exception>
		/// <exception cref="AlreadyAuthenticatedException"> 
		/// Thrown if the user is already authenticated.
		/// </exception>
		/// <exception cref="AuthenticationNotApplicableException"> 
		/// Thrown if the user is not able to authenticate.
		/// </exception>
		/// <exception cref="BadSessionChallengeAnswerException"> 
		/// Thrown if the session challenge answer is invalid.
		/// </exception>
		/// <exception cref="IncorrectLoginCredentialsException"> 
		/// Thrown if the username or password is incorrect.
		/// </exception>
		/// <exception cref="IncorrectTwoFactorAuthenticationCodeException"> 
		/// Thrown if the two-factor authentication code is incorrect.
		/// </exception>
		/// <exception cref="PrivateAccessTokenRequiredException"> 
		/// Thrown if the user is not authenticated and the private access token is required.
		/// </exception>
		/// <exception cref="SessionExpiredException">
		/// Thrown if the session has expired.
		/// </exception>
		/// <exception cref="TwoFactorAuthenticationRequiredException">
		/// Thrown if two-factor authentication is required.
		/// </exception>
		public virtual void AuthenticateUser(string username, string password,
			string otp = null, SessionIdentification sessionID = null)
		{
			if (sessionID == null && _session != null)
			{
				sessionID = new()
				{
					SessionID = _session.SessionID,
					ClientPublicHash = PublicHash
				};
			}

			JArgs args = new(){
				{UsernameKey, username},
				{PasswordKey, password},
				{SessionIDKey, sessionID},
			};

			// check if the passed-by otp argument is valid or not.
			// if yes, ignore _otp field and use user's specified otp value.
			// otherwise check for _should_otp and see if we should send an
			// otp answer or not.
			if (IsOtpValid(otp))
			{
				args.Add(OtpKey, otp);
				//sessionID.ChallengeAnswer = otp;
			}

			if (_should_otp && IsOtpValid(_otp_answer))
			{
				// after adding otp answer to args, don't forget to set
				// _should_otp to false (and _otp to null).
				//args.Add(OtpKey, _challenge);
				sessionID.ChallengeAnswer = _otp_answer;
				_should_otp = false;
				_otp_answer = null;
			}

			var request = GetRpcRequest(AuthenticateUserMethod, args);
			
			var message = new HttpRequestMessage(HttpMethod.Post, _endpoint);
			message.Content = SerializeContent(request);
			message.Content.Headers.ContentType = _contentTypeValue;
			var resp = HttpClient.Send(message);
			var contentStr = ReadFromContent(resp.Content);
			
			Console.WriteLine(contentStr);
		}

		/// <summary>
		/// returns a challenge's answer using the session's challenge secret.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal virtual string GetChallengeAnswer(string secret)
		{
			var otp = new Totp(Encoding.UTF8.GetBytes(secret));
			return KeyGeneration.GetSha1(otp.ComputeTotp() + PrivateHash);;
		}

		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Gets the session of this <see cref="SocialvoidClient"/> if and only
		/// if you have already established a session (or has loaded it from a file);
		/// oterwise it will just return a null object instead of throwing an exception.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual SessionEstablished GetSession()
		{
			return _session;
		}
		/// <summary>
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="method">
		/// the method.
		/// </param>
		/// <param name="args">
		/// the arguments.
		/// </param>
		/// <param name="id">
		/// the request ID.
		/// </param>
		/// <param name="useID">
		/// set it to `true` if you want this request to have requestID parameter
		/// set. (if the passed-by id paramater is null, this method will generate
		/// a new id itself.)
		/// </param>
		protected internal JRequest GetRpcRequest(string method, 
			JArgs args = null, 
			Nullable<long> id = null,
			bool useID = true)
		{
			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentException(
					"method name in a rpc request cannot be null or empty",
					nameof(method));
			}
			if (useID && (id == null))
			{
				id = DateTime.Now.Ticks;
			}

			return useID && id != null && id.HasValue ?
			new()
			{
				Method = method,
				Arguments = args,
				ID = id.Value,
			} : 
			new()
			{
				Method = method,
				Arguments = args,
			};
		}

		/// <summary>
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected StringContent SerializeContent(JRequest request)
		{
			return new(request.Serialize());
		}
		/// <summary>
		/// Parses the content of a <see cref="HttpContent"/> as a 
		/// <see cref="JResponse{T}"/>.
		/// </summary>
		/// <exception cref="OutOfMemoryException" />
		/// <exception cref="IOException" />
		protected internal JResponse<VType> ParseContent<VType>(
			HttpRequestMessage message,
			bool ex = true)
			where VType : class
		{
			if (HttpClient == null)
			{
				throw new InvalidOperationException("HttpClient wasn't initialized");
			}
			var resp = HttpClient.Send(message);
			if (resp == null)
			{
				throw new InvalidOperationException("HttpClient.Send returned null");
			}

			return ParseContent<VType>(resp.Content, ex);
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Creates a new instance of the <see cref="SocialvoidClient"/> class.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="publicHash">
		/// the public hash of the client.
		/// </param>
		/// <param name="privateHash">
		/// the private hash of the client.
		/// </param>
		/// <param name="platform">
		/// the platform of the client.
		/// </param>
		/// <param name="name">
		/// the client name.
		/// </param>
		/// <param name="version">
		/// the version of the client.
		/// </param>
		public static SocialvoidClient GetClient(string publicHash, string privateHash, 
			string platform, string name, string version)
			{
				if (string.IsNullOrWhiteSpace(publicHash) || publicHash.Length != 64)
				{
					throw new ArgumentException(
						"publicHash parameter is invalid",
						nameof(publicHash));
				}
				if (string.IsNullOrWhiteSpace(privateHash) || privateHash.Length != 64)
				{
					throw new ArgumentException(
						"privateHash parameter is invalid", 
						nameof(privateHash));
				}
				if (string.IsNullOrWhiteSpace(platform))
				{
					throw new ArgumentException(
						"platform cannot be null or empty", 
						nameof(platform));
				}
				if (string.IsNullOrWhiteSpace(version))
				{
					throw new ArgumentException(
						"version cannot be null or empty", 
						nameof(version));
				}
				return new SvClient(publicHash, privateHash, platform, name, version);
			}
		
		/// <summary>
		/// Checks if a string can be sent as a TOTOP answer or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="otp">
		/// the otp string to check.
		/// </param>
		/// <returns>
		/// <c>true</c> if the otp string is valid; otherwise <c>false</c>.
		/// </returns>
		protected internal static bool IsOtpValid(string otp)
		{
			return !(string.IsNullOrWhiteSpace(otp) || otp.Length > 64);
		}
		/// <summary>
		/// reads the content of a <see cref="HttpContent"/> as a string.
		/// returns <c>null</c> if the stream cannot be read.
		/// </summary>
		/// <exception cref="OutOfMemoryException" />
		/// <exception cref="IOException" />
		protected internal static string ReadFromContent(HttpContent content)
		{
			var stream = content.ReadAsStream();
			if (stream == null || !stream.CanRead)
			{
				return null;
			}

			return new StreamReader(stream).ReadToEnd();
		}
		/// <summary>
		/// Parses the content of a <see cref="HttpContent"/> as a 
		/// <see cref="JResponse{T}"/>.
		/// </summary>
		/// <exception cref="OutOfMemoryException" />
		/// <exception cref="IOException" />
		protected internal static JResponse<VType> ParseContent<VType>(
			HttpContent content,
			bool ex = true)
			where VType : class
		{
			var jresp = JResponse<VType>.Deserialize(ReadFromContent(content));
			if (ex && jresp.HasError())
			{
				throw jresp.GetException();
			}

			return jresp;
		}
		
		#endregion
		//-------------------------------------------------
	}
}
