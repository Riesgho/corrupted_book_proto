

namespace CorruptedBook.Core
{
    public class Player
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Corruption { get; set; }
        public string Name { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public float InteractionDistance { get; internal set; }

        public Player(string name, int maxHealth, int currentHealth, int corruption, PlayerStatus playerStatus, float interactionDistance)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Corruption = corruption;
            PlayerStatus = playerStatus;
            InteractionDistance = interactionDistance;
        }

        public void AddCurrentHealth(int healthAmount)
        {
            CurrentHealth = CurrentHealth + healthAmount > MaxHealth ? MaxHealth : CurrentHealth + healthAmount;
        }

        public void AddMaxHealth(int healthAmount)
        {
            MaxHealth += healthAmount;
            AddCurrentHealth(healthAmount);
        }

        public void SustractCurrentHealth(int healthAmount)
        {
            CurrentHealth = CurrentHealth - healthAmount <= 0 ? 0 : CurrentHealth - healthAmount;
            if (CurrentHealth <= 0) PlayerStatus = PlayerStatus.Dead;
        }
    }

    public enum PlayerStatus
    {
        Normal,
        Dead
    }
}
