using Verzamelwoede_NonBroken.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Models
{
    public class ItemFilterViewModel
    {
        public int Id { get; set; }
        public virtual Filter Filter { get; set; }
        public int FilterId { get; set; }
        public virtual Item Item { get; set; }
        public int ItemId { get; set; }

        public ItemFilterViewModel() { }
    }
}
