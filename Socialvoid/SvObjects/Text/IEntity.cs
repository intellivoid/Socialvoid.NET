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

namespace Socialvoid.SvObjects.Text
{
	/// <summary>
	/// This interface is created for solving compability issues.
	/// Most of the GUI clients (and libraries) define their own
	/// unique classes (or structures) with similliar functionality to
	/// <see cref="TextEntity"/> class which is used for showing texts
	/// on the UI to the users. This interface makes it easier to write
	/// wrapper classes for them and use them more easily.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	public interface IEntity
	{
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Returns the type of this entity as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the type of this entity as <see cref="string"/>.
		/// </returns>
		string GetStringType();
		/// <summary>
		/// Returns the type of this entity as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// the type of this entity as <see cref="EntityTypes"/>.
		/// </returns>
		EntityTypes GetEnumType();
		/// <summary>
		/// Checks if the type of this entity is valid/supported by this client
		/// or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the type is valid and supported;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsTypeValid();
		/// <summary>
		/// Checks if this <see cref="IEntity"/> object has
		/// a valid value property or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if this object has a value;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool HasValue();
		/// <summary>
		/// Checks if the entity type is normal or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is normal;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsNormal();
		/// <summary>
		/// Checks if the entity type is bold or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is bold;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsBold();
		/// <summary>
		/// Checks if the entity type is italic or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is italic;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsItalic();
		/// <summary>
		/// Checks if the entity type is code or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is code;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsCode();
		/// <summary>
		/// Checks if the entity type is strike-through or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is strike-through;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsStrikeThrough();
		/// <summary>
		/// Checks if the entity type is underline or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is underline;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsUnderline();
		/// <summary>
		/// Checks if the entity type is url or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is url;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsUrl();
		/// <summary>
		/// Checks if the entity type is mention or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is mention;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsMention();
		/// <summary>
		/// Checks if the entity type is hashtag or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// <c>true</c> if the entity type is hashtag;
		/// otherwise, <c>false</c>.
		/// </returns>
		bool IsHashtag();
		#endregion
		//-------------------------------------------------
	}
}