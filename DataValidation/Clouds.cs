namespace Space.DataValidation
{
    internal class Clouds
    {
        public static void CheckCloudsType(List<string> clouds, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);

                if (string.IsNullOrEmpty(clouds[i - 1]))
                {
                    Console.WriteLine($"Clouds data is missing for {i} July!");
                    badConditions.Add(i - 1);
                    continue;
                }

                string cloudType = clouds[i - 1].ToLower();

                if (isNum is true && (cloudType == "cumulus" || cloudType == "nimbus"))
                    badConditions.Add(i - 1);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
