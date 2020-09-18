using System.Collections.Generic;

namespace CorruptedBook.Core
{
    public class EssenceBag
    {
        public List<Essence> bag { get; private set; }
        public EssenceBag()
        {
            bag = new List<Essence>();
        }
        public void AddItem(Essence tool)
        {
            bag.Add(tool);
        }

        public void RemoveItem(Essence consumable)
        {
            bag.Remove(consumable);
        }
    }
}
