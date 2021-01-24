using Domain;
using Domain.Actions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;
using static Domain.Cat.CatStatus;
using static Editor.Tests.Mothers.CatMother;
using static Editor.Tests.Mothers.InGameCatMother;

namespace Editor.Tests.Actions
{
    public class JumpShould
    {
        [Test]
        public void PutCatOnAirWithAirForce()
        {
            var cat = ACat(withStatus: Grounded);
            var inGameCat = AnInGameCat(withCat: cat);
            var jump = new Jump(inGameCat);
            var airForce = new Vector3(0, 2, 0);

            jump.Execute(airForce);

            var expectedCat = ACat(withStatus: Jumping, withAirForce: airForce);
            var actualCat = inGameCat.Get();
            Assert.AreEqual(expectedCat, actualCat);
        }

        [Test]
        public void DoNotPutCatOnAirWithAirForce()
        {
            var cat = ACat(withStatus: Grounded);
            var inGameCat = AnInGameCat(withCat: cat);
            var jump = new Jump(inGameCat);
            var airForce = new Vector3(0, 0, 0);

            jump.Execute(airForce);

            var expectedCat = ACat(withStatus: Grounded, withAirForce: airForce);
            var actualCat = inGameCat.Get();
            Assert.AreEqual(expectedCat, actualCat);
        }

        [Test]
        public void DoNotAddAirForceWhenAlreadyJumping()
        {
            var initAirForce = new Vector3(0, 2, 0);
            var cat = ACat(withStatus: Jumping, withAirForce: initAirForce);
            var inGameCat = AnInGameCat(withCat: cat);
            var jump = new Jump(inGameCat);
            var airForce = new Vector3(0, 4, 0);

            jump.Execute(airForce);

            var expectedCat = ACat(withStatus: Jumping, withAirForce: initAirForce);
            var actualCat = inGameCat.Get();
            Assert.AreEqual(expectedCat, actualCat);
        }
    }
}