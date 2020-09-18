using System;
using CorruptedBook.Core;
using CorruptedBook.Presentation;
using UnityEngine;
using UnityEngine.AI;

namespace CorruptedBook.UnityDelivery.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private RaycastHit hit;
        private PlayerPresenter presenter;
        private Player player;
        [SerializeField] Camera camera;
        [SerializeField] NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Start()
        {
            presenter = new PlayerPresenter(this, player) ;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (IsPointAccesable(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    navMeshAgent.SetDestination(hit.point);
                }
            }
            MovePlayer();
        }

        public void StopPlayer()
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
        
        private void MovePlayer()
        {
            presenter.MovePlayer( navMeshAgent.path.status == NavMeshPathStatus.PathComplete);
        }

        private bool IsPointAccesable(Ray ray, out RaycastHit hit)
        {
            return Physics.Raycast(ray, out hit);
        }

    }
}
