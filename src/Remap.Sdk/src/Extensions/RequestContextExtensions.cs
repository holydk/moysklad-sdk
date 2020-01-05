using System;
using System.Collections.Generic;
using RestSharp;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Extension methods for <see cref="RequestContext"/>.
    /// </summary>
    public static class RequestContextExtensions
    {
        #region Methods

        /// <summary>
        /// Adds the relative path to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="path">The relative path to the endpoint.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithPath(this RequestContext context, string path)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Path = path;
            return context;
        }

        /// <summary>
        /// Adds the HTTP method to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="method">The HTTP method.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithMethod(this RequestContext context, Method method)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Method = method;
            return context;
        }

        /// <summary>
        /// Adds the content type to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="contentType">The content type.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithContentType(this RequestContext context, string contentType)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.ContentType = contentType;
            return context;
        }

        /// <summary>
        /// Adds the body to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="body">The body.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithBody(this RequestContext context, object body)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Body = body;
            return context;
        }

        /// <summary>
        /// Adds the query to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="query">The query.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithQuery(this RequestContext context, Dictionary<string, string> query)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var parameter in query)
                context.AddQueryParameter(parameter.Key, parameter.Value);
            return context;
        }

        /// <summary>
        /// Adds the query parameter to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The query parameter name.</param>
        /// <param name="value">The query parameter value.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithQuery(this RequestContext context, string name, string value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.AddQueryParameter(name, value);
            return context;
        }

        /// <summary>
        /// Adds the headers to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="headers">The headers.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithHeaders(this RequestContext context, Dictionary<string, string> headers)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var header in headers)
                context.AddHeader(header.Key, header.Value);
            return context;
        }

        /// <summary>
        /// Adds the header to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithHeader(this RequestContext context, string name, string value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.AddHeader(name, value);
            return context;
        }

        /// <summary>
        /// Adds the accept header to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="acceptHeader">The accept header value.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithAccept(this RequestContext context, string acceptHeader)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.AddHeader("Accept", acceptHeader);
            return context;
        }

        /// <summary>
        /// Adds the form to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="form">The form.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithForm(this RequestContext context, Dictionary<string, string> form)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var formParameter in form)
                context.AddHeader(formParameter.Key, formParameter.Value);
            return context;
        }

        /// <summary>
        /// Adds the file parameter to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The file parameter name.</param>
        /// <param name="fileParameter">The file parameter.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithFile(this RequestContext context, string name, FileParameter fileParameter)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.AddFileParameter(name, fileParameter);
            return context;
        }

        /// <summary>
        /// Adds the file parameters to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="files">The file parameters.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithFiles(this RequestContext context, Dictionary<string, FileParameter> files)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var fileParameter in files)
                context.AddFileParameter(fileParameter.Key, fileParameter.Value);
            return context;
        }

        /// <summary>
        /// Adds the path parameter to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="name">The path parameter name.</param>
        /// <param name="value">The path parameter value.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithPathParameter(this RequestContext context, string name, string value)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.AddPathParameter(name, value);
            return context;
        }

        /// <summary>
        /// Adds the path parameters to the request context.
        /// </summary>
        /// <param name="context">The request context.</param>
        /// <param name="pathParameters">The path parameters.</param>
        /// <returns>The request context.</returns>
        public static RequestContext WithPathParameters(this RequestContext context, Dictionary<string, string> pathParameters)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            foreach (var pathParameter in pathParameters)
                context.AddPathParameter(pathParameter.Key, pathParameter.Value);
            return context;
        }
            
        #endregion
    }
}