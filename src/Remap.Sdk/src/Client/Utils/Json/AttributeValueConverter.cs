using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an json converter to <see cref="AttributeValue" />.
    /// </summary>
    public class AttributeValueConverter : JsonConverter<AttributeValue>
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
        public override AttributeValue ReadJson(JsonReader reader, Type objectType, AttributeValue existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return ReadAttributeValueObject(reader, serializer);

                case JsonToken.Null:
                    return null;
            }

            throw new JsonSerializationException($"Unexpected token when reading {nameof(AttributeValue)}.");
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, AttributeValue value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        #region Utilities

        private AttributeValue ReadAttributeValueObject(JsonReader reader, JsonSerializer serializer)
        {
            _canRead = false;
            var attributeValue = serializer.Deserialize<AttributeValue>(reader);
            _canRead = true;

            JToken jToken = null;
            if (attributeValue.Value is JObject)
                jToken = attributeValue.Value as JToken;
            else
                jToken = new JValue(attributeValue.Value);

            switch (attributeValue.Type)
            {
                case AttributeType.Long:
                    attributeValue.Value = jToken.ToObject<long>(serializer);
                    break;

                case AttributeType.Time:
                    attributeValue.Value = jToken.ToObject<DateTime>(serializer);
                    break;

                case AttributeType.Double:
                    attributeValue.Value = jToken.ToObject<double>(serializer);
                    break;

                case AttributeType.Boolean:
                    attributeValue.Value = jToken.ToObject<bool>(serializer);
                    break;

                case AttributeType.CustomEntity:
                    attributeValue.Value = jToken.ToObject<CustomEntity>(serializer);
                    break;

                case AttributeType.Counterparty:
                    attributeValue.Value = jToken.ToObject<Counterparty>(serializer);
                    break;

                case AttributeType.Organization:
                    attributeValue.Value = jToken.ToObject<Organization>(serializer);
                    break;

                case AttributeType.Employee:
                    attributeValue.Value = jToken.ToObject<Employee>(serializer);
                    break;

                case AttributeType.Product:
                    attributeValue.Value = jToken.ToObject<Product>(serializer);
                    break;

                case AttributeType.Bundle:
                    attributeValue.Value = jToken.ToObject<Bundle>(serializer);
                    break;

                case AttributeType.Service:
                    attributeValue.Value = jToken.ToObject<Service>(serializer);
                    break;

                case AttributeType.Contract:
                    attributeValue.Value = jToken.ToObject<Contract>(serializer);
                    break;

                case AttributeType.Project:
                    attributeValue.Value = jToken.ToObject<Project>(serializer);
                    break;

                case AttributeType.Store:
                    attributeValue.Value = jToken.ToObject<Store>(serializer);
                    break;

                default:
                    // AttributeType.String
                    // AttributeType.Text
                    // AttributeType.Link
                    // AttributeType.File
                    attributeValue.Value = jToken.ToObject<string>(serializer);
                    break;
            }

            return attributeValue;
        }

        #endregion Utilities
    }
}