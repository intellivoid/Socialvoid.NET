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

/*
 * Credits to Devin Martin and the original OtpSharp library:
 * https://github.com/kspearrin/Otp.NET
 */

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Interface used to interact with a key.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public interface IKeyProvider
	{
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Uses the key to get an HMAC using the specified algorithm and data.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// This is a much better API than the previous API which would briefly
		/// expose the key for all derived types.
		/// 
		/// Now a derived type could be bound to an HSM/smart card/etc if
		/// required and a lot of the security limitations of in app/memory
		/// exposure of the key can be eliminated.
		/// </remarks>
		/// <param name="mode">
		/// The HMAC algorithm to use.
		/// </param>
		/// <param name="data">
		/// The data used to compute the HMAC.
		/// </param>
		/// <returns>HMAC of the key and data</returns>
		byte[] ComputeHmac(OtpHashMode mode, byte[] data);
		#endregion
		//-------------------------------------------------
	}
}
