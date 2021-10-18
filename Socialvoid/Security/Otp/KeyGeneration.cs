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
using System.Text;
using System.Security.Cryptography;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Helpers to work with key generations.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public static class KeyGeneration
	{
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Generates a random key in accordance with the RFC recommened
		/// length for each algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="length">the key length</param>
		/// <returns>The generated key</returns>
		public static byte[] GenerateRandomKey(int length)
		{
			byte[] key = new byte[length];
			using(var rnd = RandomNumberGenerator.Create())
			{
				rnd.GetBytes(key);
				return key;
			}
		}
		/// <summary>
		/// Generates a random key in accordance with the RFC recommened
		/// length for each algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="mode">HashMode</param>
		/// <returns>Key</returns>
		public static byte[] GenerateRandomKey(OtpHashMode mode = OtpHashMode.Sha1) =>
			GenerateRandomKey(LengthForMode(mode));
		/// <summary>
		/// Uses the procedure defined in RFC 4226 section 7.5 to derive a key
		/// from the master key.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="masterKey">
		/// The master key from which to derive a device specific key.
		/// </param>
		/// <param name="publicIdentifier">
		/// The public identifier that is unique to the authenticating device.
		/// </param>
		/// <param name="mode">
		/// The hash mode to use. This will determine the resulting key lenght. 
		/// The default value is sha-1 (as per the RFC) which is 20 bytes
		/// </param>
		/// <returns>Derived key</returns>
		public static byte[] DeriveKeyFromMaster(IKeyProvider masterKey,
			byte[] publicIdentifier, OtpHashMode mode = OtpHashMode.Sha1)
		{
			if(masterKey == null)
			{
				throw new ArgumentNullException(nameof(masterKey), 
					"The master key cannot be null");
			}
			return masterKey.ComputeHmac(mode, publicIdentifier);
		}
		/// <summary>
		/// Uses the procedure defined in RFC 4226 section 7.5 to derive a key
		/// from the master key.
		/// </summary>
		/// <param name="masterKey">The master key from which to derive a device specific key</param>
		/// <param name="serialNumber">A serial number that is unique to the authenticating device</param>
		/// <param name="mode">The hash mode to use.  This will determine the resulting key lenght.  The default is sha-1 (as per the RFC) which is 20 bytes</param>
		/// <returns>Derived key</returns>
		public static byte[] DeriveKeyFromMaster(IKeyProvider masterKey,
			int serialNumber,
			OtpHashMode mode = OtpHashMode.Sha1) => 
				DeriveKeyFromMaster(masterKey, 
					KeyUtilities.GetBigEndianBytes(serialNumber), mode);

		internal static HashAlgorithm GetHashAlgorithmForMode(OtpHashMode mode)
		{
			switch(mode)
			{
				case OtpHashMode.Sha256:
					return SHA256.Create();
				case OtpHashMode.Sha512:
					return SHA512.Create();
				default: //case OtpHashMode.Sha1:
					return SHA1.Create();
			}
		}

		internal static int LengthForMode(OtpHashMode mode)
		{
			switch(mode)
			{
				case OtpHashMode.Sha256:
					return 32;
				case OtpHashMode.Sha512:
					return 64;
				default: //case OtpHashMode.Sha1:
					return 20;
			}
		}
		internal static string GetSha1(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), "The value cannot be null");
			}
			if (value.Length == 0x28)
			{
				return value;
			}
			var data = Encoding.ASCII.GetBytes(value);
			var hashData = new SHA1Managed().ComputeHash(data);
			var hash = string.Empty;
			foreach (var b in hashData)
			{
				hash += b.ToString("X2");
			}
			return hash;
		}
		internal static string GetChallengeAnswer(string secret, string privateHash)
		{
			var otp = new Totp(secret);
			otp.SetExternalData(privateHash);
			return KeyGeneration.GetSha1(otp.ComputeTotp());
		}
		#endregion
		//-------------------------------------------------
	}
}
