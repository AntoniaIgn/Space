﻿using Space.DataValidation;

namespace Space.DataAccess;

internal class FileReader
{
    public static Dictionary<Spaceport,float> ReadingCSVFile(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        Dictionary<Spaceport, float> spaceportsInfo = new();

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);

            Console.WriteLine(fileName + " : ");

            Dictionary<string, List<int>> optionalDates = new();

            try
            {
                using var reader = new StreamReader(File.OpenRead(file));
                while (!reader.EndOfStream)
                {
                    string? content = reader.ReadLine();
                    var lineData = content?.Split(',').ToList();

                    if (lineData is null || lineData?.Count < 2)
                    {
                        Console.WriteLine($"Something in '{fileName}'.csv is wrong! Check for missing information(empty cells).");
                        break;
                    }

                    var lineParameter = lineData[0].ToString();
                    var elements = lineData.Skip(1).ToList();

                    if (lineParameter.Contains("Day"))
                    {
                        for (int j = 0; j < elements.Count; j++)
                        {
                            if (!string.IsNullOrEmpty(elements[j]))
                                optionalDates[elements[j]] = [];
                        }

                    }
                    else if (lineParameter.Contains("Temperature"))
                        Temperature.CheckTemperature(elements, optionalDates);
                    else if (lineParameter.Contains("Wind"))
                        Wind.CheckWindSpeed(elements, optionalDates);
                    else if (lineParameter.Contains("Humidity"))
                        Humidity.CheckHumidity(elements, optionalDates);
                    else if (lineParameter.Contains("Precipitation"))
                        Precipitation.CheckPrecipitation(elements, optionalDates);
                    else if (lineParameter.Contains("Lightning"))
                        Lightning.CheckLightning(elements, optionalDates);
                    else if (lineParameter.Contains("Clouds"))
                        Clouds.CheckCloudsType(elements, optionalDates);
                    else
                    {
                        Console.WriteLine($"Invalid parameter in '{fileName}'. Please, check!");
                        break;
                    }
                }

                reader.Close();

                var bestDate = BestDate.FindBestDate(optionalDates);
                Console.WriteLine("The best date for launching is : " + bestDate[0]);

                Spaceport spaceport = new(fileName, bestDate[0]);
                spaceportsInfo.Add(spaceport, float.Parse(bestDate[1]));
            }
            catch (Exception)
            {
                Console.WriteLine("Oh, no! It seems like there is a problem with file reading.");
            }
        }

        return spaceportsInfo;
    }
}