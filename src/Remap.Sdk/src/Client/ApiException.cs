using Confiti.MoySklad.Remap.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents a MoySklad API Exception.
    /// </summary>
    [Serializable]
    public sealed class ApiException : Exception, ISerializable
    {
        private const string C_ErrorCode = "ErrorCode";

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

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiException(string message, Exception innerException = null)
            : base(message, innerException)
        { }

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
            : base(message)
        {
            ErrorCode = errorCode;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        private ApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCode = (int)info.GetValue(C_ErrorCode, typeof(int));
        }

        #endregion Ctor

        #region Methods

        /// <inheritdoc/>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(C_ErrorCode, ErrorCode);
            base.GetObjectData(info, context);
        }

        #endregion Methods
    }
}