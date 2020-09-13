using System;
using Assets.CorruptedBook.Core;
using Assets.CorruptedBook.Domain;

public interface IGampeplayView
{
    void ShowPlayerAtPosition(float x, float y, float z);
    void ShowEssence(Essence consumable);
}