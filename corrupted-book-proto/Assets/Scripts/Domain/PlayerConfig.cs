using Assets.CorruptedBook.Domain;
using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int corruption;
    [SerializeField] private PlayerStatus playerStatus;
    public string PlayerName { get => playerName; }
    public int MaxHealth { get => maxHealth; }
    public int CurrentHealth { get => currentHealth; }
    public int Corruption { get => corruption; }
    public PlayerStatus PlayerStatus { get => playerStatus; }
}