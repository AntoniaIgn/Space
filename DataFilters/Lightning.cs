using Space.Language;

namespace Space.DataFilters;

public class Lightning
{
    public static void CheckLightning(List<string> lightning, Dictionary<string, List<int>> optionalDates)
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
                if (string.IsNullOrEmpty(lightning[i - 1]))
                {
                    Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingLightningData")}", i));
                    badConditions.Add(date);
                    continue;
                }

                if (!lightning[i - 1].ToLower().Equals("no"))
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