public class Player
{
    public string Name { get; private set; }
    public int Corruption { get; private set; }
    public int MaxHealth { get; private set; }
    public Player(string name, int maxHealth, int corruption)
    {
        Name = name;
        MaxHealth = maxHealth;
        Corruption = corruption;
    }

  
}