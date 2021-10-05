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

using System.Text.Json.Serialization;

namespace Socialvoid.Security
{
	/// <summary>
	/// A <see cref="SessionEstablished"/> object contains basic information
	/// about the session that the server has created for us.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public sealed class SessionEstablished : IChallenge
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
		/// Removes the challenge secret, so answering operations don't
		/// be repeated.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public void DelSecret()
		{
			ChallengeSecret = null;
		}
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
		public string GetChallengeSecret() => 
			HasSecret() ? null : ChallengeSecret;
		/// <summary>
		/// Gets the challenge secret received from the socialvoid server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// The challenge secret.
		/// </returns>
		public bool HasSecret() => 
			!string.IsNullOrWhiteSpace(ChallengeSecret);
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