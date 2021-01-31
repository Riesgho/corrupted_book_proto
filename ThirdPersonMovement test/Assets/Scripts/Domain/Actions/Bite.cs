using Infrastructure;

namespace Domain.Actions
{
    public class Bite
    {
        private readonly InGameThings _inGameThings;
        private readonly InGameCat _inGameCat;

        public Bite(InGameThings inGameThings, InGameCat inGameCat)
        {
            _inGameThings = inGameThings;
            _inGameCat = inGameCat;
        }

        public void Execute(Thing thing)
        {
            var thingToBite = thing;

            if (_inGameCat.Get().CanBite(thing))
                thingToBite = thing.Bitten(_inGameCat);

            _inGameThings.UpdateThings(thingToBite);
        }
    }
}