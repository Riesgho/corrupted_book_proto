using CorruptedBook.Core;
using CorruptedBook.Infraestructure;
using CorruptedBook.UnityDelivery.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace CorruptedBook.Application
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private GamePlayView gamePlayView;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private HudView hudView;
        private Player player;
        // Use this for initialization
        void Start()
        {
            player = new Player(playerConfig.PlayerName, playerConfig.MaxHealth, playerConfig.CurrentHealth, playerConfig.Corruption, playerConfig.PlayerStatus,playerConfig.InteractionDistance);
            hudView.OnStart(player);
            playerView.OnStart(player);
        }

    }
}
