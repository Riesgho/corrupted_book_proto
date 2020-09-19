using System;
using CorruptedBook.Core;
using UniRx;

namespace CorruptedBook.Presentation
{
    public interface IPlayerView
    {
        void StopPlayer();
        IObservable<Unit> MoveToInteractable(IInteractable interactableObject);
    }
}