using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Models;

namespace App1.Services
{
    public class MockDataStore : IDataStore<Zajecia>
    {
        List<Zajecia> items;

        public MockDataStore()
        {
            items = new List<Zajecia>();
            var mockItems = new List<Zajecia>
            {
                new Zajecia { Id = Guid.NewGuid().ToString(), Nazwa = "Programowanie", Godzina="8:00 - 9:35" },
                new Zajecia { Id = Guid.NewGuid().ToString(), Nazwa = "Grafika", Godzina="9:45 - 11:20" },
                new Zajecia { Id = Guid.NewGuid().ToString(), Nazwa = "Sieci", Godzina="11:30 - 13:05" },
                new Zajecia { Id = Guid.NewGuid().ToString(), Nazwa = "Algorytmy", Godzina="13:45 - 15:20" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Zajecia item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Zajecia item)
        {
            var oldItem = items.Where((Zajecia arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Zajecia arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Zajecia> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Zajecia>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}