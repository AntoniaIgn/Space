namespace Space.DataValidation
{
    internal class BestDate
    {
        public static string[] FindBestDate(Dictionary<string, List<int>> optionalDates)
        {
            double score, bestScore = double.MaxValue;
            int bestDate = 0;

            foreach (var date in optionalDates.Keys)
            {
                score = (optionalDates[date][0] * 0.5) + (optionalDates[date][1] * 0.5);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestDate = int.Parse(date);
                }
            }

            return [bestDate.ToString() + " July", bestScore.ToString()];
        }
    }
}
