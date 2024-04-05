namespace Space.DataValidation
{
    internal class Wind
    {
        public static void CheckWindSpeed(List<string> wind, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);
                int.TryParse(wind[i - 1], out int temp);

                if (isNum is true && (temp < 0 || temp > 11))
                    badConditions.Add(i - 1);

                optionalDates[date].Add(temp);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
