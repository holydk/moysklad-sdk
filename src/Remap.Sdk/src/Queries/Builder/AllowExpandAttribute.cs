using System;

namespace Confiti.MoySklad.Remap.Queries
{
    /// <summary>
    /// Represents the attribute to allow 'expand' parameter on the entity member.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class AllowExpandAttribute : Attribute
    {
    }
}