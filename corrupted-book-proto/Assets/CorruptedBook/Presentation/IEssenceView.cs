using Assets.CorruptedBook.Core;
using Assets.CorruptedBook.Domain;
using UnityEngine;

public interface IEssenceView
{
    Vector3 GetPosition();
    Essence GetItem();
    void ShowEssence();
}