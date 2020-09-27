using System;
using System.Collections;
using CorruptedBook.Core;
using CorruptedBook.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedBook.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
     
        [SerializeField] NavMeshAgent navMeshAgent;
        private PlayerPresenter presenter;
        private Subject<Unit> onMovePlayer;
        private IInteractable interactableTarget;
        public void OnStart(Player player)
        {
            presenter = new PlayerPresenter(this, player);
            onMovePlayer =  new Subject<Unit>();
        }
        
        public void StopPlayer()
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }

        public IObservable<Unit> MoveToInteractable(IInteractable interactableObject)
        {
            onMovePlayer =  new Subject<Unit>();
            return onMovePlayer
                .DoOnSubscribe(()=> MovePlayer(interactableObject.GetPosition()))
                .DoOnCompleted(StopPlayer)
                .AsUnitObservable();
        }

        public void MovePlayer(Vector3 position)
        {
            StartCoroutine(MovePlayerCoroutine(position));
        }

        public void TryInteractionWith(IInteractable interactableObject)
        {
            presenter.Interact(interactableObject);
        }

        private IEnumerator MovePlayerCoroutine(Vector3 position)
        {
            navMeshAgent.SetDestination(position);
            yield return new WaitUntil(()=> navMeshAgent.hasPath);
            presenter.MovePlayer(navMeshAgent.path.status != NavMeshPathStatus.PathInvalid);
            yield return new WaitUntil(HasReachedPosition);
            onMovePlayer.OnCompleted();
        }

        private bool HasReachedPosition()
        {
            return navMeshAgent.hasPath && navMeshAgent.remainingDistance < 0.1f;
        }
    }
}