using System;
using RestSharp;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// A delegate to ExceptionFactory method.
    /// </summary>
    /// <param name="methodName">The method name.</param>
    /// <param name="response">The rest response.</param>
    /// <returns>The exception.</returns>
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}