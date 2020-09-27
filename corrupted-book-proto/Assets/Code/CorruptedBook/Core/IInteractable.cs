﻿using UnityEngine;

 namespace CorruptedBook.Core
{
    public interface IInteractable
    {
        float GetDistanceToPlayer();
        void Execute();
        Vector3 GetPosition();
    }
}