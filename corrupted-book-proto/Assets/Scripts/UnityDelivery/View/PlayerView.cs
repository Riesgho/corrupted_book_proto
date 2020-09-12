using Assets.CorruptedBook.Domain;
using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private RaycastHit hit;
    private PlayerPresenter presenter;
    private Player player;
    private IItemView targetedItem;
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
            if (IsPointAccesable(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
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

    public void PickUpItem(IItemView clickedGameObject)
    {
        targetedItem = clickedGameObject;
        presenter.PickUpItem(targetedItem.GetItem());
    }

    private void MovePlayer()
    {
         presenter.MovePlayer( navMeshAgent.path.status == NavMeshPathStatus.PathComplete);
    }

    private bool IsPointAccesable(Ray ray, out RaycastHit hit)
    {
       return Physics.Raycast(ray, out hit);
    }

    public void ShowPickUpAction()
    {
        throw new NotImplementedException();
    }

    public bool IsTargetedItemAtDistance()
    {
        return Vector3.Distance(targetedItem.GetPosition(), transform.position) <= player.InteractionDistance;
    }
}
