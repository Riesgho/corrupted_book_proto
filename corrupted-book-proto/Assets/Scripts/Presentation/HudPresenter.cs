using Assets.CorruptedBook.Domain;
using System;

public class HudPresenter
{
    private IHudView view;
    private Player player;

    public HudPresenter(IHudView view, Player player)
    {
        this.view = view;
        this.player = player;
    }

    public void Init()
    {
        UpdatePlayersHealth();
    }

    public void UpdatePlayersHealth()
    {
        view.ShowCurrentPlayersHealth(player.CurrentHealth);
    }
}