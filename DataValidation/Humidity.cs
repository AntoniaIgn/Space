namespace Space.DataValidation
{
    internal class Humidity
    {
        public static void CheckHumidity(List<string> humidity, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);
                int.TryParse(humidity[i - 1], out int temp);

                if (isNum is true && (temp < 0 || temp > 55))
                    badConditions.Add(i - 1);

                optionalDates[date].Add(temp);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
