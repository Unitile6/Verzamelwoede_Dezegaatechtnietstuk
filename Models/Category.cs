using System.ComponentModel.DataAnnotations;

namespace Verzamelwoede_NonBroken.Models
{
    public class Category
    {
        /// <summary>
        /// Unique Identifier for the database.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Category
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Category
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Items associated with the Category.
        /// </summary>
        public ICollection<Item>? Items { get; set;}

        public Category() 
        { 
        
        }
    }
}
