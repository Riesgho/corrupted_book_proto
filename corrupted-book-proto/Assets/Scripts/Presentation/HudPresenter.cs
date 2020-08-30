using System;

public class HudPresenter
{
    private IHudView view;

    public HudPresenter(IHudView view)
    {
        this.view = view;
    }

    public void Init()
    {
        view.ShowPlayersHealth();
    }
}