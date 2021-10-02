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
	/// Indicates which HMAC hashing algorithm should be used.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public enum OtpHashMode
	{
		//-------------------------------------------------
		#region SHA region
		/// <summary>
		/// Sha1 is used as the HMAC hashing algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		Sha1,
		/// <summary>
		/// Sha256 is used as the HMAC hashing algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		Sha256,
		/// <summary>
		/// Sha512 is used as the HMAC hashing algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		Sha512,
		#endregion
		//-------------------------------------------------
	}
}
