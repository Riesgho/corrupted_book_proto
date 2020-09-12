using Assets.CorruptedBook.Domain;
using UnityEngine;

public interface IItemView
{
    Vector3 GetPosition();
    IItem GetItem();
}