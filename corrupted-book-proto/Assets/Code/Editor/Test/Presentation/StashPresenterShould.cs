using System.Collections.Generic;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Test.Presentation
{
    public class StashPresenterShould
    {
        private IStashView view;
        private IItemProvider itemProvider;
        private IRandomProvider randomProvider;
        private StashPresenter presenter;
        private List<Item> itemsToDisplay;
        [SetUp]
        public void BeforeEachTest()
        {
            view = Substitute.For<IStashView>();
            itemProvider = Substitute.For<IItemProvider>();
            randomProvider = Substitute.For<IRandomProvider>();
            itemsToDisplay = new List<Item>
            {
                new Item(0), new Item(1)
            };
            randomProvider.GetRandomValue(Arg.Any<int>(), Arg.Any<int>()).Returns(2);
            itemProvider.GenerateItems(2).Returns(itemsToDisplay);
            presenter = new StashPresenter(view, itemProvider, randomProvider);
        }
        
        [Test]
        public void DisplayItemsOnOpen()
        {
            presenter.Open();
            view.Received(1).DisplayItems(itemsToDisplay);
        }

        [Test]
        public void HideWhenClose()
        {
            presenter.Close();
            view.Received(1).HideItems();
        }
    }
}