using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client.Json
{
    /// <summary>
    /// Represents an json converter to <see cref="AbstractProduct" />.
    /// </summary>
    public class AbstractProductConverter : JsonCreationConverter<AbstractProduct>
    {
        #region Methods

        /// <summary>
        /// Create an instance of object, based on properties in the JSON object.
        /// </summary>
        /// <param name="objectType">The type of object expected.</param>
        /// <param name="jObject">The contents of JSON object that will be deserialized.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        protected override AbstractProduct Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.Product:
                            return new Product();

                        case EntityType.Variant:
                            return new Variant();

                        case EntityType.Service:
                            return new Service();

                        case EntityType.Bundle:
                            return new Bundle();
                    }
                }
            }

            throw new JsonSerializationException($"Cannot deserialize the JSON object into the specific '{nameof(AbstractProduct)}'.");
        }

        #endregion Methods
    }
}