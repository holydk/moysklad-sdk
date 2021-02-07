using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Models;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a API Exception.
    /// </summary>
    public class ApiException : Exception
    {
        #region Properties

        /// <summary>
        /// Gets the error code (HTTP status code).
        /// </summary>
        /// <value>The error code (HTTP status code).</value>
        public int ErrorCode { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public ApiError[] Errors { get; }

        /// <summary>
        /// Gets the HTTP headers.
        /// </summary>
        /// <value>The HTTP headers</value>
        public IDictionary<string, string> Headers { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="errors">The errors.</param>
        public ApiException(int errorCode, string message, IDictionary<string, string> headers, ApiError[] errors) 
            : base(message)
        {
            ErrorCode = errorCode;
            Headers = headers;
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorCode">The HTTP status code.</param>
        /// <param name="message">The error message.</param>
        public ApiException(int errorCode, string message)
            :base(message)
        {
            ErrorCode = errorCode;
        }
            
        #endregion
    }
}