using DiceThrowLogic.Actors.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
