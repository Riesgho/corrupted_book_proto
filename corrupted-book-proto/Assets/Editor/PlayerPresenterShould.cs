
using NSubstitute;
using NUnit.Framework;
using System;
public class PlayerPresenterShould
{
    [Test]
    public void StopWhenDestinationIsNotReacheable()
    {
        IPlayerView view = Substitute.For<IPlayerView>();
        PlayerConfig player = new PlayerConfig();
        PlayerPresenter presenter = new PlayerPresenter(view, player);
        presenter.MovePlayer(false);
        view.Received(1).StopPlayer();
    }
}
