using Assets.CorruptedBook.Domain;
using System;

public class GameplayPresenter
{
    private const int MAX_HEALTH = 100;
    private IGampeplayView view;
    private Player player;
    public GameplayPresenter(IGampeplayView view, Player player)
    {
        this.view = view;
        this.player = player;
    }

    public void SetPlayerOnStartPositon()
    {
        view.ShowPlayerAtPosition(0,0,0);
    }
}