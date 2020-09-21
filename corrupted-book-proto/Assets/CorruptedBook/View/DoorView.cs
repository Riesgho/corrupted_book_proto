using System;
using System.Collections;
using System.Collections.Generic;
using CorruptedBook.Core;
using CorruptedBook.UnityDelivery.View;
using CorruptedBook.View;
using UnityEngine;
using UnityEngine.AI;

public class DoorView : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerView playerView;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshObstacle navMeshObstacle;
    private static readonly int Open = Animator.StringToHash("Open");
    private bool open = false;
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
