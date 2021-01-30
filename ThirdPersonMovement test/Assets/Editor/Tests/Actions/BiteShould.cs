using System.Linq;
using Infrastructure;
using NUnit.Framework;
using static Editor.Tests.Mothers.CatMother;
using static Editor.Tests.Mothers.InGameCatMother;

namespace Editor.Tests.Actions
{
    public class BiteShould
    {
        [Test]
        public void AddAThingToBitten()
        {
            var thingId = 0;
            var thing = new Thing(thingId);
            var inGameThings = new InGameThings(new []{thing});
            var bite = new Bite(inGameThings);
            
            bite.Execute(thing);

            var actualValue = inGameThings.GetBittenGetThing();
            var expectedValue = new Thing(0); 
            Assert.AreEqual(expectedValue, actualValue);
        } 
    }

    public class InGameThings
    {
        private readonly Thing[] _things;
        private Thing _bitten;
        public InGameThings(Thing[] things)
        {
            _things = things;
        }
        
        public Thing GetBittenGetThing() => _bitten;

        public void UpdateBittenThing(Thing thing) => _bitten = thing;
    }

    public class Bite
    {
        private readonly InGameThings _inGameThings;

        public Bite( InGameThings inGameThings) => _inGameThings = inGameThings;

        public void Execute(Thing thing) => _inGameThings.UpdateBittenThing(thing);
    }

    public struct Thing
    {
        private readonly int _id;

        public Thing(int id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return $"Id: {_id}";
        }
    }
}