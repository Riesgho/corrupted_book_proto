
using Assets.CorruptedBook.Domain;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Assets.Editor.Presentation
{
    public class PlayerPresenterShould
    {
        private IPlayerView view;
        private IInventory consumableBag;
        private IItem consumable;
        private Player player;
        PlayerPresenter presenter;
        [SetUp]
        public void Setup()
        {
            consumable = Substitute.For<IItem>();
            view = Substitute.For<IPlayerView>();
            consumableBag  = Substitute.For<IInventory>();
            player = new Player("Jack", 100, 100, 0, PlayerStatus.Normal, consumableBag,1);
            presenter = new PlayerPresenter(view, player);
        }

        [Test]
        public void StopWhenDestinationIsNotReacheable()
        {
            WhenPlayerCantReachDestination();
            ThenPlayerIsStopped();
        }

        [Test]
        public void PickUpAndItem()
        {
            view.IsTargetedItemAtDistance().Returns(true);
            presenter.PickUpItem(consumable);
            view.Received(1).ShowPickUpAction();
        }

        [Test]
        public void RemoveTheConsumableAfterItsUse()
        {
            WhenPlayerConsumeAnItem();
            TheItemIsRemovedFromTheBag();
        }


        private void ThenPlayerIsStopped()
        {
            view.Received(1).StopPlayer();
        }

        private void WhenPlayerCantReachDestination()
        {
            presenter.MovePlayer(false);
        }


        private void ThenTheItemIsAddedToTheBag()
        {
            consumableBag.Received(1).AddItem(consumable);
        }
        private void WhenPlayerConsumeAnItem()
        {
            presenter.ConsumeItem(consumable);
        }

        private void TheItemIsRemovedFromTheBag()
        {
            consumableBag.Received(1).RemoveItem(consumable);
        }
    }
}