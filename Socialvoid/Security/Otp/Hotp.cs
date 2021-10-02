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

using System;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Calculate HMAC-Based One-Time-Passwords (HOTP) from a secret key.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	/// <remarks>
	/// The specifications for the methods of this class can be found in RFC 4226:
	/// http://tools.ietf.org/html/rfc4226
	/// </remarks>
	public sealed class Hotp : Otp
	{
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// The HOTP size.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly int _hotpSize;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates an HOTP instance.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="secretKey">
		/// The secret key to use in HOTP calculations.
		/// </param>
		/// <param name="mode">
		/// The hash mode to use.
		/// </param>
		/// <param name="hotpSize">The number of digits that the returning HOTP should have.  The default is 6.</param>
		public Hotp(byte[] secretKey, OtpHashMode mode = OtpHashMode.Sha1, int hotpSize = 6)
			: base(secretKey, mode)
		{
			if (hotpSize < 6 || hotpSize > 8)
			{
				throw new ArgumentOutOfRangeException(nameof(hotpSize), 
					"The hotpSize must be between 6 and 8");
			}

			_hotpSize = hotpSize;
		}
		/// <summary>
		/// Create a HOTP instance.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="key">
		/// The key to use in HOTP calculations.
		/// </param>
		/// <param name="mode">
		/// The hash mode to use.
		/// </param>
		/// <param name="hotpSize">
		/// The number of digits that the returning HOTP should have.
		/// The default value is 6.
		/// </param>
		public Hotp(IKeyProvider key, 
			OtpHashMode mode = OtpHashMode.Sha1,
			int hotpSize = 6)
			: base(key, mode)
		{
			
			if (hotpSize < 6 || hotpSize > 8)
			{
				throw new ArgumentOutOfRangeException(nameof(hotpSize), 
					"The hotpSize must be between 6 and 8");
			}

			_hotpSize = hotpSize;
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		/// <summary>
		/// Takes a time step and computes a HOTP code.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="counter">
		/// the counter. This is the number of time steps that have passed.
		/// </param>
		/// <param name="mode">
		/// The hash mode to use.
		/// </param>
		/// <returns>
		/// HOTP calculated code.
		/// </returns>
		protected override string Compute(long counter, OtpHashMode mode)
		{
			var data = KeyUtilities.GetBigEndianBytes(counter);
			var otp = this.CalculateOtp(data, mode);
			return Digits(otp, _hotpSize);
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Takes a counter and then computes a HOTP value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="counter">
		/// The timestamp to use for the HOTP calculation.
		/// </param>
		/// <returns>a HOTP value</returns>
		public string ComputeHOTP(long counter)
		{
			return this.Compute(counter, _hashMode);
		}
		/// <summary>
		/// Verify a value that has been provided with the calculated value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="hotp">the trial HOTP value.
		/// </param>
		/// <param name="counter">
		/// The counter value to verify
		/// </param>
		/// <returns>
		/// <c>true</c> if there is a match; otherwise <c>false</c>.
		/// </returns>
		public bool VerifyHotp(string hotp, long counter) => 
			hotp == ComputeHOTP(counter);

		#endregion
		//-------------------------------------------------
	}
}
