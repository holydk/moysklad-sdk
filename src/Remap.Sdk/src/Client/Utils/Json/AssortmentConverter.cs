using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an json converter to <see cref="Assortment" />.
    /// </summary>
    public class AssortmentConverter : JsonConverter<Assortment>
    {
        #region Fields

        private bool _canRead = true;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can read JSON.
        /// </summary>
        /// <value><c>true</c> if this <see cref="JsonConverter"/> can read JSON; otherwise, <c>false</c>.</value>
        public override bool CanRead => _canRead;

        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can write JSON.
        /// </summary>
        /// <value><c>true</c> if this <see cref="JsonConverter"/> can write JSON; otherwise, <c>false</c>.</value>
        public override bool CanWrite => false;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override Assortment ReadJson(JsonReader reader, Type objectType, Assortment existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return ReadAssortmentObject(reader, serializer);

                case JsonToken.Null:
                    return null;
            }

            throw new JsonSerializationException($"Unexpected token when reading {nameof(Assortment)}.");
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, Assortment value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        #region Utilities

        private Assortment ReadAssortmentObject(JsonReader reader, JsonSerializer serializer)
        {
            Assortment assortment = null;

            var jObject = JObject.Load(reader);
            if (jObject.HasValues)
            {
                _canRead = false;
                assortment = jObject.ToObject<Assortment>(serializer);
                _canRead = true;

                if (assortment != null)
                    assortment.Product = jObject.ToObject<AbstractProduct>(serializer);
            }

            return assortment;
        }

        #endregion Utilities
    }
}