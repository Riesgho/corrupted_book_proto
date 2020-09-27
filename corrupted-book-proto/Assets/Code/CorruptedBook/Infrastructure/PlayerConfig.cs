using CorruptedBook.Core;
using UnityEngine;

namespace CorruptedBook.Infrastructure
{
    [CreateAssetMenu]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private string playerName;
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private int corruption;
        [SerializeField] private PlayerStatus playerStatus;
        [SerializeField] private float interactionDistance;

        public string PlayerName => playerName;

        public int MaxHealth => maxHealth;

        public int CurrentHealth => currentHealth;

        public int Corruption => corruption;

        public PlayerStatus PlayerStatus => playerStatus;

        public float InteractionDistance => interactionDistance;
    }
}