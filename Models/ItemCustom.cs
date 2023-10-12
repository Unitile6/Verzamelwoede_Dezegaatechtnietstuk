using System.ComponentModel.DataAnnotations.Schema;

namespace Verzamelwoede_NonBroken.Models
{
    public partial class Item
    {
        /// <summary>
        /// The current value of the item.
        /// </summary>
        [NotMapped]
        public float? CurrentValue { get { return this.EmotionalValue - this.PracticalValue; } }
        /// <summary>
        /// Emotional value of the item.
        /// </summary>
        [NotMapped]
        public float? EmotionalValue { get { return Value; } }
        /// <summary>
        /// Practical value of the item.
        /// </summary>
        [NotMapped]
        public float? PracticalValue { get { return UsesPerYear + Price; } }
        /// <summary>
        /// TotalScore is calculated from all current values.
        /// </summary>
        [NotMapped]
        public float? TotalScore { get; set; }
    }
    // Volgens Luuk is dit de correcte manier van het invoegen van berekende waarden e.d. 27-09-2023 
    // Omdat de partial gemaakt is heeft het betrekking op dezelfde class maar zal deze code niet verloren gaan wanneer Item.cs opnieuw wordt gegenereerd. 
    // De NotMapped zorgt ervoor dat de property niet wordt meegenomen naar de database.
}
