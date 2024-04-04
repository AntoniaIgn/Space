using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSolution.Functions
{
    internal class Temperature
    {
        public static void CheckTemperature(List<string> temperature, List<string> optionalDates)
        {
            for (int i = 1; i < temperature.Count(); i++)
            {
                if (int.Parse(temperature[i]) < 0 && int.Parse(temperature[i]) > 33)
                    optionalDates.Remove(i.ToString());
            }
        }
    }
}
