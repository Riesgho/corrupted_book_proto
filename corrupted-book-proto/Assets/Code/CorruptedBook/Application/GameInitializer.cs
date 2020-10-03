using Boo.Lang;
using CorruptedBook.Core;
using CorruptedBook.Infrastructure;
using CorruptedBook.Presentation;
using CorruptedBook.View;
using UnityEngine;

namespace CorruptedBook.Application
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private GamePlayView gamePlayView;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private HudView hudView;
        [SerializeField] private LevelController levelController;
        [SerializeField] private ItemProvider itemProvider;
        private RandomProvider randomProvider;
        private Player player;
        // Use this for initialization
        void Start()
        {
            randomProvider = new RandomProvider();
            player = new Player(playerConfig.PlayerName, playerConfig.MaxHealth, playerConfig.CurrentHealth, playerConfig.Corruption, playerConfig.PlayerStatus,playerConfig.InteractionDistance);
            hudView.OnStart(player);
            playerView.OnStart(player);
            levelController.OnStart(playerView,itemProvider,randomProvider, new InventoryRepository());
        }

    }

    public class InventoryRepository: IInventoryRepository
    {
        private List<Item> items;

        public InventoryRepository()
        {
            items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
