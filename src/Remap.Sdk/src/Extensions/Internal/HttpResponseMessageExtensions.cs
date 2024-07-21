using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

            var stream = await response.Content.ReadAsStreamAsync();
            if (type == typeof(Stream))
                return stream;

            using (stream)
            {
                if (response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                {
                    using (var streamReader = new StreamReader(stream))
                    using (var reader = new JsonTextReader(streamReader))
                    {
                        try
                        {
                            return await Task.Run(() => JsonSerializer.CreateDefault(settings).Deserialize(reader, type));
                        }
                        catch (JsonException e)
                        {
                            throw new ApiException($"Error when deserializing HTTP response content. {e.Message}");
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the <see cref="ApiException"/> from <see cref="HttpResponseMessage"/> object.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/>.</param>
        /// <param name="callerName">The caller name.</param>
        /// <param name="settings">The <see cref="JsonSerializerSettings"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="response"/> is null.</exception>
        public static async Task<ApiException> ToApiException(this HttpResponseMessage response, string callerName, JsonSerializerSettings settings = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var errorMessage = new StringBuilder();
            var status = (int)response.StatusCode;

            errorMessage.AppendLine($"Error calling '{callerName}'. HTTP status code - {status}.");

            var errorsResponse = await response.DeserializeAsync(typeof(ApiErrorsResponse), settings) as ApiErrorsResponse;
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