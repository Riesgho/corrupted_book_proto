using Assets.CorruptedBook.Core;
using Assets.CorruptedBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CorruptedBook.Domain
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
