﻿using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Client.Json;
using Newtonsoft.Json;

namespace System.Net.Http
{
    /// <summary>
    /// Extension methods for <see cref="HttpResponseMessage"/>.
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        #region Methods

        /// <summary>
        /// Deserializes the <see cref="HttpResponseMessage"/> into a proper object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="type">The destination type.</param>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/>.</param>
        /// <returns>The <see cref="Task"/> containing the object or null.</returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> or <paramref name="type"/> is null.</exception>
        /// <exception cref="ApiException">Throws if deserialization failed with an error.</exception>
        public static async Task<object> DeserializeAsync(this HttpResponseMessage response, Type type, JsonSerializerSettings settings = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                if (type == typeof(Stream))
                {
                    var memStream = new MemoryStream();
                    await stream.CopyToAsync(memStream).ConfigureAwait(false);

                    return memStream;
                }

                if (response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                {
                    try
                    {
                        return await JsonSerializerHelper
                            .ReadFromStreamAsync(stream, type, settings)
                            .ConfigureAwait(false);
                    }
                    catch (JsonException e)
                    {
                        throw new ApiException($"Error when deserializing HTTP response content. {e.Message}", e);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the <see cref="ApiException"/> from <see cref="HttpResponseMessage"/> object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> is null.</exception>
        public static async Task<ApiException> ToApiExceptionAsync(this HttpResponseMessage response, string message, JsonSerializerSettings settings = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var errorMessage = new StringBuilder();
            var status = (int)response.StatusCode;

            errorMessage.AppendLine($"{message} HTTP status code - {status}.");

            var errorsResponse = await response
                .DeserializeAsync(typeof(ApiErrorsResponse), settings)
                .ConfigureAwait(false) as ApiErrorsResponse;
            if (errorsResponse?.Errors?.Any() == true)
            {
                for (var i = 0; i < errorsResponse.Errors.Length; i++)
                {
                    errorMessage.AppendLine($"\tError {i}:");
                    errorMessage.AppendLine($"\t\tCode: {errorsResponse.Errors[i].Code}");
                    errorMessage.AppendLine($"\t\tDescription: {errorsResponse.Errors[i].Error}");
                    errorMessage.Append($"\t\tMore info: {errorsResponse.Errors[i].MoreInfo}{(i == errorsResponse.Errors.Length - 1 ? string.Empty : Environment.NewLine)}");
                }
            }

            return new ApiException(status, errorMessage.ToString(), response.Headers.ToDictionary(), errorsResponse?.Errors);
        }

        #endregion Methods
    }
}