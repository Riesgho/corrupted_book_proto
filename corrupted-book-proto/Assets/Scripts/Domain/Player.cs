

using System;

namespace Assets.CorruptedBook.Domain
{
    public class Player
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Corruption { get; set; }
        public string Name { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public IInventory ConsumableBag { get; private set; }
        public float InteractionDistance { get; internal set; }

        public Player(string name, int maxHealth, int currentHealth, int corruption, PlayerStatus playerStatus, IInventory consumableBag, float interactionDistance)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            Corruption = corruption;
            PlayerStatus = playerStatus;
            ConsumableBag = consumableBag;
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

        public void AddItemToInventory(IItem consumable)
        {
            ConsumableBag.AddItem(consumable);
        }

        public void ConsumeItem(IItem consumable)
        {
            ConsumableBag.RemoveItem(consumable);
        }
    }

    public enum PlayerStatus
    {
        Normal,
        Dead
    }
}
