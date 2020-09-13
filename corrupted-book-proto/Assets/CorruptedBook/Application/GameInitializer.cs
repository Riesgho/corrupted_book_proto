using UnityEngine;
using Assets.CorruptedBook.Domain;
using UnityEditor;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private GameplayView gameplayView;
    [SerializeField] private HudView hudView;
    [SerializeField] private EssenceGenerator consumableGenerator;
    private Player player;
    // Use this for initialization
    void Start()
    {
        player = new Player(playerConfig.PlayerName, playerConfig.MaxHealth, playerConfig.CurrentHealth, playerConfig.Corruption, playerConfig.PlayerStatus,1);
        gameplayView.OnStart(consumableGenerator);
        hudView.OnStart(player);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
