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
	/// An abstract class that contains common OTP calculations.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	/// <remarks>
	/// https://tools.ietf.org/html/rfc4226
	/// </remarks>
	public abstract class Otp
	{
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the secret key.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected readonly IKeyProvider _secretKey;

		/// <summary>
		/// The hash mode to use.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected readonly OtpHashMode _hashMode;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Constructor for the abstract class using an explicit secret key.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="secretKey">
		/// The secret key.
		/// </param>
		/// <param name="mode">
		/// The hash mode to use.
		/// </param>
		public Otp(byte[] secretKey, OtpHashMode mode)
		{
			if(secretKey == null || secretKey.Length == 0)
			{
				throw new ArgumentNullException(nameof(secretKey),
					"Secret key cannot be null or empty");
			}

			// when passing a key into the constructor the caller may depend on
			// the reference to the key remaining intact.
			_secretKey	= new InMemoryKey(secretKey);
			_hashMode	= mode;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Otp"/> class
		/// with empty secret key.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected Otp()
		{
			;
		}
		/// <summary>
		/// Constructor for the abstract class using a generic key provider.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="key"></param>
		/// <param name="mode">The hash mode to use</param>
		public Otp(IKeyProvider key, OtpHashMode mode)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key), "key cannot be null");
			}

			_hashMode	= mode;
			_secretKey	= key;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// An abstract definition of a compute method. 
		/// Takes a counter and runs it through the derived algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="counter">Counter or step</param>
		/// <param name="mode">The hash mode to use</param>
		/// <returns>OTP calculated code</returns>
		protected abstract string Compute(long counter, OtpHashMode mode);
		/// <summary>
		/// Helper method that calculates OTPs.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal long CalculateOtp(byte[] data, OtpHashMode mode)
		{
			byte[] hmacComputedHash = _secretKey.ComputeHmac(mode, data);

			// The RFC has a hard coded index 19 in this value.
			// This is the same thing but also accomodates SHA256 and SHA512
			// hmacComputedHash[19] => hmacComputedHash[hmacComputedHash.Length - 1]

			int offset = hmacComputedHash[hmacComputedHash.Length - 1] & 0x0F;
			return (hmacComputedHash[offset] & 0x7f) << 24
				| (hmacComputedHash[offset + 1] & 0xff) << 16
				| (hmacComputedHash[offset + 2] & 0xff) << 8
				| (hmacComputedHash[offset + 3] & 0xff) % 1000000;
		}
		/// <summary>
		/// truncates a number down to the specified number of digits.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected internal static string Digits(long input, int digitCount)
		{
			var truncatedValue = ((int)input % (int)Math.Pow(10, digitCount));
			return truncatedValue.ToString().PadLeft(digitCount, '0');
		}
		/// <summary>
		/// Verify an OTP value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="initialStep">
		/// The initial step to try.
		/// </param>
		/// <param name="valueToVerify">
		/// The value to verify
		/// </param>
		/// <param name="matchedStep">
		/// Output parameter that provides the step 
		/// where the match was found.  If no match was found it will be 0
		/// </param>
		/// <param name="window">
		/// The window to verify.
		/// </param>
		/// <returns>
		/// <c>true</c> if a match is found; otherwise <c>false</c>.
		/// </returns>
		protected bool Verify(long initialStep, string valueToVerify, out long matchedStep, VerificationWindow window)
		{
			window ??= new();
			foreach(var frame in window.ValidationCandidates(initialStep))
			{
				var comparisonValue = this.Compute(frame, _hashMode);
				if(ValuesEqual(comparisonValue, valueToVerify))
				{
					matchedStep = frame;
					return true;
				}
			}

			matchedStep = 0;
			return false;
		}
		/// <summary>
		/// Constant time comparison of two values.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private bool ValuesEqual(string a, string b)
		{
			if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
			{
				return true;
			}

			if(a.Length != b.Length)
			{
				return false;
			}

			var result = 0;
			for(int i = 0; i < a.Length; i++)
			{
				result |= a[i] ^ b[i];
			}

			return result == 0;
		}
		#endregion
		//-------------------------------------------------
	}
}
