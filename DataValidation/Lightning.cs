namespace Space.DataValidation
{
    internal class Lightning
    {
        public static void CheckLightning(List<string> lightning, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);

                if (string.IsNullOrEmpty(lightning[i - 1]))
                {
                    Console.WriteLine($"Lightning data is missing for {i} July!");
                    badConditions.Add(i - 1);
                    continue;
                }

                if (isNum is true && lightning[i - 1].ToLower() != "no")
                    badConditions.Add(i - 1);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
