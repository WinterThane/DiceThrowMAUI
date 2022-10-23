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

        public static int ThrowDie(string die)
        {
            int result = 0;
            Random random = new();

            switch (die)
            {
                case "1d4":
                    result = random.Next(1, 4 + 1);
                    break;
                case "1d6":
                    result = random.Next(1, 6 + 1);
                    break;
                case "1d8":
                    result = random.Next(1, 8 + 1);
                    break;
                case "1d10":
                    result = random.Next(1, 10 + 1);
                    break;
                case "1d12":
                    result = random.Next(1, 12 + 1);
                    break;
                case "2d4":
                    result = random.Next(2, 4 + 1);
                    break;
                case "2d6":
                    result = random.Next(2, 6 + 1);
                    break;
            }    

            return result;
        }

        public static string ThrowDie(int die)
        {
            string result = die switch
            {
                1 => "diceone.png",
                2 => "dicetwo.png",
                3 => "dicethree.png",
                4 => "dicefour.png",
                5 => "dicefive.png",
                6 => "dicesix.png",
                _ => "diceone.png",
            };
            return result;
        }
    }
}
