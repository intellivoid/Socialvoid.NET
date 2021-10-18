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

namespace Socialvoid.Security
{
	/// <summary>
	/// Interface for sending simple data to a service which
	/// can be used to send data to a remote service.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public interface ISender
	{
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Sends data to a remote service.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		string Send();
		/// <summary>
		/// Add data to be sent to a remote service.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		bool AddSome(string key, string data);
		#endregion
		//-------------------------------------------------
	}
}