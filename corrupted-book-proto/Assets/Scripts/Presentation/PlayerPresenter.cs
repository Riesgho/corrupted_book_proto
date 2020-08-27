public class PlayerPresenter
{
    private IPlayerView view;

    public PlayerPresenter(IPlayerView view)
    {
        this.view = view;
    }

    public void MovePlayer(bool canMove)
    {
        if(!canMove)
         view.StopPlayer();
    }
}
