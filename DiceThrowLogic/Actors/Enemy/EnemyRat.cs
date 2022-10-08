namespace DiceThrowLogic.Actors.Enemy
{
    public class EnemyRat : Actor
    {
        public int ExperiencePoints { get; set; }

        public EnemyRat(string name, int health, int minDmg, int maxDmg, int exp) : base(name, health, minDmg, maxDmg)
        {
            ExperiencePoints = exp;
        }
    }
}
