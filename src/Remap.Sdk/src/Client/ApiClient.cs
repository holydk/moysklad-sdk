using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the API client is mainly responsible for making the HTTP call to the API backend.
    /// </summary>
    public class ApiClient
    {
        #region Fields

        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };
            
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the RestClient.
        /// </summary>
        /// <value>The instance of the RestClient.</value>
        public virtual RestClient RestClient { get; set; }

        /// <summary>
        /// Gets or sets the API configuration.
        /// </summary>
        /// <value>The instance of the API configuration.</value>
        public virtual Configuration Configuration { get; set; }
            
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ApiClient" /> class
        /// with the default base path and the default configuration if not specified.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        /// <param name="configuration">The API configuration settings.</param>
        public ApiClient(string basePath = "https://online.moysklad.ru", Configuration configuration = null)
        {
           if (string.IsNullOrEmpty(basePath))
                throw new ArgumentException(nameof(basePath));

            RestClient = new RestClient(basePath);
            Configuration = configuration ?? Configuration.Default;
        }
            
        #endregion
    
        #region Methods

        /// <summary>
        /// Executes the http request synchronously.
        /// </summary>
        /// <param name="context">The request context to prepare http request.</param>
        /// <returns>The http resonse.</returns>
        public virtual IRestResponse Call(RequestContext context)
        {
            var request = PrepareRequest(context);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            InterceptRequest(request);
            var response = RestClient.Execute(request);
            InterceptResponse(request, response);

            return response;
        }

        /// <summary>
        /// Executes the http request asynchronously.
        /// </summary>
        /// <param name="context">The request context to prepare http request.</param>
        /// <returns>The http resonse.</returns>
        public virtual async Task<IRestResponse> CallAsync(RequestContext context)
        {
            var request = PrepareRequest(context);

            RestClient.Timeout = Configuration.Timeout;
            RestClient.UserAgent = Configuration.UserAgent;

            InterceptRequest(request);
            var response = await RestClient.ExecuteTaskAsync(request);
            InterceptResponse(request, response);

            return response;
        }

        /// <summary>
        /// Serializes an input (model) into JSON string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The JSON string.</returns>
        public virtual string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">The object type.</param>
        /// <returns>The object representation of the JSON string.</returns>
        public virtual object Deserialize(IRestResponse response, Type type)
        {
            // return byte array
            if (type == typeof(byte[]))
                return response.RawBytes;

            if (type == typeof(Stream))
            {
                var headers = response.Headers;
                if (headers != null)
                {
                    var filePath = String.IsNullOrEmpty(Configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : Configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$", RegexOptions.IgnoreCase);
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(response.RawBytes);
                return stream;
            }

            // return a datetime object
            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime"))
                return DateTime.Parse(response.Content,  null, System.Globalization.DateTimeStyles.RoundtripKind);

            // return primitive type
            if (type == typeof(string) || type.Name.StartsWith("System.Nullable"))
                return ConvertType(response.Content, type);

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(response.Content, type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>
        /// Allows for extending request processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        protected virtual void InterceptRequest(IRestRequest request) { }

        /// <summary>
        /// Allows for extending response processing for <see cref="ApiClient"/> generated code.
        /// </summary>
        /// <param name="request">The RestSharp request object</param>
        /// <param name="response">The RestSharp response object</param>
        protected virtual void InterceptResponse(IRestRequest request, IRestResponse response) { }

        #endregion

        #region Utilities

        private RestRequest PrepareRequest(RequestContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            
            var request = new RestRequest(context.Path, context.Method);

            // add path parameter, if any
            foreach(var param in context.PathParameters)
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);

            // add header parameter, if any
            foreach(var param in context.Headers)
                request.AddHeader(param.Key, param.Value);

            // add query parameter, if any
            foreach(var param in context.Query)
                request.AddQueryParameter(param.Key, param.Value);

            // add form parameter, if any
            foreach(var param in context.Form)
                request.AddParameter(param.Key, param.Value);

            // add file parameter, if any
            foreach(var param in context.Files)
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentLength, param.Value.ContentType);

            if (context.Body != null)
            {
                var bodyType = context.Body.GetType();
                if (bodyType == typeof(string))
                    request.AddParameter(ContentType.Json, context.Body, ParameterType.RequestBody);
                else if (bodyType == typeof(byte[]))
                    request.AddParameter(context.ContentType, context.Body, ParameterType.RequestBody);
            }

            return request;
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'.
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public static string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
                return null;

            if (contentTypes.Contains(ContentType.Json, StringComparer.OrdinalIgnoreCase))
                return ContentType.Json;

            // use the first content type specified in 'consumes'
            return contentTypes[0]; 
        }

        /// <summary>
        /// Select the Accept header's value from the given accepts array:
        /// if JSON exists in the given array, use it;
        /// otherwise use all of them (joining into a string).
        /// </summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public static string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
                return null;

            if (accepts.Contains(ContentType.Json, StringComparer.OrdinalIgnoreCase))
                return ContentType.Json;

            return String.Join(",", accepts);
        }

        /// <summary>
        /// Creates the file parameter based on <see cref="Stream" />.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="stream">The input stream.</param>
        /// <returns>The file parameter.</returns>
        public static FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
                return FileParameter.Create(name, ReadAsBytes(stream), Path.GetFileName(((FileStream)stream).Name));
            else
                return FileParameter.Create(name, ReadAsBytes(stream), "no_file_name_provided");
        }

        /// <summary>
        /// Converts <see cref="Stream" /> to byte array.
        /// Credit/Ref: http://stackoverflow.com/a/221941/677735
        /// </summary>
        /// <param name="input">The input stream to be converted.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ReadAsBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Encodes string in base64 format.
        /// </summary>
        /// <param name="text">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string Base64Encode(string text)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Sanitizes filename by removing the path.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The filename.</returns>
        public static string SanitizeFilename(string filename)
        {
            var match = Regex.Match(filename, @".*[/\\](.*)$");

            if (match.Success)
                return match.Groups[1].Value;
            else
                return filename;
        }

        /// <summary>
        /// Convertes the date time to string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The date time as string.</returns>
        public string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString(Configuration.DateTimeFormat);
        }

        /// <summary>
        /// Convertes the date time offset to string.
        /// </summary>
        /// <param name="dateTimeOffset">The date time offset.</param>
        /// <returns>The date time offset as string.</returns>
        public string DateTimeOffsetToString(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString(Configuration.DateTimeFormat);
        }

        /// <summary>
        /// Convertes the list to string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <typeparam name="T">The list item type.</typeparam>
        /// <returns>The list as string.</returns>
        public string ListToString<T>(IList<T> list)
        {
            var flattenedString = new StringBuilder();

            foreach (var value in list)
            {
                if (flattenedString.Length > 0)
                    flattenedString.Append(",");
                flattenedString.Append(value.ToString());
            }
            
            return flattenedString.ToString();
        }

        /// <summary>
        /// Dynamically casts the object into target type.
        /// Ref: http://stackoverflow.com/questions/4925718/c-dynamic-runtime-cast
        /// </summary>
        /// <param name="source">The object to be casted.</param>
        /// <param name="dest">The target type.</param>
        /// <returns>The casted object.</returns>
        public static dynamic ConvertType(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }
            
        #endregion
    }
}