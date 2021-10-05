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
using System.Text.Json.Serialization;

namespace Socialvoid.SvObjects.Media
{
	/// <summary>
	/// ListW is a wrapper for <see cref="List{T}"/> that allows for the use
	/// of some custom methods.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class DisplayPictureSize
	{
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The width of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("height")]
		public virtual int Width { get; set;} 
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("height")]
		public virtual int Height { get; set; }

		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("document")]
		public virtual Document Document { get; set; }
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a new instance of ListW
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public DisplayPictureSize()
		{

		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Checks if this <see cref="DisplayPictureSize"/> has a 
		/// valid document.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public bool HasDocument() => 
			Document != null;
		#endregion
		//-------------------------------------------------
	}
}
