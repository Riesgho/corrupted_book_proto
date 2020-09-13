using Assets.CorruptedBook.Core;
using Assets.CorruptedBook.Core.Providers;
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

    public void OnStart(IEssenceProvider itemProvider)
    {
        presenter = new GameplayPresenter(this, itemProvider);
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
                var clickedGameObject = hit.transform.gameObject.GetComponent<IEssenceView>();
                if (clickedGameObject != null)
                    playerView.PickUpItem(clickedGameObject);
            }
        }
    }

    public void ShowEssence(Essence consumable)
    {
        throw new System.NotImplementedException();
    }
}
