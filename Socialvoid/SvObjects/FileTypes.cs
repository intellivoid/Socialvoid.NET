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
	/// File types indicate the content type of the file, if the server is
	/// unable to determine the file type then it will default to DOCUMENT.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public enum FileTypes
	{
		//-------------------------------------------------
		#region general types
		/// <summary>
		/// The default value of an <see cref="FileTypes"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Document = 0,
		#endregion
		//-------------------------------------------------
		#region Another styling
		/// <summary>
		/// The file is an image file type.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Photo = 1,
		/// <summary>
		/// The file is an video file type.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Video = 2,
		/// <summary>
		/// The file is an audio file type.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		Audio = 3,
		#endregion
		//-------------------------------------------------
	}
}