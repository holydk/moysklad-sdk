namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an address.
    /// </summary>
    public class Address
    {
        #region Properties

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        /// <value>The house.</value>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the apartment.
        /// </summary>
        /// <value>The apartment.</value>
        public string Apartment { get; set; }

        /// <summary>
        /// Gets or sets the addInfo.
        /// </summary>
        /// <value>The addInfo.</value>
        public string AddInfo { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment { get; set; }
            
        #endregion
    }
}