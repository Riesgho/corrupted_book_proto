using Assets.CorruptedBook.Domain;

public interface IPlayerView
{
    void StopPlayer();
    void ShowPickUpAction();
    bool IsTargetedItemAtDistance();
}