using NSubstitute;
using NUnit.Framework;
using System;
using CorruptedBook.Core;
using CorruptedBook.Presentation;

namespace Assets.Editor.Presentation
{
    public class PlayerPresenterShould
    {
        private IPlayerView view;
        private IInteractable interactableObject;
        private Player player;
        private PlayerPresenter presenter;
        private int distanceToObject;
        
        [SetUp]
        public void Setup()
        {
            view = Substitute.For<IPlayerView>();
            interactableObject = Substitute.For<IInteractable>();
            
            player = new Player("Jack", 100, 100, 0, PlayerStatus.Normal,1);
            presenter = new PlayerPresenter(view, player);
        }

        [Test]
        public void StopWhenDestinationIsNotReachable()
        {
            WhenPlayerCantReachDestination();
            ThenPlayerIsStopped();
        }

        [Test]
        public void InteractWithObjectsWhenIsAtDistance()
        {
            GivenPlayerIsAtDistance(1);
            interactableObject.GetDistanceToPlayer().Returns(distanceToObject);
            presenter.Interact(interactableObject);
            interactableObject.Received(1).Execute();
        }


        [Test]
        public void MoveToInteractableObject()
        {
            GivenPlayerIsAtDistance(2);
            interactableObject.GetDistanceToPlayer().Returns(distanceToObject);
            WhenPlayerInteractsWithObject();
            ThenThePlayerMovesToTheInteractableObject();
        }
        
        private void GivenPlayerIsAtDistance(int distance)
        {
            distanceToObject = distance;
        }

        private void WhenPlayerInteractsWithObject()
        {
            presenter.Interact(interactableObject);
        }

        private void WhenPlayerCantReachDestination()
        {
            presenter.MovePlayer(false);
        }

        private void ThenPlayerIsStopped()
        {
            view.Received(1).StopPlayer();
        }

        private void ThenThePlayerMovesToTheInteractableObject()
        {
            view.Received(1).MoveToInteractable(interactableObject);
        }
    }
}