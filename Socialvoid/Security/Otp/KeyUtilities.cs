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
	/// Some helper methods to perform common key functions.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	internal static class KeyUtilities
	{
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Overwrite potentially sensitive data with random junk.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// Warning!
		/// 
		/// This isn't foolproof by any means. 
		/// The garbage collector could have moved the actual location in memory
		/// to another location during a collection cycle and left the old data
		/// in place simply marking it as available. 
		/// We can't control this or even detect it.
		/// This method is simply a good faith effort to limit the exposure of
		/// sensitive data in memory as much as possible.
		/// </remarks>
		internal static void Destroy(byte[] sensitiveData)
		{
			if(sensitiveData == null || sensitiveData.Length == 0)
			{
				// if there is no data, there is nothing to destroy;
				// don't throw an exception, just return.
				return;
			}
				
			new Random().NextBytes(sensitiveData);
		}
		/// <summary>
		/// converts a long into a big endian byte array.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// RFC 4226 specifies big endian as the method for converting the counter
		/// to data and then to hash.
		/// </remarks>
		static internal byte[] GetBigEndianBytes(long input)
		{
			// Since .net uses little endian numbers, we need to reverse the byte order to get big endian.
			var data = BitConverter.GetBytes(input);
			Array.Reverse(data);
			return data;
		}
		/// <summary>
		/// converts an int into a big endian byte array.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// RFC 4226 specifies big endian as the method for converting
		/// the counter to data and then to hash.
		/// </remarks>
		static internal byte[] GetBigEndianBytes(int input)
		{
			// Since .net uses little endian numbers, we need to reverse the byte order to get big endian.
			var data = BitConverter.GetBytes(input);
			Array.Reverse(data);
			return data;
		}
		#endregion
		//-------------------------------------------------
	}
}
