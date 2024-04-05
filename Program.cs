using Space.DataAccess;

namespace SpaceSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, dear user!");

            while (true)
            {
                Console.WriteLine("Please, enter the path to or the name of the folder where you are storing the CSV files!");
                string folderPath = Console.ReadLine();

                if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
                {
                    if (Directory.GetFiles(folderPath, "*.csv").Length > 0)
                        FileReader.ReadingCSVFile(folderPath);
                    else
                        Console.WriteLine("Sorry, but it looks like there is no csv files in this folder.");

                }
                else
                    Console.WriteLine("Sorry, this folder does not exist! PLease, try with another one.");
            }

        }
    }
}
