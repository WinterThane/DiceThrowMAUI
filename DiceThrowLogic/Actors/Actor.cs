namespace DiceThrowLogic.Actors
{
    public class Actor
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Actor(string name, int health, int minDmg, int maxDmg)
        {
            Name = name;
            MaxHealth = health;
            MinDamage = minDmg;
            MaxDamage = maxDmg;
        }

    }
}
