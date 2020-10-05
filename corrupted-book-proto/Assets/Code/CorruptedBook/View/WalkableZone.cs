using UnityEngine;
using UnityEngine.EventSystems;

namespace CorruptedBook.View
{
    public class WalkableZone : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] Camera camera;
        private RaycastHit hit;

        private void OnMouseUp()
        {
            if (!IsPointAccesable(camera.ScreenPointToRay(Input.mousePosition), out hit)) return;
            if(!EventSystem.current.IsPointerOverGameObject ())//TODO: Todos los "onmouse bla" deberian hacer esto
                playerView.MovePlayer(hit.point);

        }

        private bool IsPointAccesable(Ray ray, out RaycastHit hitPoint)
        {
            return Physics.Raycast(ray, out hitPoint);
        }
    }
}