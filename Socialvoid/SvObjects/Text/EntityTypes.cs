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

namespace Socialvoid.SvObjects.Text
{
	/// <summary>
	/// Text Entity types describes the entity type applied to the referenced
	/// text so that the client can apply the supported styling or 
	/// clickable action.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public enum EntityTypes
	{
		//-------------------------------------------------
		#region Normal styling
		/// <summary>
		/// The default value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Normal = 0,
		#endregion
		//-------------------------------------------------
		#region Another styling
		/// <summary>
		/// The Bold text style value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Bold = 1,
		/// <summary>
		/// The Italic text style value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Italic = 2,
		/// <summary>
		/// The Code text style value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Code = 3,
		/// <summary>
		/// The Strike-through text style value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		StrikeThrough = 4,
		/// <summary>
		/// The Underline text style value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Underline = 5,
		/// <summary>
		/// The URL entity value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Url = 6,
		/// <summary>
		/// The Mention entity value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Mention = 7,
		/// <summary>
		/// The Hashtag entity value of an <see cref="EntityTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Hashtag = 8,
		#endregion
		//-------------------------------------------------
	}
}
