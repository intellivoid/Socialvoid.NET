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

using System.Text.Json.Serialization;

namespace Socialvoid.SvObjects.Text
{
	/// <summary>
	/// The text entity object describes the text type, this is useful 
	/// for clients to render the given text correctly.
	/// For example a "@mention" will have a TextEntity with the value
	/// mention. So that the client can preform an action when this
	/// entity is clicked.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public class TextEntity: IEntity
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The string value for normal entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string NormalTypeStr = "NORMAL";
		/// <summary>
		/// The string value for bold entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string BoldTypeStr = "BOLD";
		/// <summary>
		/// The string value for italic entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string ItalicTypeStr = "ITALIC";
		/// <summary>
		/// The string value for code entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string CodeTypeStr = "CODE";
		/// <summary>
		/// The string value for strike-through entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string StrikeTypeStr = "STRIKE";
		/// <summary>
		/// The string value for underline entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string UnderlineTypeStr = "UNDERLINE";
		/// <summary>
		/// The string value for url entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string UrlTypeStr = "URL";
		/// <summary>
		/// The string value for mention entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string MentionTypeStr = "MENTION";
		/// <summary>
		/// The string value for hashtag entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public const string HashtagTypeStr = "HASHTAG";
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The text entity type.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("type")]
		public string Type
		{
			get => _typeStr ?? NormalTypeStr;
			set
			{
				switch (value)
				{
					case NormalTypeStr:
						_type = EntityTypes.Normal;
						break;
					case BoldTypeStr:
						_type = EntityTypes.Bold;
						break;
					case ItalicTypeStr:
						_type = EntityTypes.Italic;
						break;
					case CodeTypeStr:
						_type = EntityTypes.Code;
						break;
					case StrikeTypeStr:
						_type = EntityTypes.StrikeThrough;
						break;
					case UnderlineTypeStr:
						_type = EntityTypes.Underline;
						break;
					case UrlTypeStr:
						_type = EntityTypes.Url;
						break;
					case MentionTypeStr:
						_type = EntityTypes.Mention;
						break;
					case HashtagTypeStr:
						_type = EntityTypes.Hashtag;
						break;
					default:
						_invalid = true;
						break;
				}
				_typeStr = value;
			}
		}
		/// <summary>
		/// The offset for when the entity begins in the text.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("offset")]
		public int Offset { get; set; }
		/// <summary>
		/// The length of the entity.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("length")]
		public int Length { get; set; }
		/// <summary>
		/// The value of the entity, for styling entities such as BOLD,
		/// ITALIC, etc. this value will be null, but for values such as MENTION,
		/// HASHTAG &#38; URL the value will contain the respective value for the entity, for example a URL entity will contain a value of a http URL
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("value")]
		public string Value { get; set; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		private EntityTypes _type;
		private string _typeStr;
		private bool _invalid;
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
		public TextEntity()
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
		/// Checks if this <see cref="TextEntity"/> object has
		/// a valid <see cref="Value"/> property or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public virtual bool HasValue() => !string.IsNullOrEmpty(Value);
		/// <summary>
		/// Returns the type of this entity as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the type of this entity as <see cref="string"/>.
		/// </returns>
		public virtual string GetStringType() => _typeStr;
		/// <summary>
		/// Returns the type of this entity as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the type of this entity as <see cref="EntityTypes"/>.
		/// </returns>
		public virtual EntityTypes GetEnumType() => _type;
		/// <summary>
		/// Checks if the type of this entity is 
		/// valid/supported by this client
		/// or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsTypeValid() => !_invalid;
		/// <summary>
		/// Checks if the entity type is normal or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is normal;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsNormal() => _type == EntityTypes.Normal;
		/// <summary>
		/// Checks if the entity type is bold or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is bold;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsBold() => _type == EntityTypes.Bold;
		/// <summary>
		/// Checks if the entity type is italic or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is italic;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsItalic() => _type == EntityTypes.Italic;
		/// <summary>
		/// Checks if the entity type is code or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is code;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsCode() => _type == EntityTypes.Code;
		/// <summary>
		/// Checks if the entity type is strike-through or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is strike-through;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsStrikeThrough() => _type == EntityTypes.StrikeThrough;
		/// <summary>
		/// Checks if the entity type is underline or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is underline;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsUnderline() => _type == EntityTypes.Underline;
		/// <summary>
		/// Checks if the entity type is url or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is url;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsUrl() => _type == EntityTypes.Url;
		/// <summary>
		/// Checks if the entity type is mention or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is mention;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsMention() => _type == EntityTypes.Mention;
		/// <summary>
		/// Checks if the entity type is hashtag or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is hashtag;
		/// otherwise, <c>false</c>.
		/// </returns>
		public virtual bool IsHashtag() => _type == EntityTypes.Hashtag;
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