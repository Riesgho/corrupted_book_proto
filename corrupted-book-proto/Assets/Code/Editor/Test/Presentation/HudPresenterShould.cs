using CorruptedBook.Core;
using CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Test.Presentation
{
    public class HudPresenterShould
    {
        private IHudView view;
        private Player player;
        private HudPresenter presenter;

        [SetUp]
        public void Setup()
        {
            view = Substitute.For<IHudView>();
            player = new Player("player", 50, 100, 0, PlayerStatus.Normal,1);
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