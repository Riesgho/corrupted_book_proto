using Domain.Actions;
using Editor.Tests.Actions;
using UnityEngine;

namespace Editor.Tests.Mothers
{
    public static class ThingsMother
    {
        public static Thing AThing(int withId = 0, bool withBittenStatus = false, Vector3 withPosition = default) =>
            new Thing(withId, withBittenStatus, withPosition);
    }
}