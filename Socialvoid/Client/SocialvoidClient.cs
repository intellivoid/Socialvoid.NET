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
using System.IO;
using System.Web;
using System.Net.Http;
using Socialvoid.JObjects;
using Socialvoid.Security;
using Socialvoid.Security.Otp;
using Socialvoid.SvObjects;
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
		/// the first name key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string FirstNameKey = "first_name";
		/// <summary>
		/// the last name key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string LastNameKey = "last_name";
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
		/// the ToS key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string ToSKey = "terms_of_service_id";
		/// <summary>
		/// the ToS key in jsonrpc request params.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string ToSAgreeKey = "terms_of_service_agree";
		/// <summary>
		/// <c>authenticate_user</c> method value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string SessionIDKey = "session_identification";
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
		protected const string RegisterMethod = "session.register";
		/// <summary>
		/// <c>get_terms_of_service</c> method value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected const string GetToSMethod = "help.get_terms_of_service";
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
		public virtual string PublicHash { get; protected set; }
		/// <summary>
		/// The private hash of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual string PrivateHash { get; protected set; }
		/// <summary>
		/// The platform of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual string Platform { get; protected set; }
		/// <summary>
		/// The name of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual string ClientName { get; protected set; }
		/// <summary>
		/// The version of the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual string Version { get; protected set; }
		/// <summary>
		/// The HTTP client of this <see cref="SocialvoidClient"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual HttpClient HttpClient { get; protected set; }
		/// <summary>
		/// Representing the automation of establishing a session when
		/// <see cref="HasSession"/> is <c>false</c>.
		/// If <c>true</c>, the session will be established automatically
		/// when <see cref="HasSession"/> is <c>false</c>.
		/// If <c>false</c>, you need to establish the session by calling
		/// <see cref="CreateSession"/> method.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual bool AutoSession { get; set; }
		/// <summary>
		/// the stored <see cref="Peer"/> value in the client.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual Peer AuthorizedPeer { get; protected set; }
		/// <summary>
		/// Represents whether the client has a session or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <value>
		/// <c>true</c> if has session; otherwise, <c>false</c>.
		/// </value>
		public virtual bool HasSession => _session != null;
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
		protected string _otp_challenge;
		/// <summary>
		/// the terms of service received from the socialvoid's server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected HelpDocument _termsOfService;
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
		/// <param name="store">
		/// if <c>true</c>, the session will be stored in the client;
		/// otherwise, the session will only be returned, so it's up to
		/// users whether to store the session or not.
		/// </param>
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
		public virtual SessionEstablished CreateSession(bool store = true)
		{
			JArgs args = new(){
				{PublicHashKey, PublicHash},
				{PrivateHashKey, PrivateHash},
				{PlatformKey, Platform},
				{NameKey, ClientName},
				{VersionKey, Version},
			};

			var jresp = ParseContent<SessionEstablished>(
				GetMessage(CreateSessionMethod, args));
			
			if (store)
			{
				_session = jresp.Result;
				return _session;
			}

			return jresp.Result;
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
		public virtual bool AuthenticateUser(string username, string password,
			string otp = null, SessionIdentification sessionID = null)
		{
			if (sessionID == null)
			{
				if (_session == null)
				{
					if (!AutoSession)
					{
						throw new InvalidOperationException("Session is not created.");
					}
					_session = CreateSession();
				}

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
			if (!string.IsNullOrWhiteSpace(otp))
			{
				args.Add(OtpKey, otp);
			}

			CheckAnswer(sessionID);

			var jresp = ParseContent<bool>(
				GetMessage(AuthenticateUserMethod, args));
			
			if (jresp == null)
			{
				// this shouldn't happen in normal cases.
				throw new InvalidOperationException(
					"received invalid response from server.");
			}

			return jresp.Result;
		}

		/// <summary>
		/// CreateSession method (session.create), establishes a new session
		/// to the network.
		/// Please do notice that new and unauthenticated sessions
		/// expires after 10 minutes of inactivity, authenticating to the session
		/// will increase the expiration time to 72 hours of inactivity. This timer
		/// is reset whenever the session is used in one way or another.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="username">
		/// The username of the user to become registered.
		/// </param>
		/// <param name="password">
		/// the password used to register the user.
		/// </param>
		/// <param name="tosID">
		/// The Terms of Service ID.
		/// </param>
		/// <param name="firstName">
		/// The first name of the user.
		/// </param>
		/// <param name="lastName">
		/// The last name of the user. (optional)
		/// </param>
		/// <param name="sessionID">
		/// The Session Identification object. 
		/// (optional if and only if this client has already established
		/// a session OR <see cref="AutoSession"/> is set to <c>true</c>).
		/// </param>
		/// <param name="store">
		/// set it to <c>true</c> if you want to store the session in the
		/// client.
		/// </param>
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
		public virtual Peer Register(
			string username,
			string password,
			string firstName,
			string lastName = null,
			string tosID = null,
			SessionIdentification sessionID = null,
			bool store = true)
		{

			if (password == null || password.Length < 8)
			{
				throw new ArgumentException("Password must be at least 8 characters long.");
			}
			if (sessionID == null)
			{
				if (_session == null)
				{
					if (!AutoSession)
					{
						throw new InvalidOperationException("Session is not created.");
					}
					_session = CreateSession();
				}

				sessionID = new()
				{
					SessionID = _session.SessionID,
					ClientPublicHash = PublicHash
				};
			}

			if (string.IsNullOrEmpty(tosID))
			{
				if (_termsOfService == null)
				{
					throw new InvalidOperationException(
						"ToS should be accepted before using this method");
				}
				tosID = _termsOfService.ID;
			}

			CheckAnswer(sessionID);

			JArgs args = new(){
				{SessionIDKey, sessionID},
				{ToSKey, tosID},
				{ToSAgreeKey, true},
				{UsernameKey, username},
				{PasswordKey, password},
				{FirstNameKey, firstName},
				{LastNameKey, lastName},
			};

			var jresp = ParseContent<Peer>(GetMessage(RegisterMethod, args));
			
			if (store)
			{
				AuthorizedPeer = jresp.Result;
			}

			return jresp.Result;
		}
		/// <summary>
		/// GetTermsOfService (help.get_terms_of_service), Returns a 
		/// HelpDocument object that contains information about the 
		/// Terms of Services (ToS) for the network.
		/// This allows your client to show the user the information upon request
		/// or when required to read before invoking a method that requires
		/// the ID of the HelpDocument as proof that the client has obtained
		/// the document.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual HelpDocument GetTermsOfService(bool store = true)
		{
			var jresp = ParseContent<HelpDocument>(GetMessage(GetToSMethod));
			
			if (store)
			{
				_termsOfService = jresp.Result;
			}

			return jresp.Result;
		}


		/// <summary>
		/// returns a challenge's answer using the session's challenge secret.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal virtual string GetChallengeAnswer(string secret) =>
			KeyGeneration.GetChallengeAnswer(secret, PrivateHash);
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
		protected virtual StringContent SerializeContent(JRequest request)
		{
			return new(request.Serialize());
		}
		/// <summary>
		/// Gets a <see cref="HttpRequestMessage"/> object using the specified
		/// method and endpoint.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="request">
		/// our <see cref="JRequest"/> object.
		/// </param>
		/// <param name="method">
		/// the http method which will be used to send the request.
		/// </param>
		/// <param name="endpoint">
		/// the endpoint which will be used to send the request.
		/// </param>
		/// <returns>
		/// the <see cref="HttpRequestMessage"/> object.
		/// </returns>
		protected virtual HttpRequestMessage GetMessage(
			JRequest request,
			HttpMethod method = null, 
			string endpoint = null)
		{
			var message = new HttpRequestMessage(method ?? HttpMethod.Post,
				endpoint ?? _endpoint);
			message.Content = SerializeContent(request);
			message.Content.Headers.ContentType = _contentTypeValue;
			return message;
		}
		/// <summary>
		/// Gets a <see cref="HttpRequestMessage"/> object using the specified
		/// method and endpoint.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="method">
		/// the json-rpc method.
		/// </param>
		/// <param name="args">
		/// the arguments.
		/// </param>
		/// <param name="id">
		/// the json-rpc request ID.
		/// </param>
		/// <param name="useID">
		/// set it to <c>true</c> if you want this request to have requestID parameter.
		/// (if the passed-by id paramater is null, this method will generate a new
		/// id itself.)
		/// </param>
		/// <returns>
		/// the <see cref="HttpRequestMessage"/> object.
		/// </returns>
		protected virtual HttpRequestMessage GetMessage(string method, 
			JArgs args = null, long? id = null, bool useID = true)
		{
			var request = GetRpcRequest(method, args, id, useID);
			return GetMessage(request);
		}
		/// <summary>
		/// Parses the content of a <see cref="HttpContent"/> as a 
		/// <see cref="JResponse{T}"/>.
		/// </summary>
		/// <exception cref="OutOfMemoryException" />
		/// <exception cref="IOException" />
		/// <exception cref="NotSupportedException" />
		/// <exception cref="HttpRequestException" />
		/// <exception cref="InvalidOperationException" />
		protected internal JResponse<VType> ParseContent<VType>(
			HttpRequestMessage message,
			bool ex = true,
			bool answerChallege = true)
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

			if (!answerChallege)
			{
				// if we don't need to answer challenge, we can just return the
				// response.
				return ParseContent<VType>(resp.Content, ex);
			}
			var jresp = ParseContent<VType>(resp.Content, ex);
			if (jresp.Result is IChallenge result && result.HasSecret())
			{
				_should_otp = true;
				_otp_challenge = result.GetChallengeSecret();
				//_otp_answer = GetChallengeAnswer(result.GetChallengeSecret());
				// set challenege secret to null to avoid sending it again.
				// this will avoid future conflicts in using old challenge secret.
				result.DelSecret();
			}
			return jresp;
		}
		/// <summary>
		/// Checks the <see cref="_should_otp"/> value of this client and
		/// if it's <c>true</c>, it will set the 
		/// <see cref="SessionIdentification.ChallengeAnswer"/> to 
		/// the correct answer.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected virtual void CheckAnswer(SessionIdentification sessionID)
		{
			if (sessionID == null)
			{
				return;
			}

			if (_should_otp && IsOtpValid(_otp_challenge))
			{
				// after adding otp answer to args, don't forget to set
				// _should_otp to false (and _otp to null).
				//args.Add(OtpKey, _challenge);
				sessionID.ChallengeAnswer = GetChallengeAnswer(_otp_challenge);
				//_should_otp = false;
				//_otp_challenge = null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="endpoint">
		/// the new endpoint.
		/// </param>
		/// <param name="path">
		/// the path which will be appended to the endpoint.
		/// </param>
		/// <exception cref="ArgumentException"/>
		public virtual void ChangeEndpoint(string endpoint, string path = null)
		{
			if (string.IsNullOrWhiteSpace(endpoint))
			{
				throw new ArgumentException(
					"endpoint cannot be null or empty",
					nameof(endpoint));
			}
			if (!string.IsNullOrWhiteSpace(path))
			{
				if (endpoint.EndsWith("/"))
				{
					endpoint = endpoint.Substring(0, endpoint.Length - 1);
				}
				if (path.StartsWith("/"))
				{
					path = path.Substring(1);
				}
				endpoint += "/" + HttpUtility.UrlEncode(path);
			}
			_endpoint = endpoint;
		}
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
