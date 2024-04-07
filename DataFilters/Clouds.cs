using Space.Language;

namespace Space.DataFilters;

public class Clouds
{
    public static void CheckCloudsType(List<string> clouds, Dictionary<string, List<int>> optionalDates)
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
                if (string.IsNullOrEmpty(clouds[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingCloudData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                string cloudType = clouds[i - 1].ToLower();

                if (cloudType is "cumulus" or "nimbus")
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