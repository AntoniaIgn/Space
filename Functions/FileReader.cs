using SpaceSolution.Functions;

namespace Space.Functions;

internal class FileReader
{
    public static void ReadingCSVFile(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {

            List<string> optionalDates = new() { };
            int i = 1;

            try
            {
                using var reader = new StreamReader(File.OpenRead(file));
                while (!reader.EndOfStream)
                {
                    string content = reader.ReadLine();
                    var elements = content.Split(',').ToList();
                    //add empty cell handler!

                    switch (i)
                    {
                        case 1:
                            optionalDates = elements;
                            break;
                        case 2:
                            Temperature.CheckTemperature(elements, optionalDates);
                            break;
                        case 3:
                            //function checking wind criteria 
                            break;
                        case 4:
                            //function checking humidity criteria 
                            break;
                        case 5:
                            //function checking precipitation criteria 
                            break;
                        case 6:
                            //function checking lidhtings criteria 
                            break;
                        case 7:
                            //function checking wind criteria 
                            break;
                        default:
                            //error handler
                            break;
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Oh, no! It seems like there is a problem with file reading.");
            }
        }
    }
}