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

namespace Socialvoid.Errors.ServerErrors
{
	/// <summary>
	/// This exception will be raised when there is an unexpected error
	/// while server tried to process our request.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public sealed class InternalServerErrorException : GeneralException
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
		/// The <see cref="ErrorCodes.InternalServerError"/> error code 
		/// will be returned because there was an unexpected error
		/// while trying to process your request.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		public override ErrorCodes ErrorCode
		{
			get
			{
				return ErrorCodes.InternalServerError;
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
		/// Creates a new instance of <see cref="InternalServerErrorException"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		internal InternalServerErrorException(string message) : base(message)
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