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
using Sv = Socialvoid.Client.SocialvoidClient;

namespace Socialvoid.Security.Otp
{
	/// <summary>
	/// A verification window.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public abstract class WindowBase : ISender
	{
		//-------------------------------------------------
		#region static field's Region
		/// <summary>
		/// The external static client used when window cannot verify itself
		/// when parameters for doing so are not enough.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected static HttpClient _externalWindow;
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public bool IsExternalWindow { get; protected set; }
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected HttpRequestMessage _externalRequest;
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected string _pointing;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		internal WindowBase(bool allocate)
		{
			if (allocate)
			{
				_externalWindow ??= new();
			}
		}
		internal WindowBase()
		{
			_externalWindow ??= new();
			_externalRequest = new(HttpMethod.Get, GetPoiting());
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Send data to a remote service.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string Send() =>
			(_externalWindow == null || _externalRequest == null) ? null :
			Read(_externalWindow.Send(_externalRequest));
		/// <summary>
		/// Add data to be sent to a remote service.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public abstract bool AddSome(string key, string data);
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		protected abstract string GetPoiting();
		private string Read(HttpResponseMessage resp)
		{
			return Sv.ReadFromContent(resp.Content);
		}
		#endregion
		//-------------------------------------------------
	}
}
