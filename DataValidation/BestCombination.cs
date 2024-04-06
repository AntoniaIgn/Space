namespace Space.DataValidation
{
    internal class BestCombination
    {
        public static string[] FindBestCombination(Dictionary<Spaceport, float> spaceportsInfo)
        {
            string[] bestCombination = [];
            float score, bestScore = float.MaxValue;

            foreach(Spaceport spaceport in spaceportsInfo.Keys)
            {
                score = (float)((spaceport.Latitude * 0.5) + (spaceportsInfo[spaceport] * 0.5));

                if (score < bestScore)
                {
                    bestScore = score;
                    bestCombination = [spaceport.Location, spaceport.LaunchBestDate];
                }
            }

            return bestCombination;
        }
    }
}
