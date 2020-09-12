using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;
using Assets.CorruptedBook.Domain;
namespace Assets.Editor.Presentation
{
    public class HudPresenterShould
    {
        private IHudView view;
        private IInventory consumableBag;
        private Player player;
        private HudPresenter presenter;

        [SetUp]
        public void Setup()
        {
            view = Substitute.For<IHudView>();
            consumableBag = Substitute.For<IInventory>();
            player = new Player("player", 50, 100, 0, PlayerStatus.Normal, consumableBag,1);
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
            view.Received(1).ShowPlayersHealth(player.CurrentHealth, player.MaxHealth);
        }

        private void WhenPresenterInits()
        {
            presenter.Init();
        }
    }
}