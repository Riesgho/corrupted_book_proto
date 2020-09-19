using System;
using CorruptedBook.Core;
using CorruptedBook.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedBook.UnityDelivery.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
     
        [SerializeField] NavMeshAgent navMeshAgent;
        
        
        private PlayerPresenter presenter;
        private Subject<Unit> onMovePlayer;
        
        public void OnStart(Player player)
        {
            presenter = new PlayerPresenter(this, player);
            onMovePlayer =  new Subject<Unit>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (navMeshAgent.hasPath && navMeshAgent.remainingDistance < 0.1f)//TODO : Pasar a corutina
            {
               onMovePlayer.OnCompleted();
            }
        }

        public void StopPlayer()
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }

        public IObservable<Unit> MoveToInteractable(IInteractable interactableObject)
        {
            onMovePlayer =  new Subject<Unit>();
            return onMovePlayer.DoOnSubscribe(() => navMeshAgent.SetDestination(interactableObject.GetPosition()))
                .DoOnCompleted(StopPlayer)
                .AsUnitObservable();
        }

        public void MovePlayer(Vector3 position)
        {
            navMeshAgent.SetDestination(position);//TODO: Obserable waiting to path to be completed
            presenter.MovePlayer(navMeshAgent.path.status == NavMeshPathStatus.PathComplete);
        }

        public void TryInteractionWith(IInteractable interactableObject)
        {
            presenter.Interact(interactableObject);
        }
    }
}