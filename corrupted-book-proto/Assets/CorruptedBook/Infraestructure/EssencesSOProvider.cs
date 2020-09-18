using System.Collections.Generic;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using UnityEngine;

namespace CorruptedBook.Infraestructure
{
    [CreateAssetMenu]
    public class EssencesSOProvider : ScriptableObject, IEssenceProvider
    {
        [SerializeField] private List<Essence> essences = new List<Essence>();
        public Essence GetEssence()
        {
            throw new System.NotImplementedException();
        }
    }
}
