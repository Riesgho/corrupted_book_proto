using CorruptedBook.Core.Providers;
using UnityEngine;

namespace CorruptedBook.Infrastructure
{
    public class RandomProvider: IRandomProvider
    {
        public int GetRandomValue(int from, int to)
        {
            return Random.Range(from, to);
        }
    }
}