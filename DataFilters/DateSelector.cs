using Space.Language;
using Space.Models;

namespace Space.DataFilters;

public class DateSelector
{
    public static BestDateInfo FindBestDate(Dictionary<string, List<int>> optionalDates)
    {
        float score, bestScore = float.MaxValue;
        int bestDate = 0;

        if (optionalDates.Count is 0)
        {
            return new BestDateInfo();
        }

        foreach (var date in optionalDates.Keys)
        {
            // determine which date is optimal based on wind and humidity index
            // as both factors have equal weight on the result
            // thus the lower the score is, the better
            score = (float)((optionalDates[date][0] * 0.5) + (optionalDates[date][1] * 0.5));

            if (score < bestScore)
            {
                bestScore = score;
                bestDate = int.Parse(date);
            }
        }

        return new BestDateInfo
        {
            Date = bestDate + $"{LangHelper.GetString("Month")}",
            Score = bestScore
        };
    }
}