namespace DiceThrowLogic.Actors.Player
{
    public class Player : Actor
    {
        public int MaxMana { get; set; }

        public Player(string name, int health, int minDmg, int maxDmg, int maxMana) : base(name, health, minDmg, maxDmg)
        {
            MaxMana = maxMana;  
        }
    }
}
