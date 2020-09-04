public class PlayerPresenter
{
    private IPlayerView view;
    private PlayerConfig player;
    public PlayerPresenter(IPlayerView view, PlayerConfig player)
    {
        this.view = view;
        this.player = player;
    }

    public void MovePlayer(bool canMove)
    {
        if(!canMove)
         view.StopPlayer();
    }
}
