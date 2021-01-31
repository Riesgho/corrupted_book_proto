using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Domain.Actions;
using Editor.Tests.Mothers;
using Infrastructure;
using NUnit.Framework;
using UnityEngine;
using static Editor.Tests.Mothers.BiteMother;
using static Editor.Tests.Mothers.ThingsMother;
using static Editor.Tests.Mothers.CatMother;
using static Editor.Tests.Mothers.InGameCatMother;

namespace Editor.Tests.Actions
{
    public class BiteShould
    {
        [Test]
        public void BiteWhenThingIsInRangeAndFacingThing()
        {
            var cat = ACat(withPosition: Vector3.zero, withBiteRange: 1, withFacingDirection: new Vector3(1,0,1));
            var inGameCat = AnInGameCat(cat);
            var thingId = 0;
            var thing = AThing(withId: 0, withBittenStatus: false, withPosition: new Vector3(0.5f, 0, 0.5f));
            var inGameThings = new InGameThings(new[] {thing});
            var bite = ABite(withInGameThings: inGameThings, withAnInGameCat: inGameCat);

            bite.Execute(thing);

            var actualValue = inGameThings.Get(0);
            var expectedValue = AThing(withId: 0, withBittenStatus: true, withPosition: Vector3.zero);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DoNotBiteWhenIsNotFacingThingOnZAxis()
        {
            var cat = ACat(withPosition: Vector3.zero, withBiteRange: 1, withFacingDirection: Vector3.forward);
            var inGameCat = AnInGameCat(cat);
            var thingId = 0;
            var thingPosition = new Vector3(0, 0, -0.5f);
            var thing = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            var inGameThings = new InGameThings(new[] {thing});
            var bite = ABite(withInGameThings: inGameThings, withAnInGameCat: inGameCat);

            bite.Execute(thing);

            var actualValue = inGameThings.Get(0);
            var expectedValue = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        [Test]
        public void DoNotBiteWhenIsNotFacingThingOnXAxis()
        {
            var cat = ACat(withPosition: Vector3.zero, withBiteRange: 1, withFacingDirection: Vector3.forward);
            var inGameCat = AnInGameCat(cat);
            var thingId = 0;
            var thingPosition = new Vector3(-0.5f, 0, 0.5f);
            var thing = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            var inGameThings = new InGameThings(new[] {thing});
            var bite = ABite(withInGameThings: inGameThings, withAnInGameCat: inGameCat);

            bite.Execute(thing);

            var actualValue = inGameThings.Get(0);
            var expectedValue = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        [Test]
        public void DoNotBiteWhenIsNotFacingThingOnYAxis()
        {
            var cat = ACat(withPosition: Vector3.zero, withBiteRange: 1, withFacingDirection: new Vector3(1,0,1));
            var inGameCat = AnInGameCat(cat);
            var thingId = 0;
            var thingPosition = new Vector3(0.5f, 0.5f, 0.5f);
            var thing = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            var inGameThings = new InGameThings(new[] {thing});
            var bite = ABite(withInGameThings: inGameThings, withAnInGameCat: inGameCat);

            bite.Execute(thing);

            var actualValue = inGameThings.Get(0);
            var expectedValue = AThing(withId: 0, withBittenStatus: false, withPosition: thingPosition);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}