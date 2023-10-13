using Microsoft.Build.Framework;

namespace Verzamelwoede_NonBroken.Models
{
    public class Filter
    {
        /// <summary>
        /// Unique Identifier for database functionality.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the object.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Items in the filter.
        /// </summary>
        public ICollection<Item>? Items { get; set; } // This needs not be, can be accessed from item? However, for n:n relations I'll keep it.

        public Filter(string name)
        {
            Name = name;
        }

        public Filter()
        {

        }

    }
}
