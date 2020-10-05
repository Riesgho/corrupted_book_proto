using System.Collections.Generic;
using System.Linq;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CorruptedBook.Infrastructure
{
    [CreateAssetMenu(fileName = "Provider", menuName = "Item", order = 0)]
    public class ItemProvider : ScriptableObject, IItemProvider
    {
        [SerializeField] private List<Item> items = new List<Item>();
        public List<Item> GenerateItems(int amount)
        {
            var itemsGenerated = new List<Item>();
            for (int i = 0; i < amount; i++)
            {
                var itemToAdd = items[Random.Range(0, items.Count)];
                itemsGenerated.Add(itemToAdd);
            }
            return itemsGenerated;
        }
    }
}