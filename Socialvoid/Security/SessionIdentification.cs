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
	/// A SessionIdentification object allows the client to identify the
	/// session it's using and prove that it is the owner of the session;
	/// it proves as a identification effort and security effort.
	/// Most methods that requires authentication or some sort of identity
	/// will require you to pass on this object as a parameter under
	/// `session_identification`; missing parameters or invalid security values
	/// will cause the request to fail as it's validated upon request.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public sealed class SessionIdentification: IIdentitiable<string>
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
		[JsonPropertyName("session_id")]
		public string SessionID { get; set; }
		/// <summary>
		/// The Public Hash of the client used when establishing the session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("client_public_hash")]
		public string ClientPublicHash { get; set; }
		/// <summary>
		/// The session challenge answer revolving around the client's
		/// private hash, the same client used to establish the session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("challenge_answer")]
		public string ChallengeAnswer { get; set; }
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
		public SessionIdentification()
		{

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
		/// Checks if the ID of this object is valid.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the ID is valid;
		/// otherwise, <c>false</c>.
		/// </returns>
		public bool HasValidID() =>
			!string.IsNullOrWhiteSpace(SessionID);
		/// <summary>
		/// Returns the ID of this <see cref="SessionIdentification"/> object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string GetID() => SessionID;
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
	}
}