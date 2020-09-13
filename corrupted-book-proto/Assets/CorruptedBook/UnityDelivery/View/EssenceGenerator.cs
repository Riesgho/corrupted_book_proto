using UnityEngine;
using Assets.CorruptedBook.Domain;
using Assets.CorruptedBook.Core.Providers;
using System.Linq;
using Assets.CorruptedBook.Core;

public class EssenceGenerator : MonoBehaviour, IEssenceProvider
{
    [SerializeField] private EssencesSOProvider essencesSOProvider;
    public Essence GetEssence()
    {
        var essences = essencesSOProvider.essences;
        return essencesSOProvider.essences.ElementAt(Random.Range(0, essences.Count));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
