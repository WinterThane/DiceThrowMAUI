namespace DiceThrowLogic.Actors.Player
{
    public class Player : Actor
    {
        public int MaxMana { get; set; }

        public Player(string name, int health, int maxMana, int minDmg, int maxDmg, ImageSource portrait) : base(name, health, minDmg, maxDmg, portrait)
        {
            MaxMana = maxMana;  
        }
    }
}
