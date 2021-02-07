using System;
using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an json converter to <see cref="PaymentDocument" />.
    /// </summary>
    public class PaymentDocumentConverter : JsonCreationConverter<PaymentDocument>
    {
        #region Methods

        /// <summary>
        /// Create an instance of object, based on properties in the JSON object.
        /// </summary>
        /// <param name="objectType">The type of object expected.</param>
        /// <param name="jObject">The contents of JSON object that will be deserialized.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        protected override PaymentDocument Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.CashIn:
                            return new CashIn();
                        case EntityType.CashOut:
                            return new CashOut();
                        case EntityType.PaymentIn:
                            return new PaymentIn();
                        case EntityType.PaymentOut:
                            return new PaymentOut();
                    }
                }
            }

            throw new InvalidOperationException($"Cannot deserialize the JSON object into the specific {nameof(PaymentDocument)} object.");
        }
            
        #endregion
    }
}