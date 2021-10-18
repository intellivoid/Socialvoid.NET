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
	/// Interface for challenge response authentication.
	/// Please do notice that answering the challege is not the duty of 
	/// this interface.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public interface IChallenge
	{
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Checks if the challenge is valid.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the challenge is valid;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool HasSecret();
		/// <summary>
		/// Gets the challenge secret received from the socialvoid server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// The challenge secret.
		/// </returns>
		string GetChallengeSecret();
		/// <summary>
		/// Removes the challenge secret, so answering operations don't
		/// be repeated.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		void DelSecret();
		#endregion
		//-------------------------------------------------
	}
}