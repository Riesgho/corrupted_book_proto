using CorruptedBook.Core;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedBook.View
{
    public class DoorView : MonoBehaviour, IInteractable
    {
        private PlayerView playerView;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshObstacle navMeshObstacle;
        private static readonly int Open = Animator.StringToHash("Open");
        private bool open = false;

        public void OnStart(PlayerView playerView)
        {
            this.playerView = playerView;
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
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
