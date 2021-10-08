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

/// <summary>
/// Peer Types indicates the account type that's registered to the server,
/// some actions may be restricted depending on the peer type.
/// <code> Since: v0.0.0 </code>
/// </summary>
public enum PeerTypes
{
	//-------------------------------------------------
	#region general types
	/// <summary>
	/// The default value of an <see cref="PeerTypes"/>, which means
	/// the peer type is undefined (or is unsupported by this version of
	/// library).
	/// In the case where our client received this type, we should show user
	/// the "please update your client" message.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	None = 0,
	#endregion
	//-------------------------------------------------
	#region Another styling
	/// <summary>
	/// Normal user account.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	User = 1,
	/// <summary>
	/// A bot account that performs automated actions on the network.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	Bot = 2,
	/// <summary>
	/// A proxy account that mirrors content from another platform.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	Proxy = 3,
	#endregion
	//-------------------------------------------------
}
