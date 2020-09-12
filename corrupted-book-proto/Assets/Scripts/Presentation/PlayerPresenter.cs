using System;
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

    private void AddItemToInventory(IItem consumable)
    {
        view.ShowPickUpAction();//TODO: This is an observable, that adds the item when completes.
        player.AddItemToInventory(consumable);
        
    }

    public void ConsumeItem(IItem consumable)
    {
        player.ConsumeItem(consumable);
    }


    public void PickUpItem(IItem consumable)
    {
       if(view.IsTargetedItemAtDistance())
        {
            AddItemToInventory(consumable);
        }
    }
}
