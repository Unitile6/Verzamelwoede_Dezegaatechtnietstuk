using Verzamelwoede_NonBroken.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Repositories
{
    public interface IItemRepository
    {
        public interface ICustomerRepository
        {
            Task<Item?> CreateAsync(Item c);
            Task<IEnumerable<Item>> RetrieveAllAsync();
            Task<Item?> RetrieveAsync(string id);
            Task<Item?> UpdateAsync(string id, Item c);
            Task<bool?> DeleteAsync(string id);
        }
    }
}
