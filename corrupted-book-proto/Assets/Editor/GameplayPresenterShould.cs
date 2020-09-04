using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;
using NUnit.Framework;

public class GameplayPresenterShould 
{
    private const string PLAYER_NAME = "PlayerName" ;

    private IGampeplayView view;
    private GameplayPresenter presenter;
    private PlayerConfig player;
    [SetUp]
    public void SetUp()
    {
        view = Substitute.For<IGampeplayView>();
        player = new PlayerConfig();
        presenter = new GameplayPresenter(view,player);
        presenter.CreateNewPlayer(PLAYER_NAME);
    }

    [Test]
    public void ShowPlayerAtWaypoint()
    {
        ThenThePlayerIsShownAtPosition();
    }


    private void ThenThePlayerIsShownAtPosition()
    {
        view.Received(1).ShowPlayerAtPosition(Arg.Any<float>(), Arg.Any<float>(), Arg.Any<float>());
    }
}
