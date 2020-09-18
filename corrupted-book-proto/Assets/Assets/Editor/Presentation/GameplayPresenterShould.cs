using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace Assets.Editor.Presentation
{
    public class GameplayPresenterShould
    {
        private IGamePlayView view;
        private GameplayPresenter presenter;
        [SetUp]
        public void SetUp()
        {
            view = Substitute.For<IGamePlayView>();
            presenter = new GameplayPresenter(view);
            presenter.SetPlayerOnStartPosition();
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