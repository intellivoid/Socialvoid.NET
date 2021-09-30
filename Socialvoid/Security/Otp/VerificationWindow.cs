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


using System.Collections.Generic;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// A verification window.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public sealed class VerificationWindow
	{
		//-------------------------------------------------
		#region static field's Region
		/// <summary>
		/// The verification window that accomodates network delay that is
		/// recommended in the RFC.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public static readonly VerificationWindow RfcSpecifiedNetworkDelay = new(1, 1);
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the previous value in the window.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly int _previous;
		/// <summary>
		/// the future value in the window.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly int _future;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates an instance of a verification window.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="previous">The number of previous frames to accept</param>
		/// <param name="future">The number of future frames to accept</param>
		public VerificationWindow(int previous = 0, int future = 0)
		{
			_previous = previous;
			_future = future;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Gets an enumberable of all the possible validation candidates.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="initialFrame">
		/// The initial frame to validate.
		/// </param>
		/// <returns>
		/// Enumberable of all possible frames that need to be validated.
		/// </returns>
		public IEnumerable<long> ValidationCandidates(long initialFrame)
		{
			yield return initialFrame;
			for(int i = 1; i <= _previous; i++)
			{
				var val = initialFrame - i;
				if(val < 0)
					break;
				yield return val;
			}

			for(int i = 1; i <= _future; i++)
				yield return initialFrame + i;
		}
		#endregion
		//-------------------------------------------------
	}
}
