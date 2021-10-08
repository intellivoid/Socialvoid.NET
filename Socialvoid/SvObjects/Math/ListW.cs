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

using System.Collections.Generic;

namespace Socialvoid.SvObjects.Math
{
	/// <summary>
	/// ListW is a wrapper for <see cref="List{T}"/> that allows for the use
	/// of some custom methods.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class ListW<T> : List<T>
	{
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The length of the list.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual int Length => Count;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a new instance of ListW
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public ListW()
		{

		}
		/// <summary>
		/// Creates 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public ListW(IEnumerable<T> e) : base(e)
		{

		}
		/// <summary>
		/// Creates 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public ListW(int cap) : base(cap)
		{

		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
        /// <summary>
		/// Creates 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual bool Exists(T item) => Contains(item);
        /// <summary>
		/// Creates 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual T[] GetArray() => ToArray();
		#endregion
		//-------------------------------------------------
	}
}
