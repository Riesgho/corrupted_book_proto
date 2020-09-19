using CorruptedBook.Core;
using UniRx;

namespace CorruptedBook.Presentation
{
    public class PlayerPresenter
    {
        private IPlayerView view;
        private Player player;
        public PlayerPresenter(IPlayerView view, Player player)
        {
            this.view = view;
            this.player = player;
        }

        public void MovePlayer(bool canMove)
        {
            if(!canMove)
                view.StopPlayer();
        }

        public void Interact(IInteractable interactableObject)
        {
            if(interactableObject.GetDistanceToPlayer() <= player.InteractionDistance)
                interactableObject.Execute();
            else
            {
                view.MoveToInteractable(interactableObject)
                    .DoOnCompleted(()=> Interact(interactableObject))
                    .Subscribe();
            }
        }
    }
}
