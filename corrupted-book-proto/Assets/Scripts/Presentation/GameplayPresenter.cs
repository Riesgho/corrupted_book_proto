using System;

public class GameplayPresenter
{
    private const int MAX_HEALTH = 100;
    private IGampeplayView view;
    public Player Player { get; private set; }
    public GameplayPresenter(IGampeplayView view)
    {
        this.view = view;
    }

    public void CreateNewPlayer(string name)
    {
        Player =  new Player(name, MAX_HEALTH, 0);
        view.ShowPlayerAtPosition(0,0,0);
    }
}