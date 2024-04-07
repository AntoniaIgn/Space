using Space.Language;

namespace Space.DataFilters;

public class Precipitation
{
    public static void CheckPrecipitation(List<string> precipitation, Dictionary<string, List<int>> optionalDates)
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
                if (string.IsNullOrEmpty(precipitation[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingPrecipitationData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                if (precipitation[i - 1] is not "0")
                    badConditions.Add(date);
            }
            else
                badConditions.Add(date);

            dayIndex++;
        }

        foreach (string i in badConditions)
            optionalDates.Remove(i);
    }
}