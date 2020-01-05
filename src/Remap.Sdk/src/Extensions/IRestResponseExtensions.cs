using System;
using System.Linq;
using Confetti.MoySklad.Remap.Client;
using RestSharp;

namespace Confetti.MoySklad.Remap.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IRestResponse"/>.
    /// </summary>
    public static class IRestResponseExtensions
    {
        #region Methods

        /// <summary>
        /// Parses the <see cref="IRestResponse"/> to <see cref="ApiResponse{T}"/>.
        /// </summary>
        /// <param name="response">The REST response.</param>
        /// <param name="model">The model.</param>
        /// <typeparam name="T">The model type.</typeparam>
        /// <returns>The API response.</returns>
        public static ApiResponse<T> ToApiResponse<T>(this IRestResponse response, T model)
        {
            if (response == null)
                throw new System.ArgumentNullException(nameof(response));
            
            var responseHeaders = response.Headers
                ?.ToDictionary(x => x.Name, x => x.Value.ToString(), StringComparer.OrdinalIgnoreCase);

            return new ApiResponse<T>((int)response.StatusCode, responseHeaders, model);
        }
            
        #endregion
    }
}