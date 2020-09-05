using Assets.CorruptedBook.Domain;
using UnityEngine;

public class GameplayView : MonoBehaviour, IGampeplayView
{
    [SerializeField] PlayerView playerView;
     
    private Player player;
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

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
