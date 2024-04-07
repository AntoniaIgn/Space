using Space.Models;

namespace Space.DataFilters;

public class LocationSelector
{
    public static Spaceport GetBestLocationSpaceport(Dictionary<Spaceport, float> spaceportsInfo)
    {
        Spaceport bestSpaceport = new();

        float score, bestScore = float.MaxValue;

        foreach (Spaceport spaceport in spaceportsInfo.Keys)
        {
            // rate each location based on how close it is to the Equator
            // and the score of the relevant LaunchBestDate
            // as both factors have equal weight on the result
            // thus the lower the score is, the better
            score = (float)((spaceport.Latitude * 0.5) + (spaceportsInfo[spaceport] * 0.5));

            if (score < bestScore)
            {
                bestScore = score;
                bestSpaceport = spaceport;
            }
        }

        return bestSpaceport;
    }
}
