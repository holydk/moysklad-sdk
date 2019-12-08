using System.Collections.Generic;
using RestSharp;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the request context to prepare HTTP request.
    /// </summary>
    public class RequestContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets the relative path to the endpoint.
        /// </summary>
        /// <value>The relative path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        /// <value>The HTTP method.</value>
        public Method Method { get; set; }

        /// <summary>
        /// Gets or sets the HTTP content type.
        /// </summary>
        /// <value>The HTTP content type.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the HTTP post body.
        /// </summary>
        /// <value>The HTTP post body.</value>
        public object Body { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request query.
        /// </summary>
        /// <value>The HTTP request query.</value>
        public Dictionary<string, string> Query { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the HTTP request headers.
        /// </summary>
        /// <value>The HTTP request headers.</value>
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the form parameters for the HTTP request.
        /// </summary>
        /// <value>The form parameters for the HTTP request.</value>
        public Dictionary<string, string> Form { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the files for the HTTP request.
        /// </summary>
        /// <value>The files for the HTTP request.</value>
        public Dictionary<string, FileParameter> Files { get; set; } = new Dictionary<string, FileParameter>();

        /// <summary>
        /// Gets or sets the path parameters for the HTTP request.
        /// </summary>
        /// <value>The path parameters for the HTTP request.</value>
        public Dictionary<string, string> PathParameters { get; set; } = new Dictionary<string, string>();
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        public RequestContext()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RequestContext" /> class
        /// with relative path to the endpoint and HTTP method.
        /// </summary>
        /// <param name="path">The relative path.</param>
        /// <param name="method">The HTTP method.</param>
        public RequestContext(string path, Method method)
            : this()
        {
            Path = path;
            Method = method;
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Adds a query parameter to the HTTP request.
        /// </summary>
        /// <param name="name">The query parameter name.</param>
        /// <param name="value">The query parameter value.</param>
        public void AddQueryParameter(string name, string value)
        {
            Query[name] = value;
        }

        /// <summary>
        /// Adds a header parameter to the HTTP request.
        /// </summary>
        /// <param name="name">The header parameter name.</param>
        /// <param name="value">The header parameter value.</param>
        public void AddHeader(string name, string value)
        {
            Headers[name] = value;
        }

        /// <summary>
        /// Adds a form parameter to the HTTP request.
        /// </summary>
        /// <param name="name">The form parameter name.</param>
        /// <param name="value">The form parameter value.</param>
        public void AddFormParameter(string name, string value)
        {
            Form[name] = value;
        }

        /// <summary>
        /// Adds a file parameter to the HTTP request.
        /// </summary>
        /// <param name="name">The file parameter name.</param>
        /// <param name="value">The container for files to be uploaded with requests.</param>
        public void AddFormParameter(string name, FileParameter value)
        {
            Files[name] = value;
        }

        /// <summary>
        /// Adds a path parameter to the HTTP request.
        /// </summary>
        /// <param name="name">The path parameter name.</param>
        /// <param name="value">The path parameter value.</param>
        public void AddPathParameter(string name, string value)
        {
            PathParameters[name] = value;
        }
            
        #endregion
    }
}