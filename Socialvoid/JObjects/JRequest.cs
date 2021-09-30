using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Socialvoid.JObjects
{
	/// <summary>
	/// A <see cref="JRequest"/> object which contains basic information
	/// about an error returned by the server.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	[Serializable]
	public sealed class JRequest
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
		/// The JSON-RPC version. Should be equal to "2.0".
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("jsonrpc")]
		public string JsonRPC { get; set; } = "2.0";
		/// <summary>
		/// The error message.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("method")]
		public string Method { get; set; }
		/// <summary>
		/// The error message.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("id")]
		public long ID { get; set; }
		/// <summary>
		/// The error message.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("params")]
		public JArgs Arguments { get; set; }

		
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
		/// <summary>
		/// Changes the ID property of this value to <c>DateTime.Now.Ticks</c>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public void ChangeID()
		{
			ID = DateTime.Now.Ticks;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Serializes this request as a string.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public string Serialize()
		{
			return JsonSerializer.Serialize(this);
		}
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