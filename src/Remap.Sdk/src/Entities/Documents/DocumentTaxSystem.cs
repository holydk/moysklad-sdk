using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an tax system.
    /// </summary>
    public enum DocumentTaxSystem
    {
        /// <summary>
        /// General tax system.
        /// </summary>
        [EnumMember(Value = "GENERAL_TAX_SYSTEM")]
        GeneralTaxSystem,

        /// <summary>
        /// Simplified tax system income.
        /// </summary>
        [EnumMember(Value = "SIMPLIFIED_TAX_SYSTEM_INCOME")]
        SimplifiedTaxSystemIncome,

        /// <summary>
        /// Simplified tax system income outcome.
        /// </summary>
        [EnumMember(Value = "SIMPLIFIED_TAX_SYSTEM_INCOME_OUTCOME")]
        SimplifiedTaxSystemIncomeOutcome,

        /// <summary>
        /// Unified agricultural tax.
        /// </summary>
        [EnumMember(Value = "UNIFIED_AGRICULTURAL_TAX")]
        UnifiedAgriculturalTax,

        /// <summary>
        /// Presumptive tax system.
        /// </summary>
        [EnumMember(Value = "PRESUMPTIVE_TAX_SYSTEM")]
        PresumptiveTaxSystem,

        /// <summary>
        /// Patent based.
        /// </summary>
        [EnumMember(Value = "PATENT_BASED")]
        PatentBased
    }
}