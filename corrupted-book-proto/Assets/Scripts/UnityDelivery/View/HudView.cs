using UnityEngine;
using System.Collections;
using TMPro;
using Assets.CorruptedBook.Domain;

public class HudView : MonoBehaviour, IHudView
{
    [SerializeField] TextMeshProUGUI playerCurrentHealthLabel;
    
    private Player player;
    private HudPresenter presenter;

    public void ShowCurrentPlayersHealth(int value)
    {
        playerCurrentHealthLabel.text = value.ToString();
    }

    // Use this for initialization
    void Start()
    {
        presenter = new HudPresenter(this, player);
        presenter.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
