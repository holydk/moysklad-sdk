using System.Collections.Generic;

namespace Confiti.MoySklad.Remap.Models
{
    /// <summary>
    /// Represents a API response.
    /// </summary>
    public class ApiResponse
    {
        #region Properties

        /// <summary>
        /// Gets the HTTP headers.
        /// </summary>
        /// <value>The HTTP headers</value>
        public IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets the status code (HTTP status code).
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiResponse" /> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers.</param>
        public ApiResponse(int statusCode, IDictionary<string, string> headers)
        {
            StatusCode = statusCode;
            Headers = headers;
        }

        #endregion Ctor
    }

    /// <summary>
    /// Represents a API response with payload.
    /// </summary>
    public class ApiResponse<T> : ApiResponse
    {
        #region Properties

        /// <summary>
        /// Gets the response payload (parsed HTTP body).
        /// </summary>
        /// <value>The response payload.</value>
        public T Payload { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="data">The data (parsed HTTP body).</param>
        public ApiResponse(int statusCode, IDictionary<string, string> headers, T data)
            : base(statusCode, headers)
        {
            Payload = data;
        }

        #endregion Ctor
    }
}