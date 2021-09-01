/*
 * This file is part of SocialVoid.NET Project (https://github.com/Intellivoid/SocialVoid.NET).
 * Copyright (c) 2021 SocialVoid.NET Authors.
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

namespace SocialVoid.Errors.ValidationErrors
{
	/// <summary>
	/// This exception will be raised when the Biography is too long
	/// or contains invalid characters;
	/// please see the message for further details.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public sealed class InvalidBiographyException : GeneralException
	{	
		//-------------------------------------------------
		#region Constant's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The <see cref="ErrorCodes.InvalidBiography"/> error code 
		/// will be returned because the Biography is too long
		/// or contains invalid characters;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		public override ErrorCodes ErrorCode
		{
			get
			{
				return ErrorCodes.InvalidBiography;
			}
		}
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a new instance of <see cref="InvalidBiographyException"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		internal InvalidBiographyException(string message) : base(message)
		{
			;
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		// some members here
		#endregion
		//-------------------------------------------------
	}
}
