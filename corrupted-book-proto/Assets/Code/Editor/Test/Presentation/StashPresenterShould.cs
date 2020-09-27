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
        [Test]
        public void DisplayItemsOnOpen()
        {
            var view = Substitute.For<IStashView>();
            var itemProvider = Substitute.For<IItemProvider>();
            var randomProvider = Substitute.For<IRandomProvider>();
            var itemsToDisplay = new List<Item>
            {
                new Item(0), new Item(1)
            };
            randomProvider.GetRandomValue(Arg.Any<int>(), Arg.Any<int>()).Returns(2);
            itemProvider.GenerateItems(2).Returns(itemsToDisplay);
            var presenter = new StashPresenter(view, itemProvider, randomProvider);
            presenter.Open();
            view.Received(1).DisplayItems(itemsToDisplay);
        }
    }
}