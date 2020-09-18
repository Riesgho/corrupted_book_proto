using NSubstitute;
using NUnit.Framework;
using System;
using CorruptedBook.Core;
using CorruptedBook.Presentation;

namespace Assets.Editor.Presentation
{
    public class PlayerPresenterShould
    {
        private IPlayerView view;
        private Essence consumable;
        private Player player;
        PlayerPresenter presenter;
        [SetUp]
        public void Setup()
        {
            consumable = new Essence();
            view = Substitute.For<IPlayerView>();
            player = new Player("Jack", 100, 100, 0, PlayerStatus.Normal,1);
            presenter = new PlayerPresenter(view, player);
        }

        [Test]
        public void StopWhenDestinationIsNotReacheable()
        {
            WhenPlayerCantReachDestination();
            ThenPlayerIsStopped();
        }
        

        private void ThenPlayerIsStopped()
        {
            view.Received(1).StopPlayer();
        }

        private void WhenPlayerCantReachDestination()
        {
            presenter.MovePlayer(false);
        }
    }
}