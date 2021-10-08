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

namespace Socialvoid.SvObjects.Server
{
	/// <summary>
	/// The <see cref="ServerInformation"/> object is a simple object that gives
	/// details about the server's attributes and limits or location
	/// of other servers that the client should communicate to for other
	/// purposes such as a CDN.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class ServerInformation
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
		/// The name of the network, eg; "Socialvoid".
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("network_name")]
		public string NetworkName { get; set; }
		/// <summary>
		/// The version of the protocol standard that the server is using, eg; "1.0"
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("protocol_version")]
		public string ProtocolVersion { get; set; }
		/// <summary>
		/// The HTTP URL Endpoint for the CDN server of the network
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("cdn_server")]
		public string AddressCDN { get; set; }
		/// <summary>
		/// The maximum size of a file that you can upload
		/// to the CDN Server (in bytes)
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("upload_max_file_size")]
		public int MaxUploadSize { get; set; }
		/// <summary>
		/// The maximum time-to-live (in seconds) that an unauthorized
		/// session may have. The server will often reset the expiration
		/// whenever the session is used.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("unauthorized_session_ttl	")]
		public int UnauthorizedSessionTTL { get; set; }
		/// <summary>
		/// The maximum time-to-live (in seconds) that an authorized
		/// session may have. The server will often reset the expiration
		/// whenever the session is used.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("authorized_session_ttl")]
		public int SessionTTL { get; set; }
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
		public ServerInformation()
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
		// some methods here
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