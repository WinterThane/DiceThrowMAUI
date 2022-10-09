using DiceThrowLogic.Actors.Enemy;
using DiceThrowLogic.Actors.Player;

namespace DiceThrowLogic.DiceFunctions
{
    public static class StringFunctions
    {
        public static string MakePlayerDetails(Player player)
        {
            var details = string.Empty;

            details += "Damage: " + player.MinDamage.ToString() + " - " + player.MaxDamage.ToString() + "\n";
            details += "Strength: " + "\n";
            details += "Dexterity: " + "\n";
            details += "Intelligence: " + "\n";

            return details;
        }

        public static string MakeEnemyDetails(EnemyRat enemy)
        {
            var details = string.Empty;

            details += "Damage: " + enemy.MinDamage.ToString() + " - " + enemy.MaxDamage.ToString() + "\n";
            details += "Experience: " + enemy.ExperiencePoints.ToString() + "\n";
            details += "No. of kills: " + "\n";
            details += "Lore: " + "\n";

            return details;
        }
    }
}
