using NSubstitute;
using NUnit.Framework;
using Assets.CorruptedBook.Domain;
using Assets.CorruptedBook.Core.Providers;
using Assets.CorruptedBook.Core;

namespace Assets.Editor.Presentation
{
    public class GameplayPresenterShould
    {
        private IGampeplayView view;
        private GameplayPresenter presenter;
        private Player player;
        private IEssenceProvider itemProvider;
        [SetUp]
        public void SetUp()
        {
            view = Substitute.For<IGampeplayView>();
            itemProvider = Substitute.For<IEssenceProvider>();
            player = new Player("Jack", 100, 100, 0,PlayerStatus.Normal,1);
            presenter = new GameplayPresenter(view, itemProvider);
            presenter.SetPlayerOnStartPositon();
        }

        [Test]
        public void ShowPlayerAtWaypoint()
        {
            ThenThePlayerIsShownAtPosition();
        }

        [Test]
        public void ShowItems()
        {
            var consumable = new Essence();
            itemProvider.GetEssence().Returns(consumable);
            presenter.CreateConsumable();
            view.Received(1).ShowEssence(consumable);
        }

        private void ThenThePlayerIsShownAtPosition()
        {
            view.Received(1).ShowPlayerAtPosition(Arg.Any<float>(), Arg.Any<float>(), Arg.Any<float>());
        }
    }
}