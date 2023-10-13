using System.ComponentModel.DataAnnotations;

namespace Verzamelwoede_NonBroken.Models
{
    public partial class Item
    {
        /// <summary>
        /// Unique Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the object.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description for the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Category associated with the Item
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Category's Id.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Filters for the Item.
        /// </summary>
        public ICollection<Filter> Filters { get; set; }

        /// <summary>
        /// Image url.
        /// </summary>
        public string? Imageurl { get; set; }

        /// <summary>
        /// Price associated with the item.
        /// </summary>
        public float? Price { get; set; }

        /// <summary>
        /// How many times does the user use it per year?
        /// </summary>
        public int? UsesPerYear { get; set; }

        /// <summary>
        /// Perceived value associated with the item.
        /// </summary>
        public float? Value { get; set; }

        public Item()
        {

        }

    }
}
