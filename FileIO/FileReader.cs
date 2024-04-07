using Space.DataFilters;
using Space.Language;
using Space.Models;

namespace Space.FileIO;

public class FileReader
{
    public static SpaceportsResponse ReadFileData()
    {
        while (true)
        {
            Console.WriteLine($"\n{LangHelper.GetString("EnterFolderPath")}");
            string? folderPath = Console.ReadLine();

            if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
            {
                if (Directory.GetFiles(folderPath, "*.csv").Length > 0)
                {
                    return new SpaceportsResponse
                    {
                        SpaceportsData = ReadCSVFile(folderPath),
                        FolderPath = folderPath
                    };
                }
                else
                    Console.WriteLine($"\n{LangHelper.GetString("MissingCSVFiles")}");
            }
            else
                Console.WriteLine($"\n{LangHelper.GetString("MissingFolder")}");
        }
    }

    static Dictionary<Spaceport, float> ReadCSVFile(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        Dictionary<Spaceport, float> spaceportsInfo = new(); // Key: spaceport, Value: score of weather condition

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
                        Console.WriteLine(string.Format($"\n{LangHelper.GetString("MissingCSVFileData")}", fileName));
                        break;
                    }

                    var lineParameter = lineData[0].ToString(); // the first element on the line is a parameter
                    var elements = lineData.Skip(1).ToList(); // everything else is cells containing data

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
                        Console.WriteLine(string.Format($"\n{LangHelper.GetString("InvalidParameter")}", fileName));
                        break;
                    }
                }

                reader.Close();

                if (optionalDates.Count is 0)
                {
                    string text = LangHelper.GetString("MissingSuitableDate")!;
                    Console.WriteLine(text);
                    Spaceport spaceportWithoutDate = new()
                    {
                        Location = fileName,
                        LaunchBestDate = text
                    };

                    spaceportsInfo.Add(spaceportWithoutDate, float.MaxValue);
                    continue;
                }

                var bestDateInfo = DateSelector.FindBestDate(optionalDates);
                Console.WriteLine($"{LangHelper.GetString("BestlaunchingDate")} {bestDateInfo.Date}");

                Spaceport spaceport = new()
                {
                    Location = fileName,
                    LaunchBestDate = bestDateInfo.Date
                };

                spaceportsInfo.Add(spaceport, bestDateInfo.Score);
            }
            catch (Exception)
            {
                Console.WriteLine($"\n{LangHelper.GetString("ReadingError")}");
            }
        }

        return spaceportsInfo;
    }
}