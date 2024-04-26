using System;

namespace SortLoot
{
    /// <summary>
    /// IComparable<Loot>
    /// </summary>
    public class Loot : IComparable<Loot>
    {
        /// <summary>Tipo de loot.</summary>
        public LootType Kind { get; }

        /// <summary>Loot descrição.</summary>
        public string Description { get; }

        /// <summary>Loot value.</summary>
        public float Value { get; }

        /// <summary>
        /// </summary>
        /// <param name="kind">Type of loot.</param>
        /// <param name="description">Loot description.</param>
        /// <param name="value">Loot value.</param>
        public Loot(LootType kind, string description, float value)
        {
            Kind = kind;
            Description = description;
            Value = value;
        }
        public int CompareTo(Loot other)
        {
            // do maior para menor
            int valueComparison = other.Value.CompareTo(Value);
            if (valueComparison != 0)
            {
                return valueComparison;
            }

            // comparar alfabeticamente
            int typeComparison = Kind.ToString().CompareTo(other.Kind.ToString());
            if (typeComparison != 0)
            {
                return typeComparison;
            }
            return String.Compare(Description, other.Description, StringComparison.Ordinal);
        }

        public override string ToString() =>
            $"[{Kind,15}]\t{Value:f2}\t{Description}";
    }
}
