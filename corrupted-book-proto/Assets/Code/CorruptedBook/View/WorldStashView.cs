using System;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedBook.View
{
    public class WorldStashView : MonoBehaviour, IInteractable
    {
        private PlayerView playerView;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshObstacle navMeshObstacle;
        [SerializeField] private StashView stashView;
        private static readonly int Open = Animator.StringToHash("Open");
        private bool open = false;

        public void OnStart(PlayerView playerView, IItemProvider itemProvider, IRandomProvider randomProvider)
        {
            this.playerView = playerView;
            stashView.OnStart(itemProvider, randomProvider);
        }

        private void OnMouseUp()
        {
            playerView.TryInteractionWith(this);
        }

        public float GetDistanceToPlayer()
        {
            return Vector3.Distance(playerView.transform.position, GetPosition());
        }

        public void Execute()
        {
            open = !open;
            animator.SetBool(Open, open);
            stashView.Open();
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}