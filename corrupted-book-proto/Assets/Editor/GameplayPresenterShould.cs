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

    [SetUp]
    public void SetUp()
    {
        view = Substitute.For<IGampeplayView>();
        presenter = new GameplayPresenter(view);
        presenter.CreateNewPlayer(PLAYER_NAME);
    }

    [Test]
    public void CreatePlayerWithAName()
    {
        ThenThePlayerHasAName();
    }

    [Test]
    public void CreatePlayerWith100PointsMaxHealthOnStart()
    {
        ThenPlayerHasMaxHealth();
    }

    [Test]
    public void CreatePlayerWith0CorruptionOnStart()
    {
        ThenPlayerHasCorruption();
    }

    [Test]
    public void ShowPlayerAtWaypoint()
    {
        ThenThePlayerIsShownAtPosition();
    }

    private void ThenThePlayerHasAName()
    {
        Assert.AreEqual(PLAYER_NAME, presenter.Player.Name);
    }


    private void ThenPlayerHasMaxHealth()
    {
        Assert.AreEqual(100, presenter.Player.MaxHealth);
    }

    private void ThenPlayerHasCorruption()
    {
        Assert.AreEqual(0, presenter.Player.Corruption);
    }


    private void ThenThePlayerIsShownAtPosition()
    {
        view.Received(1).ShowPlayerAtPosition(Arg.Any<float>(), Arg.Any<float>(), Arg.Any<float>());
    }
}
