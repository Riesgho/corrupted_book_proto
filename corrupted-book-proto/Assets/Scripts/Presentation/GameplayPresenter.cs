using System;

public class GameplayPresenter
{
    private const int MAX_HEALTH = 100;
    private IGampeplayView view;
    private PlayerConfig player;
    public GameplayPresenter(IGampeplayView view, PlayerConfig player)
    {
        this.view = view;
        this.player = player;
    }

    public void CreateNewPlayer(string name)
    {
        view.ShowPlayerAtPosition(0,0,0);
    }
}