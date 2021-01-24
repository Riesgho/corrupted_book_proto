using Boo.Lang;
using CorruptedBook.Core;
using CorruptedBook.Presentation;

namespace CorruptedBook.Application
{
    public class InventoryRepository: IInventoryRepository
    {
        private List<Item> items;

        public InventoryRepository()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}