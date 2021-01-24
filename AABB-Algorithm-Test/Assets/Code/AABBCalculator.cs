using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Code
{
    public class AabbCalculator: CollisionDetector
    {
        public bool HasCollisionOnY(Bounds actor, Bounds target, float tolerance)
        {
             var diff = actor.min.y - target.max.y;
            return diff <= tolerance;
        }

        public float GetLastDifference(Bounds actor, Bounds target)
        {
            return Math.Abs(actor.min.y - target.max.y);
        }
        
    }

    public interface CollisionDetector
    {
        bool HasCollisionOnY(Bounds actor, Bounds target, float tolerance);

        float GetLastDifference(Bounds actor, Bounds target);
    }
}