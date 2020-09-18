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
        [FormerlySerializedAs("gameplayView")] [SerializeField] private GamePlayView gamePlayView;
        [SerializeField] private HudView hudView;
        private Player player;
        // Use this for initialization
        void Start()
        {
            player = new Player(playerConfig.PlayerName, playerConfig.MaxHealth, playerConfig.CurrentHealth, playerConfig.Corruption, playerConfig.PlayerStatus,1);
            hudView.OnStart(player);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
