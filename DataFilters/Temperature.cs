using Space.Language;

namespace Space.DataFilters;

public class Temperature
{
    public static void CheckTemperature(List<string> temperature, Dictionary<string, List<int>> optionalDates)
    {
        if (optionalDates.Count is 0)
            return;

        List<string> badConditions = new();
        int dayCounter = 1;

        foreach (string date in optionalDates.Keys)
        {
            bool isNum = int.TryParse(date, out int i);
            if (isNum)
            {
                if (string.IsNullOrEmpty(temperature[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingTemperatureData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                _ = int.TryParse(temperature[i - 1], out int temp);

                if (temp is <= 0 or >= 33)
                    badConditions.Add(date);
            }
            else
                badConditions.Add(date);

            dayCounter++;
        }

        foreach (string i in badConditions)
            optionalDates.Remove(i);
    }
}