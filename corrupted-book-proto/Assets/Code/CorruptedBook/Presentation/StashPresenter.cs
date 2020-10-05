using System.Collections.Generic;
using System.Linq;
using CorruptedBook.Application;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;

namespace CorruptedBook.Presentation
{
    public class StashPresenter
    {
        private const int MAX_STASH_SIZE = 3;
        private const int MIN_STASH_SIZE = 1;

        private IStashView view;
        private IItemProvider itemProvider;
        private IRandomProvider randomProvider;
        private List<Item> memoryItems;
        private IInventoryRepository inventoryRepository;

        public List<Item> ItemsInStash => memoryItems;

        public StashPresenter(IStashView view, IItemProvider itemProvider, IRandomProvider randomProvider,
            IInventoryRepository inventoryRepository)
        {
            this.view = view;
            this.itemProvider = itemProvider;
            this.randomProvider = randomProvider;
            this.inventoryRepository = inventoryRepository;
        }

        public void Open()
        {
            if (memoryItems == null)
                memoryItems = itemProvider.GenerateItems(randomProvider.GetRandomValue(MIN_STASH_SIZE, MAX_STASH_SIZE));

            if (memoryItems.Count == 0) return;
            
            view.UpdateItemsInStash();
        }

        public void Close()
        {
            view.Hide();
        }

        public void SaveItem(Item item)
        {
            inventoryRepository.AddItem(item);
            memoryItems.Remove(memoryItems.First(stashItem => stashItem.Id == item.Id));
            if (memoryItems.Count == 0)
            {
                Close();
                return;
            }
            view.UpdateItemsInStash();
        }
    }
}