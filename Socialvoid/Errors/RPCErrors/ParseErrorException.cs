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

namespace Socialvoid.Errors.RPCErrors
{
	/// <summary>
	/// This exception will be raised when invalid JSON is received by the server.
		/// An error occurred on the server while parsing the JSON text.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public sealed class ParseErrorException : GeneralException
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
		/// The <see cref="ErrorCodes.ParseError"/> error code 
		/// will be returned because invalid JSON was received by the server.
		/// An error occurred on the server while parsing the JSON text.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		public override ErrorCodes ErrorCode
		{
			get
			{
				return ErrorCodes.ParseError;
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
		/// Creates a new instance of <see cref="ParseErrorException"/>.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		internal ParseErrorException(string message) : base(message)
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