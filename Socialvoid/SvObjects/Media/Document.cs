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
using System.Text.Json.Serialization;
using Socialvoid.Security;

namespace Socialvoid.SvObjects.Media
{
	/// <summary>
	/// A document object contains basic information about the file associated
	/// with the document and the document ID used to retrieve the document
	/// from the CDN Server.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class Document: IIdentitiable<string>, IFlagable<string>
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The file is a general file, it doesn't consist of any special type
		/// that was detected by the server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string DocumentTypeStr = "DOCUMENT";
		/// <summary>
		/// The file is an image file type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string PhotoTypeStr = "PHOTO";
		/// <summary>
		/// The file is an video file type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string VideoTypeStr = "VIDEO";
		/// <summary>
		/// The file is an audio file type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string AudioTypeStr = "AUDIO";
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The width of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("id")]
		public virtual string ID { get; set;}
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("file_mime")]
		public virtual string MimeType { get; set; }
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("file_name")]
		public virtual string FileName { get; set; }
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("file_size")]
		public virtual int FileSize { get; set; }
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("file_type")]
		public virtual string FileType
		{
			get => _typeStr;
			set
			{
				switch (value)
				{
					case DocumentTypeStr:
						_type = FileTypes.Document;
						break;
					case PhotoTypeStr:
						_type = FileTypes.Photo;
						break;
					case VideoTypeStr:
						_type = FileTypes.Video;
						break;
					case AudioTypeStr:
						_type = FileTypes.Audio;
						break;
					default:
						_invalidType = true;
						break;
				}
				_typeStr = value;
			}
		}
		/// <summary>
		/// The height of the picture.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("flags")]
		public virtual string[] Flags { get; set; }
		/// <summary>
		/// The Unix Timestamp for when this document was first created.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("created_timestamp")]
		public virtual string CreatedAt
		{
			get => _createdAt.Ticks.ToString();
			set => _createdAt = new DateTime(Convert.ToInt64(value));
		}
		#endregion
		//-------------------------------------------------
		#region field's Region
		private bool _invalidType;
		private string _typeStr;
		private FileTypes _type;
		private long _ticks;
		private DateTime _createdAt = DateTime.MinValue;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Creates a new instance of a <see cref="Document"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public Document()
		{

		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// 
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public FileTypes GetEnumFileType() => _type;
		/// <summary>
		/// Returns the type of this file as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the type of this file as <see cref="string"/>.
		/// </returns>
		public virtual string GetStringType() => _typeStr;
		/// <summary>
		/// Checks if the type of this file is 
		/// valid/supported by this client.
		/// or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsTypeValid() => !_invalidType;
		/// <summary>
		/// Checks if the file type is document or not.
		/// Document type file is a general file, it doesn't consist of any 
		/// special type that was detected by the server.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the file type is considered as a document;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsDocumentType() => _type == FileTypes.Document;
		/// <summary>
		/// Checks if the file type is photo or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the file type is considered as a photo;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsPhotoType() => _type == FileTypes.Photo;
		/// <summary>
		/// Checks if the file type is video or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the file type is considered as a video;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsVideoType() => _type == FileTypes.Video;
		/// <summary>
		/// Checks if the file type is audio or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the file type is considered as an audio;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsAudioType() => _type == FileTypes.Audio;
		/// <summary>
		/// converts file size to KB.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public float ConvertToKB() => FileSize / 1024f;
		/// <summary>
		/// converts file size to MB.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public float ConvertToMB() => ConvertToKB() / 1024f;
		/// <summary>
		/// converts file size to GB.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public float ConvertToGB() => ConvertToMB() / 1024f;
		/// <summary>
		/// converts file size to GB.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public System.DateTime GetTimeStamp() => 
			_createdAt != DateTime.MinValue ? _createdAt:
			new(Convert.ToInt64(CreatedAt));
		/// <summary>
		/// Checks if the ID of this object is valid.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the ID is valid;
		/// otherwise, <c>false</c>.
		/// </returns>
		public bool HasValidID() =>
			!string.IsNullOrWhiteSpace(ID);
		/// <summary>
		/// Returns the ID of this <see cref="Document"/> object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string GetID() => ID;
		/// <summary>
		/// Returns the flags of this object.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the flags of this object as an array of 
		/// <see cref="string"/> objects.
		/// </returns>
		public string[] GetFlags() => Flags;
		/// <summary>
		/// Checks if this object has any flag or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array is not null and it's length
		/// is more than zero; otherwise <c>false</c>.
		/// </returns>
		public bool HasFlag() => Flags != null && Flags.Length > 0;
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
		public bool HasFlag(params string[] flags)
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
		public int GetFlagLength() =>
			Flags == null ? default : Flags.Length;
		/// <summary>
		/// Checks if the length of the flag array is zero or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public bool HasZeroFlags() => GetFlagLength() == default;
		/// <summary>
		/// Checks if this object has all of the specified flags or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the flag array of this object has all of the
		/// specified flags; otherwise <c>false</c>.
		/// </returns>
		public bool HasFlags(params string[] flags)
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
		public string GetFlag(int index, bool ex = true)
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
		private bool hasFlag(string flag)
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
		#endregion
		//-------------------------------------------------
	}
}
