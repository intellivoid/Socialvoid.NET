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
using System.Security.Cryptography;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Represents a key in memory.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	/// <remarks>
	/// This will attempt to use the Windows data protection api to
	/// encrypt the key in memory.
	/// However, this type favors working over memory protection. 
	/// This is an attempt to minimize exposure in memory, nothing more.
	/// This protection is flawed in many ways and is limited to Windows.
	/// 
	/// In order to use the key to compute an hmac it must be temporarily 
	/// decrypted, used, then re-encrypted.
	/// This does expose the key in memory for a time.
	/// If a memory dump occurs in this time the plaintext key will be part
	/// of it. Furthermore, there are potentially artifacts from the hmac
	/// computation, GC compaction, or any number of other leaks even after
	/// the key is re-encrypted.
	/// 
	/// This type favors working over memory protection. If the particular 
	/// platform isn't supported then, unless forced by modifying the 
	/// <c>IsPlatformSupported</c> method, it will just store the key in a standard
	/// byte array.
	/// </remarks>
	public class InMemoryKey : IKeyProvider
	{
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// The key data in memory.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		internal readonly byte[] _KeyData;

		/// <summary>
		/// The key length representing the length of the <see cref="_KeyData"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		internal readonly int _keyLength;
		/// <summary>
		/// Used for locking.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly object _stateSync = new();
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates an instance of a key.
		/// </summary>
		/// <param name="key">Plaintext key data</param>
		public InMemoryKey(byte[] key)
		{
			if(!(key != null))
				throw new ArgumentNullException("key");
			if(!(key.Length > 0))
				throw new ArgumentException("The key must not be empty");

			_keyLength = key.Length;
			int paddedKeyLength = (int)Math.Ceiling((decimal)key.Length / (decimal)16) * 16;
			_KeyData = new byte[paddedKeyLength];
			Array.Copy(key, _KeyData, key.Length);
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Gets a copy of the plaintext key.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// This is internal rather than protected so that the tests can 
		/// use this method.
		/// </remarks>
		/// <returns>
		/// Plaintext Key
		/// </returns>
		internal byte[] GetCopyOfKey()
		{
			var plainKey = new byte[_keyLength];
			lock(_stateSync)
			{
				Array.Copy(_KeyData, plainKey, _keyLength);
			}
			return plainKey;
		}
		/// <summary>
		/// Uses the key to get an HMAC using the specified algorithm and data.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="mode">
		/// The HMAC algorithm to use
		/// </param>
		/// <param name="data">
		/// The data used to compute the HMAC
		/// </param>
		/// <returns>
		/// HMAC of the key and data
		/// </returns>
		public byte[] ComputeHmac(OtpHashMode mode, byte[] data)
		{
			byte[] hashedValue = null;
			using(HMAC hmac = CreateHmacHash(mode))
			{
				byte[] key = this.GetCopyOfKey();
				try
				{
					hmac.Key = key;
					hashedValue = hmac.ComputeHash(data);
				}
				finally
				{
					KeyUtilities.Destroy(key);
				}
			}

			return hashedValue;
		}

		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Create an HMAC object for the specified algorithm.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private static HMAC CreateHmacHash(OtpHashMode otpHashMode)
		{
			return otpHashMode switch 
			{
				OtpHashMode.Sha256 => new HMACSHA256(),
				OtpHashMode.Sha512 => new HMACSHA512(),
				_ => new HMACSHA1() //OtpHashMode.Sha1
			};
		}
		#endregion
		//-------------------------------------------------
	}
}
