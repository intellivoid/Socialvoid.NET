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

namespace Socialvoid.SvObjects.Media
{
	/// <summary>
	/// ListW is a wrapper for <see cref="List{T}"/> that allows for the use
	/// of some custom methods.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class Document
	{
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
		public virtual string FileType { get; set; }
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
		/// Checks if this <see cref="DisplayPictureSize"/> has a 
		/// valid document.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public bool HasID() => !string.IsNullOrEmpty(ID);
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
		#endregion
		//-------------------------------------------------
	}
}
