using Space.Language;

namespace Space.DataFilters;

public class Wind
{
    public static void CheckWindSpeed(List<string> wind, Dictionary<string, List<int>> optionalDates)
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
                if (string.IsNullOrEmpty(wind[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingWindData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                _ = int.TryParse(wind[i - 1], out int temp);

                if (temp is < 0 or > 11)
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