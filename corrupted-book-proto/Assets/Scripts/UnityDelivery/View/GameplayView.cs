using Assets.CorruptedBook.Domain;
using UnityEngine;

public class GameplayView : MonoBehaviour, IGampeplayView
{
    [SerializeField] PlayerView playerView;
    private GameplayPresenter presenter;

    public void ShowPlayerAtPosition(float x, float y, float z)
    {
        playerView.transform.position = new Vector3(x, y, z);
    }

    public void OnStart(Player player)
    {
        presenter = new GameplayPresenter(this, player);
        presenter.SetPlayerOnStartPositon();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var clickedGameObject = hit.transform.gameObject.GetComponent<IItemView>();
                if (clickedGameObject != null)
                    playerView.PickUpItem(clickedGameObject);
            }
        }
    }
}
