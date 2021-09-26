using System;
using System.Collections.Generic;
using System.Linq;
using Catalogs.Entities;

namespace Catalogs.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "mx-7", Price = 3700, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Clio", Price = 1700, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Lancer X-11", Price = 4300, CreatedDate = System.DateTimeOffset.UtcNow },
        };
        
        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}