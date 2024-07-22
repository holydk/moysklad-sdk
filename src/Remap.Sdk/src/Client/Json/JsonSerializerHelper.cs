using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Confiti.MoySklad.Remap.Client.Json
{
    internal static class JsonSerializerHelper
    {
        private static readonly UTF8Encoding _utf8EncodingWithoutPreamble = new UTF8Encoding(false);
        private static int _bufferSize = 1024;

        public static async Task<object> ReadFromStreamAsync(Stream stream, Type type, JsonSerializerSettings settings = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!stream.CanRead)
                return null;

            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
                return await Task.Run(() => JsonSerializer.CreateDefault(settings).Deserialize(reader, type)).ConfigureAwait(false);
        }

        public static async Task<Stream> WriteToStreamAsync(object body, JsonSerializerSettings settings = null)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            var memStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memStream, _utf8EncodingWithoutPreamble, _bufferSize, leaveOpen: true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                JsonSerializer.CreateDefault(settings).Serialize(jsonTextWriter, body);
                await jsonTextWriter.FlushAsync().ConfigureAwait(false);

                memStream.Seek(0, SeekOrigin.Begin);
            }

            return memStream;
        }
    }
}