namespace DiceThrowLogic.Actors.Player
{
    public class Player : Actor
    {
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public Player(string name, int maxHealth, int currentHealth, int maxMana, int currentMana, int minDmg, int maxDmg, ImageSource portrait) : base(name, maxHealth, minDmg, maxDmg, portrait)
        {
            CurrentHealth = currentHealth;
            MaxMana = maxMana;  
            CurrentMana = currentMana;
        }
    }
}
