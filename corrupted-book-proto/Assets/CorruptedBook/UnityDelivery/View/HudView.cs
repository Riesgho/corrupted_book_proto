using UnityEngine;
using System.Collections;
using TMPro;
using Assets.CorruptedBook.Domain;
using System;

public class HudView : MonoBehaviour, IHudView
{
    [SerializeField] TextMeshProUGUI playerCurrentHealthLabel;
    [SerializeField] TextMeshProUGUI playerMaxHealthLabel;

    private Player player;
    private HudPresenter presenter;

    public void ShowPlayersHealth(int current, int max)
    {
        playerCurrentHealthLabel.text = current.ToString();
        playerMaxHealthLabel.text = max.ToString();
    }

    public void OnStart(Player player)
    {
        presenter = new HudPresenter(this, player);
        presenter.Init();
    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
