using System;
using CorruptedBook.View;
using UnityEngine;

namespace CorruptedBook.UnityDelivery.View
{
    public class WalkableZone : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] Camera camera;
        private RaycastHit hit;

        private void OnMouseUp()
        {
            if (IsPointAccesable(camera.ScreenPointToRay(Input.mousePosition), out hit))
                playerView.MovePlayer(hit.point);
        }

        private bool IsPointAccesable(Ray ray, out RaycastHit hitPoint)
        {
            return Physics.Raycast(ray, out hitPoint);
        }
    }
}