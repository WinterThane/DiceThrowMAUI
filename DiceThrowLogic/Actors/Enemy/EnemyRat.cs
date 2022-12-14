namespace DiceThrowLogic.Actors.Enemy
{
    public class EnemyRat : Actor
    {
        public int ExperiencePoints { get; set; }

        public EnemyRat(string name, int health, int minDmg, int maxDmg, int exp, ImageSource portrait) : base(name, health, minDmg, maxDmg, portrait)
        {
            ExperiencePoints = exp;
        }
    }
}
