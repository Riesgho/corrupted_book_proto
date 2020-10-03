using CorruptedBook.Core;
using CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Test.Presentation
{
    public class ItemStashPresenterShould
    {
        private IItemStashView view;
        private IInventoryRepository inventory;
        private ItemStashPresenter presenter;
        private Item item;

        [SetUp]
        public void BeforeEachTest()
        {
            view = Substitute.For<IItemStashView>();
            item = new Item(0);
            inventory = Substitute.For<IInventoryRepository>();
            presenter = new ItemStashPresenter(view, inventory, item);
        }

        [Test]
        public void SendItemToPlayersInventoryWhenSelected()
        {
            presenter.SaveItem();
            inventory.Received(1).AddItem(item);
        }

        [Test]
        public void ShowItemInformation()
        {
            presenter.OnStart();
            view.Received(1).UpdateItemInformation(item);
        }
 //TODO: Mover todo al StashPresenter.
        [Test]
        public void EraseItemFromStash()
        {
            
        }
    }
}