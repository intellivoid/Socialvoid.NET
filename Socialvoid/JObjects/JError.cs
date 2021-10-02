using System;
using System.Text.Json.Serialization;

namespace Socialvoid.JObjects
{
	/// <summary>
	/// A <see cref="JError"/> object which contains basic information
	/// about an error returned by the server.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	[Serializable]
	public sealed class JError
	{
		//-------------------------------------------------
		#region Constant's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The response error code.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("code")]
		public int Code { get; set; }
		/// <summary>
		/// The error message.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("message")]
		public string Message { get; set; }
		
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		// some members here
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
		
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		#endregion
		//-------------------------------------------------
	}
}