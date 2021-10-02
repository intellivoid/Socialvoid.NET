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

using System;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Class to apply a correction factor to the system time.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	/// <remarks>
	/// In cases where the local system time is incorrect it is preferable to simply correct the system time.
	/// This class is provided to handle cases where it isn't possible for the client, the server, or both, to be on the correct time.
	/// 
	/// This library provides limited facilities to to ping NIST for a correct network time.  This class can be used manually however in cases where a server's time is off
	/// and the consumer of this library can't control it.  In that case create an instance of this class and provide the current server time as the correct time parameter
	/// 
	/// This class is immutable and therefore threadsafe.
	/// </remarks>
	public class TimeCorrection
	{
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// Applies the correction factor to the current system UTC time and
		/// returns a corrected time.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public DateTime CorrectedUtcNow
		{
			get => GetCorrectedTime(DateTime.UtcNow);
		}
		/// <summary>
		/// The timespan that is used to calculate a corrected time.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public TimeSpan CorrectionFactor
		{
			get => _timeCorrectionFactor;
		}
		#endregion
		//-------------------------------------------------
		#region static field's Region
		/// <summary>
		/// An instance that provides no correction factor.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public static readonly TimeCorrection UncorrectedInstance = new();
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// The timespan that is used as a correction factor.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly TimeSpan _timeCorrectionFactor;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Constructor used solely for the <see cref="UncorrectedInstance"/> static
		/// field to provide an instance without a correction factor.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private TimeCorrection()
		{
			_timeCorrectionFactor = TimeSpan.FromSeconds(0);
		}

		/// <summary>
		/// Creates a corrected time object by providing the known correct 
		/// current UTC time.
		/// The current system UTC time will be used as the reference.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// This overload assumes UTC.
		/// If a base and reference time other than UTC are required then use the
		/// other overlaod.
		/// </remarks>
		/// <param name="correctUtc">The current correct UTC time</param>
		public TimeCorrection(DateTime correctUtc)
		{
			_timeCorrectionFactor = DateTime.UtcNow - correctUtc;
		}

		/// <summary>
		/// Creates a corrected time object by providing the known correct current time
		/// and the current reference time that needs correction.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="correctTime">
		/// The current correct time.
		/// </param>
		/// <param name="referenceTime">
		/// The current reference time (time that will have the correction factor
		/// applied in subsequent calls).
		/// </param>
		public TimeCorrection(DateTime correctTime, DateTime referenceTime)
		{
			_timeCorrectionFactor = referenceTime - correctTime;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Applies the correction factor to the reference time and returns a
		/// corrected time.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="referenceTime">
		/// The reference time.
		/// </param>
		/// <returns>
		/// The reference time with the correction factor applied.
		/// </returns>
		public DateTime GetCorrectedTime(DateTime referenceTime) =>
			referenceTime - _timeCorrectionFactor;

		#endregion
		//-------------------------------------------------
	}
}
