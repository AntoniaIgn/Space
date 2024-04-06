namespace Space.DataValidation
{
    internal class Temperature
    {
        public static void CheckTemperature(List<string> temperature, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);

                if (string.IsNullOrEmpty(temperature[i - 1]))
                {
                    Console.WriteLine($"Temperature data is missing for {i} July!");
                    badConditions.Add(i - 1);
                    continue;
                }

                int.TryParse(temperature[i - 1], out int temp);

                if (isNum is true && (temp < 0 || temp > 33))
                    badConditions.Add(i - 1);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
