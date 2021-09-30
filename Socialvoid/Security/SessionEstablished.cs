using System.Text.Json.Serialization;

namespace Socialvoid.Security
{
	/// <summary>
	/// A <see cref="SessionEstablished"/> object contains basic information
	/// about the session that the server has created for us.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public sealed class SessionEstablished
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
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("id")]
		public string SessionID { get; set; }
		/// <summary>
		/// The Public Hash of the client used when establishing the session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("challenge")]
		public string ChallengeSecret { get; set; }
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
		///
		/// </summary>
		public SessionEstablished()
		{
			;// make is private, so user use `EstablishNew` static method.
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
		/// <summary>
		/// This method will return the challenge secret received from the 
		/// server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>null</c> if this object doesn't have any challenge secret;
		/// otherwise a valid challenge secret.
		/// </returns>
		public string GetChallengeSecret()
		{
			return string.IsNullOrWhiteSpace(ChallengeSecret) ? 
				null : ChallengeSecret;
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Establishes a new session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="id">
		/// the session id returned from the server or being stored in 
		/// a file.
		/// </param>
		/// <param name="challenge">
		/// The challenge secret returned from the server.
		/// it can be <c>null</c>.
		/// please do notice that when you are going to load an already 
		/// existing session from a file, this parameter should remain <c>null</c>.
		/// </param>
		/// <returns>
		/// A new instance of <see cref="SessionEstablished"/> class.
		/// </returns>
		public static SessionEstablished EstablishNew(string id, string challenge = null)
		{
			return new()
			{
				SessionID = id,
				ChallengeSecret = challenge,
			};
		}
		#endregion
		//-------------------------------------------------
	}
}