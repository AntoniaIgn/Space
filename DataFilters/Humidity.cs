using Space.Language;

namespace Space.DataFilters;

public class Humidity
{
    public static void CheckHumidity(List<string> humidity, Dictionary<string, List<int>> optionalDates)
    {
        if (optionalDates.Count is 0)
            return;

        List<string> badConditions = new();
        int dayIndex = 0;

        foreach (string date in optionalDates.Keys)
        {
            bool isNum = int.TryParse(date, out int i);

            if (isNum)
            {
                if (string.IsNullOrEmpty(humidity[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingHumidityData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                _ = int.TryParse(humidity[i - 1], out int temp);

                if (temp is < 0 or >= 55)
                    badConditions.Add(date);

                optionalDates[date].Add(temp);
            }
            else
                badConditions.Add(date);

            dayIndex++;
        }

        foreach (string i in badConditions)
            optionalDates.Remove(i);
    }
}