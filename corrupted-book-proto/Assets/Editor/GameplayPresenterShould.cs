using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;
using NUnit.Framework;
using Assets.CorruptedBook.Domain;
namespace Assets.Editor.Presentation
{
    public class GameplayPresenterShould
    {
        private IGampeplayView view;
        private GameplayPresenter presenter;
        private Player player;
        [SetUp]
        public void SetUp()
        {
            view = Substitute.For<IGampeplayView>();
            player = new Player("Jack", 100, 100, 0,PlayerStatus.Normal);
            presenter = new GameplayPresenter(view, player);
            presenter.SetPlayerOnStartPositon();
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
}