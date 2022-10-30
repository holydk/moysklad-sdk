using Confiti.MoySklad.Remap.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Confiti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents an json converter to <see cref="Discount" />.
    /// </summary>
    public class DiscountConverter : JsonCreationConverter<Discount>
    {
        #region Methods

        /// <summary>
        /// Create an instance of object, based on properties in the JSON object.
        /// </summary>
        /// <param name="objectType">The type of object expected.</param>
        /// <param name="jObject">The contents of JSON object that will be deserialized.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        protected override Discount Create(Type objectType, JObject jObject, JsonSerializer serializer)
        {
            if (jObject.HasValues && jObject["meta"] is JObject jMeta)
            {
                var meta = jMeta.ToObject<Meta>(serializer);
                if (meta != null)
                {
                    switch (meta.Type)
                    {
                        case EntityType.Discount:
                            return new Discount();

                        case EntityType.AccumulationDiscount:
                            return new AccumulationDiscount();

                        case EntityType.PersonalDiscount:
                            return new PersonalDiscount();

                        case EntityType.SpecialPriceDiscount:
                            return new SpecialPriceDiscount();

                        case EntityType.BonusProgram:
                            return new BonusProgram();
                    }
                }
            }

            throw new InvalidOperationException($"Cannot deserialize the JSON object into the specific {nameof(Discount)} object.");
        }

        #endregion Methods
    }
}