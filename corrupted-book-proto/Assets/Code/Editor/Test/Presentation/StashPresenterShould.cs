using System.Collections.Generic;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;
using TMPro;

namespace Test.Presentation
{
    public class StashPresenterShould
    {
        private IStashView view;
        private IItemProvider itemProvider;
        private IRandomProvider randomProvider;
        private StashPresenter presenter;
        private List<Item> itemsToDisplay;
        private IItemStashView itemStashview;
        private IInventoryRepository inventory;
        private Item item;

        [SetUp]
        public void BeforeEachTest()
        {
            itemStashview = Substitute.For<IItemStashView>();
            item = new Item(0);
            inventory = Substitute.For<IInventoryRepository>();
            view = Substitute.For<IStashView>();
            itemProvider = Substitute.For<IItemProvider>();
            randomProvider = Substitute.For<IRandomProvider>();
            itemsToDisplay = new List<Item>
            {
                new Item(0), new Item(1)
            };
            randomProvider.GetRandomValue(Arg.Any<int>(), Arg.Any<int>()).Returns(2);
            itemProvider.GenerateItems(2).Returns(itemsToDisplay);
            presenter = new StashPresenter(view, itemProvider, randomProvider, inventory);
            presenter.Open();
        }

        [Test]
        public void DisplayItemsOnOpen()
        {
            ThenTheItemsInTheStashAreUpdated(1);
        }
        
        [Test]
        public void HideWhenClose()
        {
            presenter.Close();
            view.Received(1).Hide();
        }

        [Test]
        public void DisplayPreviousGeneratedItemsWhenOpenForSecondTime()
        {
            presenter.Open();
            itemProvider.Received(1).GenerateItems(Arg.Any<int>());
            ThenTheItemsInTheStashAreUpdated(2);
        }

        [Test]
        public void SendItemToPlayersInventoryWhenSelected()
        {
            GivenAnItemIsSaved(item);
            inventory.Received(1).AddItem(item);
        }


        [Test]
        public void EraseItemFromStashWhenItemClicked()
        {
            var itemsAmount = presenter.ItemsInStash.Count;
            GivenAnItemIsSaved(item);
            ThenTheItemsInTheStashAreUpdated(2);
            Assert.AreEqual(itemsAmount - 1, presenter.ItemsInStash.Count);
        }

        [Test]
        public void CloseStashWhenNoMoreItems()
        {
            var listWithOneItem =  itemsToDisplay = new List<Item>
            {
               item
            };
            randomProvider.GetRandomValue(Arg.Any<int>(), Arg.Any<int>()).Returns(1);
            itemProvider.GenerateItems(1).Returns(listWithOneItem);
            GivenAnItemIsSaved(item);
            presenter.Close();
        }

        [Test]
        public void NotBeOpenedIfHasZeroItems()
        {
            GivenAnItemIsSaved(itemsToDisplay[0]);
            GivenAnItemIsSaved(itemsToDisplay[0]);
            presenter.Open();
            ThenTheItemsInTheStashAreUpdated(2);
        }

        private void GivenAnItemIsSaved(Item itemToSave)
        {
            presenter.SaveItem(itemToSave);
        }

        private void ThenTheItemsInTheStashAreUpdated(int times)
        {
            view.Received(times).UpdateItemsInStash();
        }
    }
}