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
        public List<Item> GenerateItems(int amountToGenerate)
        {
            var itemsGenerated = new List<Item>();
            for (int i = 0; i < amountToGenerate; i++)
            {
                var itemToAdd = items.First(item => item.Id == Random.Range(0, items.Count - 1));
                itemsGenerated.Add(itemToAdd);
            }
            return itemsGenerated;
        }
    }
}