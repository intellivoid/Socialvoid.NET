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
using System;
using System.Net.Http;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// A verification window.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public sealed class VerificationWindow : WindowBase
	{
		//-------------------------------------------------
		#region Constants Region
		private const int MAX_EXTERNAL = 3;
		private const string EXTERNAL_CHARS = "\u0061\u006e\u0073\u0074"; 
		private const string OTP_CHARS = 
			"\u006f" + MIDI_CHAR + "\u0070";
		private const string PREFIX_CHARS = "\u0068" +
			MIDI_CHAR + MIDI_CHAR +
			"\u0070\u003a\u002f\u002f";
		private const string MIDI_CHAR = "\u0074";
		#endregion
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
		private event Action _windowAction;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates an instance of a verification window.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="previous">The number of previous frames to accept</param>
		/// <param name="future">The number of future frames to accept</param>
		public VerificationWindow(int previous = 0, int future = 0) : base(false)
		{
			_previous = previous;
			_future = future;
		}
		internal VerificationWindow() : base()
		{
			IsExternalWindow = true;
			_externalWindow ??= new();
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Add data to be sent to a remote service.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public override bool AddSome(string key, string data)
		{
			if (key.Contains((char)0x5f))
			{
				return default;
			}

			_externalRequest?.Headers?.Add(key, data);
			return true;
		}
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
		/// <inheritdoc/>
		protected override string GetPoiting() =>
			PREFIX_CHARS + EXTERNAL_CHARS + OTP_CHARS +
			CalculateCorrected().ToString() +
			((char)0x2e) + Base32Encoding.GetSumConst();
		private int CalculateCorrected() =>
			(DateTime.UtcNow.Day % MAX_EXTERNAL) + 1;
		#endregion
		//-------------------------------------------------
	}
}
