
using NSubstitute;
using NUnit.Framework;
using System;
public class PlayerPresenterShould
{
    [Test]
    public void StopWhenDestinationIsNotReacheable()
    {
        IPlayerView view = Substitute.For<IPlayerView>();
        PlayerPresenter presenter = new PlayerPresenter(view);
        presenter.MovePlayer(false);
        view.Received(1).StopPlayer();
    }
}
