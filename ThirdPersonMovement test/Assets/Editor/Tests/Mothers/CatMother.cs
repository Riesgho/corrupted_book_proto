using Domain;
using UnityEngine;
using static Domain.Cat;

namespace Editor.Tests.Mothers
{
    public static class CatMother
        {
            public static Cat ACat(Vector3? withPosition = default, int withSpeed = 0,
                CatStatus withStatus = CatStatus.Grounded, Vector3? withAirForce = default)
            {
                return new Cat(withPosition?? Vector3.zero, withSpeed, withStatus, withAirForce?? Vector3.zero);
            }
        }
}