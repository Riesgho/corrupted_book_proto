using Assets.CorruptedBook.Domain;

public class PlayerPresenter
{
    private IPlayerView view;
    private Player player;
    public PlayerPresenter(IPlayerView view, Player player)
    {
        this.view = view;
        this.player = player;
    }

    public void MovePlayer(bool canMove)
    {
        if(!canMove)
         view.StopPlayer();
    }

    public void AddItemToInventory(IItem consumable)
    {
        player.AddItemToInventory(consumable);
    }

    public void ConsumeItem(IItem consumable)
    {
        player.ConsumeItem(consumable);
    }
}
