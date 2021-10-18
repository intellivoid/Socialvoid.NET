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

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Socialvoid.Security;
using Socialvoid.SvObjects.Media;

namespace Socialvoid.SvObjects
{
	/// <summary>
	/// A peer object provides a basic description and identification 
	/// of a peer entity that can contain information used to display the peer
	/// on the client or basic flags and properties of the peer to pre-determine
	/// what actions are available for a peer.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class Peer: IIdentitiable<string>, IFlagable<string>
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The string value for normal user account type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string UserTypeStr = "USER";
		/// <summary>
		/// The string value for a bot account that performs automated
		/// actions on the network.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string BotTypeStr = "BOT";
		/// <summary>
		/// The string value for a proxy account that mirrors content
		/// from another platform.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string ProxyTypeStr = "PROXY";
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("id")]
		public string PeerID { get; set; }
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("type")]
		public string PeerType
		{
			get => _typeStr;
			set
			{
				switch (value)
				{
					case UserTypeStr:
						_type = PeerTypes.User;
						break;
					case BotTypeStr:
						_type = PeerTypes.Bot;
						break;
					case ProxyTypeStr:
						_type = PeerTypes.Proxy;
						break;
					default:
						_type = PeerTypes.None;
						break;
				}
				_typeStr = value;
			}
		}
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; }
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("username")]
		public string Username { get; set; }
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("display_picture_sizes")]
		public List<DisplayPictureSize> DisplayPictureSizes { get; set; }
		/// <summary>
		/// The ID of the session obtained when establishing a session.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("flags")]
		public string[] Flags { get; set; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		private string _typeStr;
		private PeerTypes _type;
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
		///
		/// </summary>
		public Peer()
		{

		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Initialize Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Returns the flags of this object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the flags of this object as an array of 
		/// <see cref="string"/> objects.
		/// </returns>
		public virtual string[] GetFlags() => Flags;
		/// <summary>
		/// Checks if this object has any flag or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array is not null and it's length
		/// is more than zero; otherwise <c>false</c>.
		/// </returns>
		public virtual bool HasFlag() => Flags != null && Flags.Length > 0;
		/// <summary>
		/// Checks if this object has at the very least one of the specified
		/// flags or not. If you want to check for all of the flags, please
		/// use <see cref="HasFlags(string[])"/> method.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array of this object contains at the very
		/// least one of the specified flags; otherwise <c>false</c>.
		/// </returns>
		public virtual bool HasFlag(params string[] flags)
		{
			if (flags == null || flags.Length == 0 || !HasFlag())
			{
				return false;
			}
			else if (flags.Length == 1)
			{
				// easy path: inlined so we can reduce the running time.
				foreach (var f in Flags)
				{
					if (f == flags[default])
					{
						return true;
					}
				}
			}

			foreach(var f in flags)
			{
				if (hasFlag(f))
				{
					return true;
				}
			}

			return false;
		}
		/// <summary>
		/// Returns the length of the flag arrays of this object.
		/// If the flag array is empty, this method will return zero.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual int GetFlagLength() =>
			Flags == null ? default : Flags.Length;
		/// <summary>
		/// Checks if the length of the flag array is zero or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual bool HasZeroFlags() => GetFlagLength() == default;
		/// <summary>
		/// Checks if this object has all of the specified flags or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array of this object has all of the
		/// specified flags; otherwise <c>false</c>.
		/// </returns>
		public virtual bool HasFlags(params string[] flags)
		{
			if (flags == null || flags.Length == 0 || !HasFlag())
			{
				return false;
			}
			else if (flags.Length == 1)
			{
				// easy path: inlined so we can reduce the running time.
				foreach (var f in Flags)
				{
					if (f != flags[default])
					{
						return false;
					}
				}
			}

			foreach (var f in flags)
			{
				if (!hasFlag(f))
				{
					return false;
				}
			}

			return true;
		}
		/// <summary>
		/// Returns the flag of this object using the specified index
		/// in the flag array.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <param name="index">
		/// the index of the flag.
		/// </param>
		/// <param name="ex">
		/// set this argument to <c>true</c> if you want the method to
		/// throw an exception in the case it couldn't return any flag.
		/// if you set this to <c>false</c> the method will return
		/// <c>null</c> (or default).
		/// </param>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual string GetFlag(int index, bool ex = true)
		{
			if (HasZeroFlags())
			{
				if (ex)
				{
					throw new InvalidOperationException(
						$"flags length of this {GetType().ToString()} is 0");
				}
				return null;
			}
			if (index < 0)
			{
				if (ex)
				{
					throw new ArgumentException(
						"index cannot be negatice",
						nameof(index));
				}
				return null;
			}
			if (index > GetFlagLength())
			{
				if (ex)
				{
					throw new ArgumentException(
						$"index({index}), cannot be more than"+
						$" flags array length({GetFlagLength()})",
						nameof(index));
				}
				return null;
			}
			return Flags[index];
		}

		/// <summary>
		/// Checks if the flag array of this object contains a single flag
		/// or not.
		/// </summary>
		protected bool hasFlag(string flag)
		{
			if (string.IsNullOrWhiteSpace(flag))
			{
				return false;
			}
			foreach (var f in Flags)
			{
				if (f == flag)
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Returns the ID of this <see cref="Peer"/> object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string GetID() => PeerID;
		/// <summary>
		/// Checks if the ID of this object is valid.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the ID is valid;
		/// otherwise, <c>false</c>.
		/// </returns>
		public bool HasValidID() =>
			!string.IsNullOrWhiteSpace(PeerID);
		/// <summary>
		/// Checks if the type of this peer is 
		/// valid/supported by this client or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsTypeValid() => _type != PeerTypes.None;
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
	}
}