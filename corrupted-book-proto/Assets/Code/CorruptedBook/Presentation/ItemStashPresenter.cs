using CorruptedBook.Core;

namespace CorruptedBook.Presentation
{
    public class ItemStashPresenter
    {
        private IItemStashView _stashView;
        private IInventoryRepository inventory;
        private Item item;


        public ItemStashPresenter(IItemStashView stashView, IInventoryRepository inventory, Item item)
        {
            this._stashView = stashView;
            this.inventory = inventory;
            this.item = item;
        }

        public void SaveItem()
        {
            inventory.AddItem(item);
        }

        public void OnStart()
        {
            _stashView.UpdateItemInformation(item);
        }
    }
}