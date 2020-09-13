
using Assets.CorruptedBook.Core.Providers;
using System;

public class GameplayPresenter
{
    private IGampeplayView view;
    private IEssenceProvider itemProvider;
    public GameplayPresenter(IGampeplayView view, IEssenceProvider itemProvider)
    {
        this.view = view;
        this.itemProvider = itemProvider;
    }

    public void SetPlayerOnStartPositon()
    {
        view.ShowPlayerAtPosition(0,0,0);
    }

    public void CreateConsumable()
    {
        var consumable = itemProvider.GetEssence();
        view.ShowEssence(consumable);
    }
}