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

namespace Socialvoid.SvObjects
{
	/// <summary>
	/// This interface is created for solving compability issues.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public interface IFlagable<T>
	{
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Returns the flags of this object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the flags of this object as an array of 
		/// <see cref="string"/> objects.
		/// </returns>
		T[] GetFlags();
		/// <summary>
		/// Returns the length of the flag arrays of this object.
		/// If the flag array is empty, this method will return zero.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		int GetFlagLength();
		/// <summary>
		/// Checks if the length of the flag array is zero or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		bool HasZeroFlags();
		/// <summary>
		/// Checks if this object has any flag or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array is not null and it's length
		/// is more than zero; otherwise <c>false</c>.
		/// </returns>
		bool HasFlag();
		/// <summary>
		/// Checks if this object has at the very least one of the specified
		/// flags or not. If you want to check for all of the flags, please
		/// use <see cref="HasFlags(T[])"/> method.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array of this object contains at the very
		/// least one of the specified flags; otherwise <c>false</c>.
		/// </returns>
		bool HasFlag(params T[] flags);
		/// <summary>
		/// Checks if this object has all of the specified flags or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array of this object has all of the
		/// specified flags; otherwise <c>false</c>.
		/// </returns>
		bool HasFlags(params T[] flags);
		/// <summary>
		/// Returns the flag of this object using the specified index
		/// in the flag array.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="index">
		/// the index of the flag.
		/// </param>
		/// <param name="ex">
		/// set this argument to <c>true</c> if you want the method to
		/// throw an exception in the case it couldn't return any flag.
		/// if you set this to <c>false</c> the method will return
		/// <c>null</c> (or default).
		/// </param>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		T GetFlag(int index, bool ex = true);
		#endregion
		//-------------------------------------------------
	}
}