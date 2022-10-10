namespace DiceThrowLogic.DiceFunctions
{
    public static class CalculateDamage
    {
        public static int MakeDamage(int minDmg, int maxDmg)
        {
            Random random = new();
            int damage = random.Next(minDmg, maxDmg + 1);

            return damage;
        }
    }
}
