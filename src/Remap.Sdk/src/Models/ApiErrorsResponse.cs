namespace Confiti.MoySklad.Remap.Models
{
	/// <summary>
	/// Represents a response containing the <see cref="ApiError"/>'s.
	/// </summary>
	public class ApiErrorsResponse
	{
		#region Properties

		/// <summary>
		/// Gets or sets the errors.
		/// </summary>
		/// <value>The errors.</value>
		public ApiError[] Errors { get; set; }

		#endregion Properties
	}
}