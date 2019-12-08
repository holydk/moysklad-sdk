using System.Collections.Generic;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a API response.
    /// </summary>
    public class ApiResponse<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status code (HTTP status code).
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP headers.
        /// </summary>
        /// <value>The HTTP headers</value>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Gets or sets the data (parsed HTTP body).
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; private set; }
        
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="data">The data (parsed HTTP body).</param>
        public ApiResponse(int statusCode, IDictionary<string, string> headers, T data)
        {
            StatusCode = statusCode;
            Headers = headers;
            Data = data;
        }
            
        #endregion
    }
}