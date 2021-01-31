using Domain;
using Editor.Tests.Actions;
using UnityEngine;
using static Domain.Cat;

namespace Editor.Tests.Mothers
{
    public static class CatMother
        {
            public static Cat ACat(Vector3? withPosition = default, int withBiteRange = 0, int withSpeed = 0,
                CatStatus withStatus = CatStatus.Grounded, Vector3? withAirForce = default, Vector3? withFacingDirection = default) =>
                new Cat(withPosition?? Vector3.zero, withSpeed, withStatus, withAirForce?? Vector3.zero, withBiteRange, withFacingDirection?? Vector3.forward);
        }
}