using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Represents an json creation converter to object.
    /// </summary>
    public abstract class JsonCreationConverter<T> : JsonConverter<T>
    {
        #region Properties

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
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            T target = Create(objectType, jObject, serializer);
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override sealed void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            throw new NotSupportedException($"{nameof(JsonCreationConverter<T>)} should only be used while deserializing.");
        }

        /// <summary>
        /// Create an instance of object, based on properties in the JSON object.
        /// </summary>
        /// <param name="objectType">The type of object expected.</param>
        /// <param name="jObject">The contents of JSON object that will be deserialized.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        protected abstract T Create(Type objectType, JObject jObject, JsonSerializer serializer);

        #endregion Methods
    }
}