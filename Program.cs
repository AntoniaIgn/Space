using Space.DataAccess;
using Space.DataValidation;

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
                    {
                        var data = FileReader.ReadingCSVFile(folderPath);
                        var spaceports = data.Keys.ToList();
                        var bestCombination = BestCombination.FindBestCombination(data);

                        FileWriter.WritingSCVFile(spaceports, folderPath);
                        break;
                    }
                    else
                        Console.WriteLine("Sorry, but it looks like there is no csv files in this folder.");

                }
                else
                    Console.WriteLine("Sorry, this folder does not exist! PLease, try with another one.");
            }

            Console.WriteLine("\nPlease, enter your e-mail first and then password. We need them in order to send the analysis file.");
            string senderEmail = Console.ReadLine();
            string senderPassword = Console.ReadLine();

            Console.WriteLine("\nTo who you want to send the file? Please, enter the receiver email.");
            string receiver = Console.ReadLine();
        }
    }
}
