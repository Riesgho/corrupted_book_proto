

namespace Assets.CorruptedBook.Domain
{
    public class Player
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Name { get; set; }

        public Player(string name, int maxHealth, int currentHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}
