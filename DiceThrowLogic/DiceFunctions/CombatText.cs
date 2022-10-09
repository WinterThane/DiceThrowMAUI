namespace DiceThrowLogic.DiceFunctions
{
    public static class CombatText
    {
        public static List<string> ListOfTextRows { get; set; }

        public static string CombatTextResult(string input)
        {
            ListOfTextRows.Add(input);
            var result = MakeRows(ListOfTextRows);
            return result;
        }

        private static string MakeRows(List<string> inputList)
        {
            var result = string.Empty;

            for (int i = inputList.Count - 1; i >= 0; i--)
            {
                result += inputList[i] + "\n";
            }

            return result;
        }

        public static void CleanCombatText()
        {
            ListOfTextRows.Clear();
        }
    }
}
