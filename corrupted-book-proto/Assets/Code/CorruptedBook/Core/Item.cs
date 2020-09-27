using UnityEngine;
using UnityEngine.UI;

namespace CorruptedBook.Core
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private int id;

        public Item(int id)
        {
            this.id = id;
        }

        public int Id => id;
    }
}