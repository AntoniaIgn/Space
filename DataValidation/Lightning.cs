namespace Space.DataValidation
{
    internal class Lightning
    {
        public static void CheckLightning(List<string> lightings, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);

                if (isNum is true && lightings[i - 1].ToLower() != "no")
                    badConditions.Add(i - 1);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
