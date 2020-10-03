using System.Collections;
using CorruptedBook.Core.Providers;
using UnityEngine;
using System.Linq;
using CorruptedBook.Presentation;

namespace CorruptedBook.View
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private DoorView[] doors;
        [SerializeField] private WorldStashView[] stashes;

        public void OnStart(PlayerView player, IItemProvider itemProvider, IRandomProvider randomProvider, IInventoryRepository inventoryRepository)
        {
            foreach (var door in doors)
            {
                door.OnStart(player);
            }

            foreach (var worldStash in stashes)
            {
                worldStash.OnStart(player, itemProvider,  randomProvider,inventoryRepository);
            }
        }
    }
}