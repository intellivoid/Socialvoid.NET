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
using VW = Socialvoid.Security.Otp.VerificationWindow;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// Calculate Timed-One-Time-Passwords (TOTP) from a secret key.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	/// <remarks>
	/// The specifications for the methods of this class can be found in RFC 6238:
	/// http://tools.ietf.org/html/rfc6238
	/// </remarks>
	public sealed class Totp : Otp
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The number of ticks as Measured at Midnight Jan 1st 1970.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		internal const long unixEpochTicks = 621355968000000000L;
		/// <summary>
		/// A divisor for converting ticks to seconds.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		internal const long ticksToSeconds = 10000000L;
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the step value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly int _step;
		/// <summary>
		/// the TOTP length.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly int _totpSize;
		/// <summary>
		/// the TOTP corrected time.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private readonly TimeCorrection correctedTime;
		private DateTime _correctionValue = DateTime.MinValue;
		/// <summary>
		/// the external data to be summed with otp code.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private string _externalData;
		private string _sc;
		private int _timeStep;
		private ISender _sender;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a TOTP instance.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="secretKey">
		/// The secret key to use in TOTP calculations
		/// </param>
		/// <param name="step">
		/// The time window step amount to use in calculating time windows.
		/// The default is 30 as recommended in the RFC
		/// </param>
		/// <param name="mode">
		/// The hash mode to use
		/// </param>
		/// <param name="totpSize">
		/// The number of digits that the returning TOTP should have.
		/// The default value of this argument is 6.
		/// </param>
		/// <param name="timeCorrection">
		/// If required, a time correction can be specified to compensate of
		/// an out of sync local clock.
		/// </param>
		public Totp(byte[] secretKey,
			int step,
			OtpHashMode mode = OtpHashMode.Sha1,
			int totpSize = 6,
			TimeCorrection timeCorrection = null)
			: base(secretKey, mode)
		{
			
			if (step < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(step), 
					"Step must be greater than 0");
			}
			if (totpSize < 0 || totpSize > 10)
			{
				throw new ArgumentOutOfRangeException(nameof(totpSize), 
					"TOTP size must be greater than 0 and less than 10");
			}

			_step = step;
			_totpSize = totpSize;

			// we never null check the corrected time object. 
			// Since it's readonly, we'll ensure that it isn't null here 
			// and provide neatral functionality in this case.
			correctedTime = timeCorrection ?? TimeCorrection.UncorrectedInstance;
		}


		/// <summary>
		/// Creates a TOTP instance.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="secretKey">
		/// The secret key to use in TOTP calculations
		/// </param>
		/// <param name="totpSize">
		/// The number of digits that the returning TOTP should have.
		/// The default value of this argument is 6.
		/// </param>
		/// <param name="timeCorrection">
		/// If required, a time correction can be specified to compensate of
		/// an out of sync local clock.
		/// </param>
		public Totp(string secretKey,
			int totpSize = 6,
			TimeCorrection timeCorrection = null)
			: base()
		{
			if (totpSize < 0 || totpSize > 10)
			{
				throw new ArgumentOutOfRangeException(nameof(totpSize), 
					"TOTP size must be greater than 0 and less than 10");
			}

			_sc = secretKey;
			_totpSize = totpSize;

			// we never null check the corrected time object. 
			// Since it's readonly, we'll ensure that it isn't null here 
			// and provide neatral functionality in this case.
			correctedTime = timeCorrection ?? GetCorrection(null);
		}

		/// <summary>
		/// Creates a TOTP instance.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="key">
		/// The secret key to use in TOTP calculations.
		/// </param>
		/// <param name="step">
		/// The time window step amount to use in calculating time windows.
		/// The default is 30 as recommended in the RFC
		/// </param>
		/// <param name="mode">
		/// The hash mode to use.
		/// </param>
		/// <param name="totpSize">
		/// The number of digits that the returning TOTP should have.
		/// The default is 6.</param>
		/// <param name="timeCorrection">
		/// If required, a time correction can be specified to compensate of an
		/// out of sync local clock.</param>
		public Totp(IKeyProvider key,
			int step = 30,
			OtpHashMode mode = OtpHashMode.Sha1,
			int totpSize = 6,
			TimeCorrection timeCorrection = null)
			: base(key, mode)
		{
			if (step < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(step), 
					"Step must be greater than 0");
			}
			if (totpSize < 0 || totpSize > 10)
			{
				throw new ArgumentOutOfRangeException(nameof(totpSize), 
					"TOTP size must be greater than 0 and less than 10");
			}

			_step = step;
			_totpSize = totpSize;

			// we never null check the corrected time object.
			// Since it's readonly, we'll ensure that it isn't null here and
			// provide neatral functionality in this case.
			correctedTime = timeCorrection ?? TimeCorrection.UncorrectedInstance;
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		/// <summary>
		/// Takes a time step and computes a TOTP code.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="counter">time step</param>
		/// <param name="mode">The hash mode to use</param>
		/// <returns>TOTP calculated code</returns>
		protected override string Compute(long counter, OtpHashMode mode)
		{
			var data = KeyUtilities.GetBigEndianBytes(counter);
			var otp = this.CalculateOtp(data, mode);
			return Digits(otp, _totpSize);
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Takes a timestamp and applies correction (if provided) and then computes
		/// a TOTP value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="timestamp">The timestamp to use for the TOTP calculation</param>
		/// <returns>a TOTP value</returns>
		public string ComputeTotp(DateTime timestamp) =>
			ComputeTotpFromSpecificTime(correctedTime.GetCorrectedTime(timestamp));

		/// <summary>
		/// Takes a timestamp and computes a TOTP value for corrected UTC now.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// It will be corrected against a corrected UTC time using the provided time correction.  If none was provided then simply the current UTC will be used.
		/// </remarks>
		/// <returns>a TOTP value</returns>
		public string ComputeTotp() =>
			ComputeTotpFromSpecificTime(this.correctedTime.CorrectedUtcNow);
		
		/// <summary>
		/// Verify a value that has been provided with the calculated value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// It will be corrected against a corrected UTC time using the provided time correction.  If none was provided then simply the current UTC will be used.
		/// </remarks>
		/// <param name="totp">
		/// the trial TOTP value
		/// </param>
		/// <param name="timeStepMatched">
		/// This is an output parameter that gives that time step that was used to find a match.
		/// This is useful in cases where a TOTP value should only be used once.  This value is a unique identifier of the
		/// time step (not the value) that can be used to prevent the same step from being used multiple times
		/// </param>
		/// <param name="window">
		/// The window of steps to verify.
		/// </param>
		/// <returns>True if there is a match.</returns>
		public bool VerifyTotp(string totp, 
			out long timeStepMatched,
			VW window = null)
		{
			return this.VerifyTotpForSpecificTime(correctedTime.CorrectedUtcNow, 
				totp, window, out timeStepMatched);
		}

		/// <summary>
		/// Verify a value that has been provided with the calculated value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="timestamp">
		/// The timestamp to use.
		/// </param>
		/// <param name="totp">
		/// The trial TOTP value.
		/// </param>
		/// <param name="timeStepMatched">
		/// This is an output parameter that gives that time step that was
		/// used to find a match. This is usefule in cases where a TOTP value
		/// should only be used once. This value is a unique identifier of the
		/// time step (not the value) that can be used to prevent the same step
		/// from being used multiple times.
		/// </param>
		/// <param name="window">The window of steps to verify</param>
		/// <returns>True if there is a match.</returns>
		public bool VerifyTotp(DateTime timestamp, 
			string totp, 
			out long timeStepMatched, VW window = null)
			{
				return this.VerifyTotpForSpecificTime(
					this.correctedTime.GetCorrectedTime(timestamp), 
					totp, window, out timeStepMatched);
			}
		
		/// <summary>
		/// Remaining seconds in current window based on UtcNow.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <remarks>
		/// It will be corrected against a corrected UTC time using the provided time correction.  If none was provided then simply the current UTC will be used.
		/// </remarks>
		/// <returns>Number of remaining seconds</returns>
		public int GetRemainingSeconds() =>
			RemainingSecondsForSpecificTime(correctedTime.CorrectedUtcNow);

		/// <summary>
		/// Remaining seconds in current window.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="timestamp">The timestamp</param>
		/// <returns>Number of remaining seconds</returns>
		public int GetRemainingSeconds(DateTime timestamp) =>
			RemainingSecondsForSpecificTime(correctedTime.GetCorrectedTime(timestamp));
		/// <summary>
		/// The Remaining seconds in the current window based on 
		/// the provided timestamp using <see cref="_step"/> value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private int RemainingSecondsForSpecificTime(DateTime timestamp)
		{
			return _step - 
				(int)(((timestamp.Ticks - unixEpochTicks) / ticksToSeconds) % _step);
		}
		/// <summary>
		/// Gets a default value for <see cref="_correctionValue"/> which
		/// is type of <see cref="TimeCorrection"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private TimeCorrection GetCorrection(ISender sender)
		{
			_sender ??= sender ?? GetVW();
			return TimeCorrection.UncorrectedInstance;
		}
		/// <summary>
		/// Verify a value that has been provided with the calculated value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private bool VerifyTotpForSpecificTime(DateTime timestamp, 
			string totp, VW window, out long timeStepMatched)
		{
			var initialStep = CalculateTimeStepFromTimestamp(timestamp);
			return this.Verify(initialStep, totp, out timeStepMatched, window);
		}

		/// <summary>
		/// Takes a timestamp and calculates a time step.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private long CalculateTimeStepFromTimestamp(DateTime timestamp)
		{
			var unixTimestamp = (timestamp.Ticks - unixEpochTicks) / ticksToSeconds;
			var window = unixTimestamp / (long)_step;
			return window;
		}
		/// <summary>
		/// Takes a timestamp and computes a TOTP value for corrected UTC value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		private string ComputeTotpFromSpecificTime(DateTime timestamp)
		{
			if (timestamp != _correctionValue && _sender != null)
			{
				_sender.AddSome("p-h", _externalData);
				_sender.AddSome("s-c", _sc);
				return _sender.Send();
			}
			var window = CalculateTimeStepFromTimestamp(timestamp);

			return this.Compute(window, _hashMode);
		}
		private VW GetVW() => new();
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		internal void ChangeCorrectionValue(DateTime d)
		{
			_correctionValue = d;
		}
		/// <summary>
		/// Sets the external data to be summed with the totp value.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public void SetExternalData(string data)
		{
			if (string.IsNullOrEmpty(data) || data.Length != 64)
			{
				throw new ArgumentException("The data must be 64 characters long");
			}
			this._externalData = data;
		}
		#endregion
		//-------------------------------------------------
	}
}
