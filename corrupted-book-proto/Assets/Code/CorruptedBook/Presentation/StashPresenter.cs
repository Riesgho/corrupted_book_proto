using System.Collections.Generic;
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
     
        public StashPresenter(IStashView view, IItemProvider itemProvider, IRandomProvider randomProvider)
        {
            this.view = view;
            this.itemProvider = itemProvider;
            this.randomProvider = randomProvider;
        }

        public void Open()
        {
            if(memoryItems == null)
                memoryItems = itemProvider.GenerateItems(randomProvider.GetRandomValue(MIN_STASH_SIZE,MAX_STASH_SIZE));
            
            view.DisplayItems(memoryItems);
        }

        public void Close()
        {
            view.HideItems();
        }
    }
}