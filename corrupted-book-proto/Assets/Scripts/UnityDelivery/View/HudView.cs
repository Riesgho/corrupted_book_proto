using UnityEngine;
using System.Collections;

public class HudView : MonoBehaviour, IHudView
{
    private HudPresenter presenter;
    public void ShowPlayersHealth()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {
        presenter = new HudPresenter(this);
        presenter.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
