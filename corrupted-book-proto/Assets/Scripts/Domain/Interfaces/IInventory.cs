﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CorruptedBook.Domain
{
    public interface IInventory
    {
        void AddItem(IItem item);
        void RemoveItem(IItem consumable);
    }
}
