using System;
using Assets.CorruptedBook.Core;
using Assets.CorruptedBook.Domain;
using NSubstitute.Core;

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

    private void AddItemToInventory(Essence essence)
    {
        view.ShowPickUpAction();//TODO: This is an observable, that adds the item to the bag  when completes.    
    }

    public void PickUpItem(Essence essence)
    {
       if(view.IsTargetedItemAtDistance())
        {
            AddItemToInventory(essence);
        }
    }
}
