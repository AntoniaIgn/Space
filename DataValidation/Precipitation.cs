namespace Space.DataValidation
{
    internal class Precipitation
    {
        public static void CheckPrecipitation(List<string> precipitation, Dictionary<string, List<int>> optionalDates)
        {
            List<int> badConditions = new();

            foreach (string date in optionalDates.Keys)
            {
                bool isNum = int.TryParse(date, out int i);

                if (isNum is true && precipitation[i - 1] != "0")
                    badConditions.Add(i - 1);
            }

            foreach (int i in badConditions)
                optionalDates.Remove(i.ToString());
        }
    }
}
