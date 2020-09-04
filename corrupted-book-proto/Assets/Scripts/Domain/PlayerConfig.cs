using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private int maxHealth;
    [SerializeField] private int corruption;

    public string PlayerName { get => playerName; }
    public int MaxHealth { get => maxHealth; }
    public int Corruption { get => corruption; }
}