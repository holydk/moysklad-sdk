namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an report profit.
    /// </summary>
    public abstract class ReportProfit
    {
        #region Properties

        /// <summary>
        /// Gets or sets the margin of the items.
        /// </summary>
        /// <value>The return margin of the items.</value>
        public double? Margin { get; set; }

        /// <summary>
        /// Gets or sets the profit of the items.
        /// </summary>
        /// <value>The return profit of the items.</value>
        public double? Profit { get; set; }

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        /// <value>The return price of the item.</value>
        public double? ReturnCost { get; set; }

        /// <summary>
        /// Gets or sets the return cost sum of the items.
        /// </summary>
        /// <value>The return cost sum of the items.</value>
        public double? ReturnCostSum { get; set; }

        /// <summary>
        /// Gets or sets the return price of the item.
        /// </summary>
        /// <value>The return price of the item.</value>
        public double? ReturnPrice { get; set; }

        /// <summary>
        /// Gets or sets the returned count of the items.
        /// </summary>
        /// <value>The returned count of the items.</value>
        public double? ReturnQuantity { get; set; }

        /// <summary>
        /// Gets or sets the return sum of the items.
        /// </summary>
        /// <value>The return sum of the items.</value>
        public double? ReturnSum { get; set; }

        /// <summary>
        /// Gets or sets the sell price of the item.
        /// </summary>
        /// <value>The sell price of the item.</value>
        public double? SellCost { get; set; }

        /// <summary>
        /// Gets or sets the sell cost sum of the items.
        /// </summary>
        /// <value>The sell cost sum of the items.</value>
        public double? SellCostSum { get; set; }

        /// <summary>
        /// Gets or sets the price of the sold item.
        /// </summary>
        /// <value>The price of the sold item.</value>
        public double? SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the count of the sold items.
        /// </summary>
        /// <value>The count of the sold items.</value>
        public double? SellQuantity { get; set; }

        /// <summary>
        /// Gets or sets the sell sum of the items.
        /// </summary>
        /// <value>The sell sum of the items.</value>
        public double? SellSum { get; set; }

        #endregion Properties
    }
}