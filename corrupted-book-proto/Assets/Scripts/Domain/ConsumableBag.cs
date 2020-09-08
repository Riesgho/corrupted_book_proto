using Assets.CorruptedBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CorruptedBook.Domain
{
    public class ConsumableBag : IInventory
    {
        public List<IItem> bag { get; private set; }
        public ConsumableBag()
        {
            bag = new List<IItem>();
        }
        public void AddItem(IItem tool)
        {
            bag.Add(tool);
        }

        public void RemoveItem(IItem consumable)
        {
            bag.Remove(consumable);
        }
    }
}
