using Domain.Actions;

namespace Infrastructure
{
    public class InGameThings
    {
        private readonly Thing[] _things;
        private Thing _bitten;

        public InGameThings(Thing[] things)
        {
            _things = things;
        }

        public Thing GetBitten() => _bitten;

        public void UpdateThings(Thing thing)
        {
            _things[thing.Id] = thing;
        }

        public Thing Get(int id)
        {
            return _things[id];
        }
    }
}