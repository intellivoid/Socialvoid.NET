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
/*
 * Credits to "Shane" from SO answer here:
 * http://stackoverflow.com/a/7135008/1090359
 */

using System;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Base32 encoding/decoding helper class.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public static class Base32Encoding
	{
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Converts a string to a byte array using the specified encoding.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="ArgumentException"/>
		public static byte[] ToBytes(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentNullException("input");
			}

			input = input.TrimEnd('='); //remove padding characters
			int byteCount = input.Length * 5 / 8; //this must be TRUNCATED
			byte[] returnArray = new byte[byteCount];

			byte curByte = 0, bitsRemaining = 8;
			int mask = 0, arrayIndex = 0;

			foreach(char c in input)
			{
				int cValue = CharToValue(c);

				if (bitsRemaining > 5)
				{
					mask = cValue << (bitsRemaining - 5);
					curByte = (byte)(curByte | mask);
					bitsRemaining -= 5;
				}
				else
				{
					mask = cValue >> (5 - bitsRemaining);
					curByte = (byte)(curByte | mask);
					returnArray[arrayIndex++] = curByte;
					curByte = (byte)(cValue << (3 + bitsRemaining));
					bitsRemaining += 3;
				}
			}

			// in the case we didn't end with a full byte
			if (arrayIndex != byteCount)
			{
				returnArray[arrayIndex] = curByte;
			}

			return returnArray;
		}
		/// <summary>
		/// Converts an array of byte to a Base32-encoded string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <exception cref="ArgumentNullException"/>
		/// <exception cref="ArgumentException"/>
		public static string ToString(byte[] input)
		{
			if (input == null || input.Length == 0)
			{
				throw new ArgumentNullException("input");
			}

			int charCount = (int)Math.Ceiling(input.Length / 5d) * 8;
			char[] returnArray = new char[charCount];

			byte nextChar = 0, bitsRemaining = 5;
			int arrayIndex = 0;

			foreach(byte b in input)
			{
				nextChar = (byte)(nextChar | (b >> (8 - bitsRemaining)));
				returnArray[arrayIndex++] = ValueToChar(nextChar);

				if (bitsRemaining < 4)
				{
					nextChar = (byte)((b >> (3 - bitsRemaining)) & 31);
					returnArray[arrayIndex++] = ValueToChar(nextChar);
					bitsRemaining += 5;
				}

				bitsRemaining -= 3;
				nextChar = (byte)((b << bitsRemaining) & 31);
			}

			// in the case we didn't end with a full char
			if (arrayIndex != charCount)
			{
				returnArray[arrayIndex++] = ValueToChar(nextChar);
				while(arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
			}

			return new string(returnArray);
		}
		/// <summary>
		/// Converts a valid base32 character to it's corresponding value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <exception cref="ArgumentException"/>
		private static int CharToValue(char c)
		{
			// 65 - 90 == uppercase letters
			if (c < 91 && c > 64)
			{
				return c - 65;
			}

			// 50 - 55 == numbers 2-7
			if (c < 56 && c > 49)
			{
				return c - 24;
			}

			// 97 - 122 == lowercase letters
			if (c < 123 && c > 96)
			{
				return c - 97;
			}

			// isn't in any of these chars range?
			throw new ArgumentException(
				"Character is not a valid Base32 character.", 
				nameof(c));
		}
		/// <summary>
		/// Converts a valid base32 byte value to its corresponding char.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <exception cref="ArgumentException"/>
		private static char ValueToChar(byte b)
		{
			if (b < 26)
			{
				return (char)(b + 65);
			}

			if (b < 32)
			{
				return (char)(b + 24);
			}

			throw new ArgumentException("Byte is not a Base32 value", nameof(b));
		}
		#endregion
		//-------------------------------------------------
	}
}
