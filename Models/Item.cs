using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

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
        public ICollection<Filter>? Filters { get; set; }

        /// <summary>
        /// Image url.
        /// </summary>
        public string? Imageurl { get; set; } // Waarom geeft 'ie aan dat de picture required is?

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
        /// <summary>
        /// Set the item as favourite?
        /// </summary>
        public bool Favourite { get; set; } = false;

        public Item()
        {

        }
        
        public void DownloadOverview()
        {
            // From C# 11 and .NET7 book; directory handling

            SectionTitle("Managing directories"); // No method found.
            // define a directory path for a new folder
            // starting in the user's folder
            string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "NewFolder");
            Console.WriteLine($"Working with: {newFolder}");
            // check if it exists
            Console.WriteLine($"Does it exist? {Path.Exists(newFolder)}");
            // create directory 
            Console.WriteLine("Creating it...");
            CreateDirectory(newFolder);
            Console.WriteLine($"Does it exist? {Path.Exists(newFolder)}");
            Console.Write("Confirm the directory exists, and then press ENTER: ");
            Console.ReadLine();
            // delete directory 
            Console.WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            Console.WriteLine($"Does it exist? {Path.Exists(newFolder)}");
        
            // Next: add functionality 
        
        }

        private void SectionTitle(string v)
        {
            throw new NotImplementedException();
        }
    }
}
