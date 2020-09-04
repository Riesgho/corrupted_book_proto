using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;
using Assets.CorruptedBook.Domain;

public class HudPresenterShould
{
    private IHudView view;
    private Player player;
    private HudPresenter presenter;

    [SetUp]
    public void Setup()
    {
        view = Substitute.For<IHudView>();
        player = new Player("player", 100, 100);
        presenter = new HudPresenter(view, player);
    }

    [Test]
    public void ShowPlayersHealthAInit()
    {
        WhenPresenterInits();
        ThenCurrentPlayersHealthIsShown();
    }


    [Test]
    public void UpdatesPlayersHeatlhBar()
    {
        presenter.UpdatePlayersHealth();
        ThenCurrentPlayersHealthIsShown();
    }
    private void ThenCurrentPlayersHealthIsShown()
    {
        view.Received(1).ShowCurrentPlayersHealth(player.CurrentHealth);
    }

    private void WhenPresenterInits()
    {
        presenter.Init();
    }
}
