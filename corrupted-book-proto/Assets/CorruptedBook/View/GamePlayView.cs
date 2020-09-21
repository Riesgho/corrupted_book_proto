using CorruptedBook.Presentation;
using CorruptedBook.View;
using UnityEngine;

namespace CorruptedBook.UnityDelivery.View
{
    public class GamePlayView : MonoBehaviour, IGamePlayView
    {
        [SerializeField] PlayerView playerView;
        private GameplayPresenter presenter;

        public void ShowPlayerAtPosition(float x, float y, float z)
        {
            playerView.transform.position = new Vector3(x, y, z);
        }

        public void OnStart()
        {
            presenter = new GameplayPresenter(this);
            presenter.SetPlayerOnStartPosition();
        }
    }
}