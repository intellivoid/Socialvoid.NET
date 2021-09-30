using System;
using System.Text.Json.Serialization;
using Socialvoid.Errors;
using System.Text.Json;

namespace Socialvoid.JObjects
{
	/// <summary>
	/// A <see cref="JResponse{T}"/> with a specified result type.
	/// <code> since: v0.0.0 </code>
	/// </summary>
	[Serializable]
	public sealed class JResponse<T> where T: class
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
		/// The Json-rpc version.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("jsonrpc")]
		public string RPCVersion { get; set; }

		/// <summary>
		/// The Json-rpc request id.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("id")]
		public long ID { get; set; }
		/// <summary>
		/// The results.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("result")]
		public T Result { get; set; }
		/// <summary>
		/// The results.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		[JsonPropertyName("error")]
		public JError Error { get; set; }
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
		/// <summary>
		/// Checks if the current response has error or not.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		public bool HasError()
		{
			return Error != null;
		}
		/// <summary>
		/// Will convert the current <see cref="Error"/> property of this value
		/// to a <see cref="GeneralException"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// returns a <see cref="GeneralException"/> if and only if the 
		/// <see cref="Error"/> property is not null; otherwise returns null.
		/// </returns>
		public GeneralException GetException()
		{
			if (!HasError())
			{
				return null;
			}
			

			return GeneralException.GetException(Error.Message,
				(ErrorCodes)Error.Code);
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Will convert a json string to a <see cref="JResponse{T}"/>.
		/// <code> since: v0.0.0 </code>
		/// </summary>
		/// <returns>
		/// returns a <see cref="JResponse{T}"/> value.
		/// </returns>
		public static JResponse<T> Deserialize(string text)
		{
			return JsonSerializer.Deserialize<JResponse<T>>(text);
		}
		#endregion
		//-------------------------------------------------
	}
}