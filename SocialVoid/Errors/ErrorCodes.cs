/*
 * This file is part of SocialVoid.NET Project (https://github.com/Intellivoid/SocialVoid.NET).
 * Copyright (c) 2021 SocialVoid.NET Authors.
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

namespace SocialVoid.Errors 
{
	/// <summary>
	/// All error codes received from the SocialVoid servers.
	/// <code> Since: v0.0.0 </code>
	/// </summary>
	public enum ErrorCodes
	{
		//-------------------------------------------------
		#region Unknown Error
		/// <summary>
		/// This error code will be returned when the error is not
		/// implimented on client-side at all.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		UnknownError = 0,
		#endregion
		//-------------------------------------------------
		#region Validation Errors
		/// <summary>
		/// This error code will be returned when the given username
		/// is invalid and does not meet the specification.
		/// <code> Since: v0.0.0 </code>
		/// <!--
		/// These are errors raised when the client passes
		/// on parameters or data that is invalid in some way or another.
		/// -->
		/// </summary>
		InvalidUsername = 8448,
		/// <summary>
		/// This error code will be returned when the given password is 
		/// invalid and/or insecure and does not meet the specification.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidPassword = 8449,
		/// <summary>
		/// This error code will be returned when the First Name provided
		/// contains invalid characters and or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidFirstName = 8450,
		/// <summary>
		/// This error code will be returned when the Last Name provided
		/// contains invalid characters and or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidLastName = 8451,
		/// <summary>
		/// This error code will be returned when the Biography is too long or
		/// contains invalid characters;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidBiography = 8452,
		/// <summary>
		/// This error code will be returned when the given username
		/// is already registered in the server and cannot be used.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		UsernameAlreadyExists = 8453,
		/// <summary>
		/// This error code will be returned when the client provided
		/// an invalid peer identification as input.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidPeerInput = 8454,
		/// <summary>
		/// This error code will be returned when the post contains
		/// invalid characters or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidPostText = 8455,
		/// <summary>
		/// This error code will be returned when the client's public hash
		/// is invalid and cannot be identified as a sha256.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidClientPublicHash = 8456,
		/// <summary>
		/// This error code will be returned when the client's private hash
		/// is invalid and cannot be identified as a sha256.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidClientPrivateHash = 8457,
		/// <summary>
		/// This error code will be returned when the version is invalid
		/// or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidVersion = 8459,
		/// <summary>
		/// This error code will be returned when the client name contains
		/// invalid characters or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidClientName = 8460,
		/// <summary>
		/// This error code will be returned when the session identification
		/// object is invalid;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidSessionIdentification = 8461,

		/// <summary>
		/// This error code will be returned when the platform name contains
		/// invalid characters or is too long;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		InvalidPlatform = 8464,
		#endregion
		//-------------------------------------------------
		#region Authentication Errors
		/// <summary>
		/// This error code will be returned when the given login credentials
		/// are incorrect.
		/// <code> Since: v0.0.0 </code>
		/// <!--
		/// These errors are raised when anything related to authentication
		/// has failed, this can include things from when trying 
		/// to authenticate to session challenge errors.
		/// -->
		/// </summary>
		IncorrectLoginCredentials = 8704,
		/// <summary>
		/// This error code will be returned when the given two-factor
		/// authentication code is incorrect.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		IncorrectTwoFactorAuthenticationCode = 8705,
		/// <summary>
		/// This error code will be returned when the user does not support
		/// this method of authentication;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		AuthenticationNotApplicable = 	8706,
		/// <summary>
		/// This error code will be returned when the requested session
		/// was not found in the database on server-side.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		SessionNotFound	= 8707,
		/// <summary>
		/// This error code will be returned when the client attempts
		/// to invoke a method that requires authentication.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		NotAuthenticated	= 8708,
		/// <summary>
		/// This error code will be returned when the user/entity uses
		/// a Private Access Token to authenticate and the client
		/// attempted to authenticate in another way.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		PrivateAccessTokenRequired	= 8709,
		/// <summary>
		/// This error code will be returned when the authentication process
		/// failed for some unexpected reason;
		/// please see the message for further details.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		AuthenticationFailure	= 8710,
		/// <summary>
		/// This error code will be returned when the given session
		/// challenge answer is incorrect or out of sync.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		BadSessionChallengeAnswer	= 8711,
		/// <summary>
		/// This error code will be returned when the Two-Factor 
		/// Authentication is required and so the client must repeat
		/// the same request but  provide a Two-Factor authentication 
		/// code as well.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		TwoFactorAuthenticationRequired	= 8712,
		/// <summary>
		/// This error code will be returned when the client is attempting
		/// to authenticate when already authenticated.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		AlreadyAuthenticated	= 8713,
		/// <summary>
		/// This error code will be returned when trying to use a
		/// session that has been expired.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		SessionExpired	= 8714,
		#endregion
		//-------------------------------------------------
		#region Media Errors
		// TODO: This part is a work in progress,
		// media has yet to be implemented on the server-side.
		#endregion
		//-------------------------------------------------
		#region Network Errors
		/// <summary>
		/// This error code will be returned when the requested user entity
		/// was not found on the server-side.
		/// <code> Since: v0.0.0 </code>
		/// <!--
		/// These are the catch-all errors when dealing with the network, from 
		/// finding peers, following them, posting, etc...
		/// -->
		/// </summary>
		PeerNotFound = 12544,
		/// <summary>
		/// This error code will be returned when the client requested
		/// a post that isn't found (or does not exist on the server-side).
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		PostNotFound = 12545,
		/// <summary>
		/// This error code will be returned when the client requested a post
		/// that was deleted.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		PostDeleted = 12546,
		/// <summary>
		/// This error code will be returned when the client attempts to
		/// repost a post that has already been reposted (by the same user).
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		AlreadyReposted = 12547,
		/// <summary>
		/// This error code will be returned when there was an error while
		/// trying to upload one or more files to the server.
		/// <code> Since: v0.0.0 </code>
		/// </summary>
		FileUploadError = 12548,
		#endregion
		//-------------------------------------------------
		#region Server Errors
		/// <summary>
		/// This error code will be returned when there was an unexpected
		/// error while trying to process your request.
		/// <code> Since: v0.0.0 </code>
		/// <!--
		/// These error codes are usually returned as a last resort
		/// when something is wrong with the server.
		/// -->
		/// </summary>
		InternalServerError = 16384,
		#endregion
		//-------------------------------------------------
	}
}

