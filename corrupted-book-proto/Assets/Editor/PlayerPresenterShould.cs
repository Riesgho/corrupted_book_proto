
using Assets.CorruptedBook.Domain;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Assets.Editor.Presentation
{
    public class PlayerPresenterShould
    {
        [Test]
        public void StopWhenDestinationIsNotReacheable()
        {
            IPlayerView view = Substitute.For<IPlayerView>();
            Player player = new Player("Jack", 100, 100, 0, PlayerStatus.Normal);
            PlayerPresenter presenter = new PlayerPresenter(view, player);
            presenter.MovePlayer(false);
            view.Received(1).StopPlayer();
        }
    }
}