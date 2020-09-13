using UnityEngine;
using System.Collections.Generic;
using Assets.CorruptedBook.Core;

[CreateAssetMenu]
public class EssencesSOProvider : ScriptableObject
{
    public List<Essence> essences = new List<Essence>();
}
