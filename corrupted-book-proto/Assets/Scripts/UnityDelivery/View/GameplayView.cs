using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour, IGampeplayView
{
    [SerializeField] GameObject player;

    private GameplayPresenter presenter;

    public void ShowPlayerAtPosition(float x, float y, float z)
    {
        player.transform.position = new Vector3(x, y, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        presenter = new GameplayPresenter(this);
        presenter.CreateNewPlayer("Insert Name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
