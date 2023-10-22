using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_NonBroken.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<int, Item> itemsCache;

        private ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
            if(itemsCache is null)
            {
                itemsCache = new ConcurrentDictionary<int, Item>(_context.Item.ToDictionary(c => c.Id));
            }
        }
        public Task<Item?> RetrieveAsync(int id)
        {
            // For performance, get from cache.
            if (itemsCache is null) return null!;
            itemsCache.TryGetValue(id, out Item? c);
            return Task.FromResult(c);
        }
        private Item UpdateCache(int id, Item c)
        {
            Item? old;
            if (itemsCache is not null)
            {
                if (itemsCache.TryGetValue(id, out old))
                {
                    if (itemsCache.TryUpdate(id, c, old))
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public async Task<Item?> CreateAsync(Item item)
        {
        EntityEntry<Item> added = await _context.Item.AddAsync(item);
        int affected = await _context.SaveChangesAsync();
            if(affected == 1)
            {
                if (itemsCache is null) return item;
                return itemsCache.AddOrUpdate(item.Id, item, UpdateCache);
            }
            else
            {
                { return null; }
            }

        }
        public async Task<Item?> UpdateAsync(int id, Item c)
        {
            // Normalize customer Id.
            // Update in database.
            _context.Item.Update(c);
            int affected = await _context.SaveChangesAsync();
            if (affected == 1)
            {
                // update in cache
                return UpdateCache(id, c);
            }
            return null;
        }
        public async Task<bool?> DeleteAsync(int id)
        {
            // Remove from database.
            Item? c = _context.Item.Find(id);
            if (c is null) return null;
            _context.Item.Remove(c);
            int affected = await _context.SaveChangesAsync();
            if (affected == 1)
            {
                if (itemsCache is null) return null;
                // Remove from cache.
                return itemsCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }
    }
}

